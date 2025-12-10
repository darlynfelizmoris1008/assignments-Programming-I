using System;
using System.Linq;
using System.Windows.Forms;
using manuahorros.D;
using manuahorros.data;

namespace manuahorros.ui
{
    public partial class AccountsForm : Form
    {
        private readonly MemberRepository _memberRepo = new MemberRepository();
        private readonly AccountRepository _accountRepo = new AccountRepository();

        private bool _isMenuCollapsed = true;
        private int _menuExpandedWidth;
        private int _menuCollapsedWidth = 60;

        private Account? _selectedAccount;

        public AccountsForm()
        {
            InitializeComponent();
            InitializeAccountTypeCombo();
            LoadMembers();

            _menuExpandedWidth = pnlMenu.Width;
            pnlMenu.Width = _menuCollapsedWidth;
        }

        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            var form = new MembersForm();
            form.Show();
            this.Close();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            var form = new TransactionsForm();
            form.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeAccountTypeCombo()
        {
            cboAccountType.DataSource = Enum.GetValues(typeof(AccountType));
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
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadAccountsForSelectedMember()
        {
            try
            {
                if (cboMembers.SelectedItem is not Member member)
                {
                    dgvAccounts.DataSource = null;
                    _selectedAccount = null;
                    ClearInputs();
                    return;
                }

                int memberId = member.Id;

                var accounts = _accountRepo.GetByMemberId(memberId);
                dgvAccounts.DataSource = accounts;

                if (dgvAccounts.Columns["Id"] != null)
                    dgvAccounts.Columns["Id"].Visible = false;

                if (dgvAccounts.Columns["MemberId"] != null)
                    dgvAccounts.Columns["MemberId"].Visible = false;

                if (dgvAccounts.Columns["Member"] != null)
                    dgvAccounts.Columns["Member"].Visible = false;

                if (dgvAccounts.Columns["CreatedAt"] != null)
                    dgvAccounts.Columns["CreatedAt"].Visible = false;

                if (dgvAccounts.Columns["AccountNumber"] != null)
                    dgvAccounts.Columns["AccountNumber"].HeaderText = "Account Number";

                if (dgvAccounts.Columns["AccountType"] != null)
                    dgvAccounts.Columns["AccountType"].HeaderText = "Account Type";

                if (dgvAccounts.Columns["Balance"] != null)
                    dgvAccounts.Columns["Balance"].HeaderText = "Balance";

                if (dgvAccounts.Columns["IsActive"] != null)
                    dgvAccounts.Columns["IsActive"].HeaderText = "Active";

                if (dgvAccounts.Rows.Count > 0)
                {
                    dgvAccounts.ClearSelection();
                    dgvAccounts.Rows[0].Selected = true;
                    LoadSelectedAccountFromGrid();
                }
                else
                {
                    _selectedAccount = null;
                    ClearInputs();
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

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMembers.SelectedValue == null)
                {
                    MessageBox.Show("Please select a member.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string accountNumber = txtAccountNumber.Text.Trim();

                if (string.IsNullOrWhiteSpace(accountNumber))
                {
                    MessageBox.Show("Account Number is required.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboAccountType.SelectedItem == null)
                {
                    MessageBox.Show("Please select an account type.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int memberId = ((Member)cboMembers.SelectedItem).Id;
                var accountType = (AccountType)cboAccountType.SelectedItem;

                var account = new Account
                {
                    MemberId = memberId,
                    AccountNumber = accountNumber,
                    AccountType = accountType,
                    IsActive = chkIsActive.Checked
                };

                var newId = _accountRepo.Add(account);

                if (newId <= 0)
                {
                    MessageBox.Show("Error inserting account.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtAccountNumber.Text = string.Empty;
                txtAccountNumber.Focus();

                LoadAccountsForSelectedMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unexpected error:\n{ex.Message}",
                    "Exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cboMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadAccountsForSelectedMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error updating account list:\n{ex.Message}",
                    "Update Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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
        }
        private void LoadSelectedAccountFromGrid()
        {
            if (dgvAccounts.CurrentRow == null)
                return;

            if (dgvAccounts.CurrentRow.DataBoundItem is not Account account)
                return;

            _selectedAccount = account;

            txtAccountNumber.Text = account.AccountNumber;
            cboAccountType.SelectedItem = account.AccountType;
            chkIsActive.Checked = account.IsActive;

            var members = _memberRepo.GetAll();
            var member = members.FirstOrDefault(m => m.Id == account.MemberId);
            if (member != null)
            {
                cboMembers.SelectedValue = member.Id;
            }
        }

        private void ClearInputs()
        {
            txtAccountNumber.Text = string.Empty;
            chkIsActive.Checked = true;

            if (cboAccountType.Items.Count > 0)
                cboAccountType.SelectedIndex = 0;
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadSelectedAccountFromGrid();
            }
        }
        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            if (_selectedAccount == null)
            {
                MessageBox.Show("Please select an account first.",
                    "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string accountNumber = txtAccountNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                MessageBox.Show("Account Number is required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboAccountType.SelectedItem == null)
            {
                MessageBox.Show("Please select an account type.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int memberId = ((Member)cboMembers.SelectedItem).Id;
            var accountType = (AccountType)cboAccountType.SelectedItem;

            _selectedAccount.MemberId = memberId;
            _selectedAccount.AccountNumber = accountNumber;
            _selectedAccount.AccountType = accountType;
            _selectedAccount.IsActive = chkIsActive.Checked;

            var confirm = MessageBox.Show(
                "Do you want to update this account?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            bool success = _accountRepo.Update(_selectedAccount);

            if (!success)
            {
                MessageBox.Show("Error updating account.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Account updated successfully.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadAccountsForSelectedMember();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (_selectedAccount == null)
            {
                MessageBox.Show("Please select an account first.",
                    "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this account?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            bool success = _accountRepo.Delete(_selectedAccount.Id);

            if (!success)
            {
                MessageBox.Show("Error deleting account.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Account deleted successfully.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _selectedAccount = null;
            ClearInputs();
            LoadAccountsForSelectedMember();
        }
    }
}
