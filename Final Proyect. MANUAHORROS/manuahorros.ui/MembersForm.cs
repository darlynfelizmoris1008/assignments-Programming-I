using System;
using System.Windows.Forms;
using manuahorros.D;
using manuahorros.data;

namespace manuahorros.ui
{
    public partial class MembersForm : Form
    {
        private readonly MemberRepository _memberRepo = new MemberRepository();

        private Member? _selectedMember;

        private bool _isMenuCollapsed = false;
        private int _menuExpandedWidth;
        private int _menuCollapsedWidth = 60;

        public MembersForm()
        {
            InitializeComponent();

            _menuExpandedWidth = pnlMenu.Width;

            pnlMenu.Width = _menuCollapsedWidth;
            _isMenuCollapsed = true;

            UpdateToggleButtonPosition();

            LoadMembers();
        }

        private void UpdateToggleButtonPosition()
        {
            btnToggleMenu.Left = pnlMenu.Width - btnToggleMenu.Width - 10;
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            var form = new AccountsForm();
            form.Show();
            this.Close();
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

        private void LoadMembers()
        {
            var members = _memberRepo.GetAll();
            dgvMembers.DataSource = members;

            if (dgvMembers.Columns["Id"] != null)
                dgvMembers.Columns["Id"].Visible = false;

            if (dgvMembers.Columns["CreatedAt"] != null)
                dgvMembers.Columns["CreatedAt"].Visible = false;

            if (dgvMembers.Columns["FullName"] != null)
                dgvMembers.Columns["FullName"].HeaderText = "Name";

            if (dgvMembers.Columns["StudentId"] != null)
                dgvMembers.Columns["StudentId"].HeaderText = "Student ID";

            if (dgvMembers.Columns["Email"] != null)
                dgvMembers.Columns["Email"].HeaderText = "Email";

            if (dgvMembers.Columns["Phone"] != null)
                dgvMembers.Columns["Phone"].HeaderText = "Phone";

            if (dgvMembers.Rows.Count > 0)
            {
                dgvMembers.ClearSelection();
                dgvMembers.Rows[0].Selected = true;
                LoadSelectedMemberFromGrid();
            }
            else
            {
                _selectedMember = null;
                ClearInputs();
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string studentId = txtStudentId.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(studentId))
            {
                MessageBox.Show("Full Name and Student ID are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var member = new Member(fullName, studentId)
            {
                Email = email,
                Phone = phone
            };

            var newId = _memberRepo.Add(member);

            if (newId <= 0)
            {
                MessageBox.Show("Error inserting member.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearInputs();
            LoadMembers();
        }

        private void LoadSelectedMemberFromGrid()
        {
            if (dgvMembers.CurrentRow == null)
                return;

            if (dgvMembers.CurrentRow.DataBoundItem is not Member member)
                return;

            _selectedMember = member;

            txtFullName.Text = member.FullName;
            txtStudentId.Text = member.StudentId;
            txtEmail.Text = member.Email;
            txtPhone.Text = member.Phone;
        }

        private void ClearInputs()
        {
            txtFullName.Text = string.Empty;
            txtStudentId.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;

            txtFullName.Focus();
        }

        private void dgvMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadSelectedMemberFromGrid();
        }

        private void dgvMembers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            LoadSelectedMemberFromGrid();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void MembersForm_Load(object sender, EventArgs e)
        {
            UpdateToggleButtonPosition();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            if (_selectedMember == null)
            {
                MessageBox.Show("Please select a member first.",
                    "Update Member", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = txtFullName.Text.Trim();
            string studentId = txtStudentId.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(studentId))
            {
                MessageBox.Show("Full Name and Student ID are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedMember.FullName = fullName;
            _selectedMember.StudentId = studentId;
            _selectedMember.Email = email;
            _selectedMember.Phone = phone;

            var confirmed = MessageBox.Show(
                "Do you want to update this member?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmed != DialogResult.Yes)
                return;

            bool success = _memberRepo.Update(_selectedMember);

            if (!success)
            {
                MessageBox.Show("Error updating member.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Member updated successfully.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadMembers();
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            if (_selectedMember == null)
            {
                MessageBox.Show("Please select a member first.",
                    "Delete Member", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmed = MessageBox.Show(
                "Are you sure you want to delete this member?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmed != DialogResult.Yes)
                return;

            bool success = _memberRepo.Delete(_selectedMember.Id);

            if (!success)
            {
                MessageBox.Show("Error deleting member.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Member deleted successfully.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _selectedMember = null;
            ClearInputs();
            LoadMembers();
        }
    }
}
