namespace manuahorros.ui
{
    partial class MembersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MembersForm));
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtStudentId = new TextBox();
            label1 = new Label();
            btnAddMember = new Button();
            txtPhone = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dgvMembers = new DataGridView();
            pnlMenu = new Panel();
            btnToggleMenu = new PictureBox();
            btnExit = new Button();
            btnTransactions = new Button();
            btnAccounts = new Button();
            btnMembers = new Button();
            label5 = new Label();
            pnlMemberForm = new Panel();
            btnDeleteMember = new PictureBox();
            btnUpdaterMember = new PictureBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnToggleMenu).BeginInit();
            pnlMemberForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnDeleteMember).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnUpdaterMember).BeginInit();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(95, 68);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(208, 23);
            txtFullName.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(95, 168);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(211, 23);
            txtEmail.TabIndex = 1;
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(95, 124);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(211, 23);
            txtStudentId.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 68);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 3;
            label1.Text = "Full Name";
            // 
            // btnAddMember
            // 
            btnAddMember.BackColor = Color.LightSkyBlue;
            btnAddMember.FlatStyle = FlatStyle.Flat;
            btnAddMember.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddMember.Location = new Point(110, 294);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(116, 23);
            btnAddMember.TabIndex = 4;
            btnAddMember.Text = "Add Member";
            btnAddMember.UseVisualStyleBackColor = false;
            btnAddMember.Click += btnAddMember_Click;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(95, 223);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(211, 23);
            txtPhone.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 231);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 7;
            label2.Text = "Phone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 176);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 8;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 127);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 9;
            label4.Text = "Student ID";
            label4.Click += label4_Click;
            // 
            // dgvMembers
            // 
            dgvMembers.BackgroundColor = SystemColors.ButtonHighlight;
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Location = new Point(364, 411);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.Size = new Size(1127, 160);
            dgvMembers.TabIndex = 10;
            dgvMembers.CellContentClick += dgvMembers_CellContentClick_1;
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
            pnlMenu.Size = new Size(313, 594);
            pnlMenu.TabIndex = 11;
            // 
            // btnToggleMenu
            // 
            btnToggleMenu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggleMenu.BorderStyle = BorderStyle.FixedSingle;
            btnToggleMenu.Image = (Image)resources.GetObject("btnToggleMenu.Image");
            btnToggleMenu.Location = new Point(273, 12);
            btnToggleMenu.Name = "btnToggleMenu";
            btnToggleMenu.Size = new Size(37, 36);
            btnToggleMenu.TabIndex = 17;
            btnToggleMenu.TabStop = false;
            btnToggleMenu.Click += pictureBox1_Click;
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
            label5.Location = new Point(0, 9);
            label5.Name = "label5";
            label5.Size = new Size(256, 30);
            label5.TabIndex = 12;
            label5.Text = "MANUAHORROS - Panel";
            label5.Click += label5_Click;
            // 
            // pnlMemberForm
            // 
            pnlMemberForm.BorderStyle = BorderStyle.FixedSingle;
            pnlMemberForm.Controls.Add(btnDeleteMember);
            pnlMemberForm.Controls.Add(btnUpdaterMember);
            pnlMemberForm.Controls.Add(label6);
            pnlMemberForm.Controls.Add(txtFullName);
            pnlMemberForm.Controls.Add(label1);
            pnlMemberForm.Controls.Add(btnAddMember);
            pnlMemberForm.Controls.Add(label2);
            pnlMemberForm.Controls.Add(label3);
            pnlMemberForm.Controls.Add(txtPhone);
            pnlMemberForm.Controls.Add(label4);
            pnlMemberForm.Controls.Add(txtStudentId);
            pnlMemberForm.Controls.Add(txtEmail);
            pnlMemberForm.Location = new Point(699, 30);
            pnlMemberForm.Name = "pnlMemberForm";
            pnlMemberForm.Size = new Size(353, 364);
            pnlMemberForm.TabIndex = 12;
            // 
            // btnDeleteMember
            // 
            btnDeleteMember.Image = (Image)resources.GetObject("btnDeleteMember.Image");
            btnDeleteMember.Location = new Point(276, 287);
            btnDeleteMember.Name = "btnDeleteMember";
            btnDeleteMember.Size = new Size(30, 30);
            btnDeleteMember.TabIndex = 15;
            btnDeleteMember.TabStop = false;
            btnDeleteMember.Click += btnDeleteMember_Click;
            // 
            // btnUpdaterMember
            // 
            btnUpdaterMember.ErrorImage = null;
            btnUpdaterMember.Image = (Image)resources.GetObject("btnUpdaterMember.Image");
            btnUpdaterMember.Location = new Point(27, 287);
            btnUpdaterMember.Name = "btnUpdaterMember";
            btnUpdaterMember.Size = new Size(30, 30);
            btnUpdaterMember.TabIndex = 14;
            btnUpdaterMember.TabStop = false;
            btnUpdaterMember.Click += btnUpdateMember_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(47, 9);
            label6.Name = "label6";
            label6.Size = new Size(231, 30);
            label6.TabIndex = 13;
            label6.Text = "Member Management";
            label6.Click += label6_Click;
            // 
            // MembersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1539, 594);
            Controls.Add(pnlMemberForm);
            Controls.Add(pnlMenu);
            Controls.Add(dgvMembers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MembersForm";
            Text = "MANUAHORROS - Members";
            Load += MembersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnToggleMenu).EndInit();
            pnlMemberForm.ResumeLayout(false);
            pnlMemberForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnDeleteMember).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnUpdaterMember).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtStudentId;
        private Label label1;
        private Button btnAddMember;
        private TextBox txtPhone;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dgvMembers;
        private Panel pnlMenu;
        private Label label5;
        private Panel pnlMemberForm;
        private Label label6;
        private Button btnMembers;
        private Button btnAccounts;
        private Button btnTransactions;
        private Button btnExit;
        private PictureBox btnToggleMenu;
        private PictureBox btnDeleteMember;
        private PictureBox btnUpdaterMember;
    }
}