using System;
using System.Windows.Forms;

namespace manuahorros.ui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            var form = new MembersForm();
            form.ShowDialog();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            var form = new AccountsForm();
            form.ShowDialog();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            var form = new TransactionsForm();
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
