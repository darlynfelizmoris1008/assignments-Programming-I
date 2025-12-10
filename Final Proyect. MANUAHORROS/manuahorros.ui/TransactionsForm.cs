using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using manuahorros.D;
using manuahorros.data;

namespace manuahorros.ui
{
    public partial class TransactionsForm : Form
    {
        private readonly MemberRepository _memberRepo = new MemberRepository();
        private readonly AccountRepository _accountRepo = new AccountRepository();
        private readonly TransactionRepository _transactionRepo = new TransactionRepository();

        private bool _isMenuCollapsed = true;
        private int _menuExpandedWidth;
        private int _menuCollapsedWidth = 60;

        private Transaction? _selectedTransaction;

        public TransactionsForm()
        {
            InitializeComponent();

            _menuExpandedWidth = pnlMenu.Width;

            pnlMenu.Width = _menuCollapsedWidth;
            _isMenuCollapsed = true;

            UpdateToggleButtonPosition();

            InitializeTransactionTypeCombo();
            LoadMembers();
        }

        private void UpdateToggleButtonPosition()
        {
            btnToggleMenu.Left = pnlMenu.Width - btnToggleMenu.Width - 10;
        }

        private void InitializeTransactionTypeCombo()
        {
            cboTransactionType.DataSource = new[]
            {
                TransactionType.Deposit,
                TransactionType.Withdrawal
            };
        }

