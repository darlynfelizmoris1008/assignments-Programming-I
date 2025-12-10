namespace manuahorros.ui
{
    partial class AccountsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountsForm));
            cboMembers = new ComboBox();
            txtAccountNumber = new TextBox();
            cboAccountType = new ComboBox();
            chkIsActive = new CheckBox();
            btnAddAccount = new Button();
            dgvAccounts = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pnlMenu = new Panel();
            btnToggleMenu = new PictureBox();
            btnExit = new Button();
            btnTransactions = new Button();
            btnAccounts = new Button();
            btnMembers = new Button();
            label5 = new Label();
            panel1 = new Panel();
            btnDeleteMember = new PictureBox();
            btnUpdaterMember = new PictureBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnToggleMenu).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnDeleteMember).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnUpdaterMember).BeginInit();
            SuspendLayout();
            // 
            // cboMembers
            // 
            cboMembers.FormattingEnabled = true;
            cboMembers.Location = new Point(122, 103);
            cboMembers.Name = "cboMembers";
            cboMembers.Size = new Size(198, 23);
            cboMembers.TabIndex = 0;
            cboMembers.SelectedIndexChanged += cboMembers_SelectedIndexChanged;
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.Location = new Point(122, 174);
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.Size = new Size(198, 23);
            txtAccountNumber.TabIndex = 1;
            txtAccountNumber.TextChanged += txtAccountNumber_TextChanged;
            // 
            // cboAccountType
            // 
            cboAccountType.FormattingEnabled = true;
            cboAccountType.Location = new Point(122, 244);
            cboAccountType.Name = "cboAccountType";
            cboAccountType.Size = new Size(198, 23);
            cboAccountType.TabIndex = 2;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(326, 244);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(59, 19);
            chkIsActive.TabIndex = 3;
            chkIsActive.Text = "Active";
            chkIsActive.UseVisualStyleBackColor = true;
            chkIsActive.CheckedChanged += chkIsActive_CheckedChanged;
            // 
            // btnAddAccount
            // 
            btnAddAccount.BackColor = Color.LightSkyBlue;
            btnAddAccount.FlatStyle = FlatStyle.Flat;
            btnAddAccount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddAccount.Location = new Point(151, 295);
            btnAddAccount.Name = "btnAddAccount";
            btnAddAccount.Size = new Size(97, 23);
            btnAddAccount.TabIndex = 4;
            btnAddAccount.Text = "Add Account";
            btnAddAccount.UseVisualStyleBackColor = false;
            btnAddAccount.Click += btnAddAccount_Click;
            // 
            // dgvAccounts
            // 
            dgvAccounts.BackgroundColor = SystemColors.ControlLightLight;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Location = new Point(406, 415);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.Size = new Size(1131, 150);
            dgvAccounts.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 106);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 6;
            label1.Text = "Member";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 174);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 7;
            label2.Text = "Account Member";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 248);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 8;
            label3.Text = "Account Type";
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.SteelBlue;
            pnlMenu.Controls.Add(btnToggleMenu);
            pnlMenu.Controls.Add(btnExit);
            pnlMenu.Controls.Add(btnTransactions);
            pnlMenu.Controls.Add(btnAccounts);
            pnlMenu.Controls.Add(btnMembers);
            pnlMenu.Controls.Add(label5);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(313, 603);
            pnlMenu.TabIndex = 12;
            // 
            // btnToggleMenu
            // 
            btnToggleMenu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggleMenu.BorderStyle = BorderStyle.FixedSingle;
            btnToggleMenu.Image = (Image)resources.GetObject("btnToggleMenu.Image");
            btnToggleMenu.Location = new Point(273, 9);
            btnToggleMenu.Name = "btnToggleMenu";
            btnToggleMenu.Size = new Size(37, 36);
            btnToggleMenu.TabIndex = 19;
            btnToggleMenu.TabStop = false;
            btnToggleMenu.Click += btnToggleMenu_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(12, 559);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 16;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnTransactions
            // 
            btnTransactions.Location = new Point(75, 242);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Size = new Size(134, 23);
            btnTransactions.TabIndex = 15;
            btnTransactions.Text = "Manage Transactions";
            btnTransactions.UseVisualStyleBackColor = true;
            btnTransactions.Click += btnTransactions_Click;
            // 
            // btnAccounts
            // 
            btnAccounts.Location = new Point(75, 152);
            btnAccounts.Name = "btnAccounts";
            btnAccounts.Size = new Size(134, 23);
            btnAccounts.TabIndex = 14;
            btnAccounts.Text = "Manage Accounts";
            btnAccounts.UseVisualStyleBackColor = true;
            btnAccounts.Click += btnAccounts_Click;
            // 
            // btnMembers
            // 
            btnMembers.Location = new Point(75, 68);
            btnMembers.Name = "btnMembers";
            btnMembers.Size = new Size(134, 23);
            btnMembers.TabIndex = 13;
            btnMembers.Text = "Manage Members";
            btnMembers.UseVisualStyleBackColor = true;
            btnMembers.Click += btnMembers_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 9);
            label5.Name = "label5";
            label5.Size = new Size(256, 30);
            label5.TabIndex = 12;
            label5.Text = "MANUAHORROS - Panel";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDeleteMember);
            panel1.Controls.Add(btnUpdaterMember);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cboMembers);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnAddAccount);
            panel1.Controls.Add(txtAccountNumber);
            panel1.Controls.Add(chkIsActive);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cboAccountType);
            panel1.Location = new Point(669, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 353);
            panel1.TabIndex = 13;
            // 
            // btnDeleteMember
            // 
            btnDeleteMember.Image = (Image)resources.GetObject("btnDeleteMember.Image");
            btnDeleteMember.Location = new Point(306, 288);
            btnDeleteMember.Name = "btnDeleteMember";
            btnDeleteMember.Size = new Size(30, 30);
            btnDeleteMember.TabIndex = 16;
            btnDeleteMember.TabStop = false;
            btnDeleteMember.Click += btnDeleteAccount_Click;
            // 
            // btnUpdaterMember
            // 
            btnUpdaterMember.ErrorImage = null;
            btnUpdaterMember.Image = (Image)resources.GetObject("btnUpdaterMember.Image");
            btnUpdaterMember.Location = new Point(64, 288);
            btnUpdaterMember.Name = "btnUpdaterMember";
            btnUpdaterMember.Size = new Size(30, 30);
            btnUpdaterMember.TabIndex = 15;
            btnUpdaterMember.TabStop = false;
            btnUpdaterMember.Click += btnUpdateAccount_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(89, 21);
            label4.Name = "label4";
            label4.Size = new Size(231, 30);
            label4.TabIndex = 13;
            label4.Text = "Account Management";
            // 
            // AccountsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1576, 603);
            Controls.Add(panel1);
            Controls.Add(pnlMenu);
            Controls.Add(dgvAccounts);
            Name = "AccountsForm";
            Text = "AccountsForm";
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnToggleMenu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnDeleteMember).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnUpdaterMember).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cboMembers;
        private TextBox txtAccountNumber;
        private ComboBox cboAccountType;
        private CheckBox chkIsActive;
        private Button btnAddAccount;
        private DataGridView dgvAccounts;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel pnlMenu;
        private Button btnExit;
        private Button btnTransactions;
        private Button btnAccounts;
        private Button btnMembers;
        private Label label5;
        private Panel panel1;
        private Label label4;
        private PictureBox btnToggleMenu;
        private PictureBox btnUpdaterMember;
        private PictureBox btnDeleteMember;
    }
}