        private void LoadMembers()
        {
            try
            {
                var members = _memberRepo.GetAll();

                cboMembers.DataSource = members;
                cboMembers.DisplayMember = "FullName";
                cboMembers.ValueMember = "Id";

                if (cboMembers.Items.Count > 0)
                {
                    cboMembers.SelectedIndex = 0;
                    LoadAccountsForSelectedMember();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading members:\n{ex.Message}",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadAccountsForSelectedMember()
        {
            try
            {
                if (cboMembers.SelectedItem is not Member member)
                {
                    cboAccounts.DataSource = null;
                    dgvTransactions.DataSource = null;
                    lblBalanceValue.Text = "0.00";
                    _selectedTransaction = null;
                    return;
                }

                int memberId = member.Id;

                var accounts = _accountRepo.GetByMemberId(memberId);

                cboAccounts.DataSource = accounts;
                cboAccounts.DisplayMember = "AccountNumber";
                cboAccounts.ValueMember = "Id";

                if (cboAccounts.Items.Count > 0)
                {
                    cboAccounts.SelectedIndex = 0;
                    LoadTransactionsForSelectedAccount();
                }
                else
                {
                    dgvTransactions.DataSource = null;
                    lblBalanceValue.Text = "0.00";
                    _selectedTransaction = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading accounts:\n{ex.Message}",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadTransactionsForSelectedAccount()
        {
            try
            {
                if (cboAccounts.SelectedItem is not Account account)
                {
                    dgvTransactions.DataSource = null;
                    lblBalanceValue.Text = "0.00";
                    _selectedTransaction = null;
                    return;
                }

                int accountId = account.Id;
                var transactions = _transactionRepo.GetByAccountId(accountId);
                dgvTransactions.DataSource = transactions;

                if (dgvTransactions.Columns["Id"] != null)
                    dgvTransactions.Columns["Id"].Visible = false;

                if (dgvTransactions.Columns["AccountId"] != null)
                    dgvTransactions.Columns["AccountId"].Visible = false;

                if (dgvTransactions.Columns["Account"] != null)
                    dgvTransactions.Columns["Account"].Visible = false;

                if (dgvTransactions.Columns["LoanId"] != null)
                    dgvTransactions.Columns["LoanId"].Visible = false;

                if (dgvTransactions.Columns["Loan"] != null)
                    dgvTransactions.Columns["Loan"].Visible = false;

                if (dgvTransactions.Columns["CreatedAt"] != null)
                    dgvTransactions.Columns["CreatedAt"].Visible = false;

                if (dgvTransactions.Columns["Date"] != null)
                    dgvTransactions.Columns["Date"].HeaderText = "Date";

                if (dgvTransactions.Columns["Type"] != null)
                    dgvTransactions.Columns["Type"].HeaderText = "Type";

                if (dgvTransactions.Columns["Amount"] != null)
                    dgvTransactions.Columns["Amount"].HeaderText = "Amount";

                if (dgvTransactions.Columns["Description"] != null)
                    dgvTransactions.Columns["Description"].HeaderText = "Description";

                UpdateBalanceSummary(accountId);

                if (dgvTransactions.Rows.Count > 0)
                {
                    dgvTransactions.ClearSelection();
                    dgvTransactions.Rows[0].Selected = true;
                    LoadSelectedTransactionFromGrid();
                }
                else
                {
                    _selectedTransaction = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading transactions:\n{ex.Message}",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateBalanceSummary(int accountId)
        {
            var transactions = _transactionRepo.GetByAccountId(accountId);

            decimal balance = 0m;

            foreach (var t in transactions)
            {
                if (t.Type == TransactionType.Deposit)
                {
                    balance += t.Amount;
                }
                else if (t.Type == TransactionType.Withdrawal)
                {
                    balance -= t.Amount;
                }
            }

            lblBalanceValue.Text = balance.ToString("N2");
        }

        private void btnApplyTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboAccounts.SelectedValue == null)
                {
                    MessageBox.Show("Please select an account.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboTransactionType.SelectedItem == null)
                {
                    MessageBox.Show("Please select a transaction type.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(
                        txtAmount.Text.Trim(),
                        NumberStyles.Number,
                        CultureInfo.InvariantCulture,
                        out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Please enter a valid amount greater than zero.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var type = (TransactionType)cboTransactionType.SelectedItem;
                if (cboAccounts.SelectedItem is not Account account)
                {
                    MessageBox.Show("Please select an account.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int accountId = account.Id;

                var tx = new Transaction
                {
                    AccountId = accountId,
                    LoanId = null,
                    Date = DateTime.Now,
                    Type = type,
                    Amount = amount,
                    Description = txtDescription.Text.Trim()
                };

                var txId = _transactionRepo.Add(tx);

                if (txId <= 0)
                {
                    MessageBox.Show("Error inserting transaction.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtAmount.Text = string.Empty;
                txtDescription.Text = string.Empty;

                LoadTransactionsForSelectedAccount();

                MessageBox.Show("Transaction registered successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unexpected error applying transaction:\n{ex.Message}",
                    "Exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cboMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccountsForSelectedMember();
        }

        private void cboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTransactionsForSelectedAccount();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            var form = new AccountsForm();
            form.Show();
            this.Close();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            var form = new MembersForm();
            form.Show();
            this.Close();
        }

        private void btnToggleMenu_Click(object sender, EventArgs e)
        {
            if (_isMenuCollapsed)
            {
                pnlMenu.Width = _menuExpandedWidth;
                _isMenuCollapsed = false;
            }
            else
            {
                pnlMenu.Width = _menuCollapsedWidth;
                _isMenuCollapsed = true;
            }

            UpdateToggleButtonPosition();
        }

        private void lblCurrentBalance_Click(object sender, EventArgs e)
        {
        }

        private void LoadSelectedTransactionFromGrid()
        {
            if (dgvTransactions.CurrentRow == null)
                return;

            if (dgvTransactions.CurrentRow.DataBoundItem is not Transaction tx)
                return;

            _selectedTransaction = tx;
        }

        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadSelectedTransactionFromGrid();
            }
        }

        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            if (_selectedTransaction == null)
            {
                MessageBox.Show("Please select a transaction first.",
                    "Delete Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this transaction?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            bool success = _transactionRepo.Delete(_selectedTransaction.Id);

            if (!success)
            {
                MessageBox.Show("Error deleting transaction.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Transaction deleted successfully.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _selectedTransaction = null;
            LoadTransactionsForSelectedAccount();
        }
    }
}
