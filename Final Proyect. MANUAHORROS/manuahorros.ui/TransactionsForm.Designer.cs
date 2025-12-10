namespace manuahorros.ui
{
    partial class TransactionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionsForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cboMembers = new ComboBox();
            cboTransactionType = new ComboBox();
            cboAccounts = new ComboBox();
            txtAmount = new TextBox();
            txtDescription = new TextBox();
            btnApplyTransaction = new Button();
            dgvTransactions = new DataGridView();
            label6 = new Label();
            lblCurrentBalance = new Label();
            pnlMenu = new Panel();
            btnToggleMenu = new PictureBox();
            btnExit = new Button();
            btnTransactions = new Button();
            btnAccounts = new Button();
            btnMembers = new Button();
            label7 = new Label();
            panel1 = new Panel();
            btnDeleteMember = new PictureBox();
            lblBalanceValue = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnToggleMenu).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnDeleteMember).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 84);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "Member";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(116, 261);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 1;
            label2.Text = "Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 207);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Amount";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(116, 314);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 3;
            label4.Text = "Desc";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(95, 144);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 4;
            label5.Text = "Account";
            // 
            // cboMembers
            // 
            cboMembers.FormattingEnabled = true;
            cboMembers.Location = new Point(170, 84);
            cboMembers.Name = "cboMembers";
            cboMembers.Size = new Size(191, 23);
            cboMembers.TabIndex = 5;
            cboMembers.SelectedIndexChanged += cboMembers_SelectedIndexChanged;
            // 
            // cboTransactionType
            // 
            cboTransactionType.FormattingEnabled = true;
            cboTransactionType.Location = new Point(170, 258);
            cboTransactionType.Name = "cboTransactionType";
            cboTransactionType.Size = new Size(191, 23);
            cboTransactionType.TabIndex = 6;
            // 
            // cboAccounts
            // 
            cboAccounts.FormattingEnabled = true;
            cboAccounts.Location = new Point(170, 141);
            cboAccounts.Name = "cboAccounts";
            cboAccounts.Size = new Size(191, 23);
            cboAccounts.TabIndex = 7;
            cboAccounts.SelectedIndexChanged += cboAccounts_SelectedIndexChanged;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(170, 199);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(191, 23);
            txtAmount.TabIndex = 8;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(170, 311);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(191, 23);
            txtDescription.TabIndex = 9;
            // 
            // btnApplyTransaction
            // 
            btnApplyTransaction.BackColor = Color.LightSkyBlue;
            btnApplyTransaction.FlatStyle = FlatStyle.Flat;
            btnApplyTransaction.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnApplyTransaction.Location = new Point(200, 404);
            btnApplyTransaction.Name = "btnApplyTransaction";
            btnApplyTransaction.Size = new Size(75, 24);
            btnApplyTransaction.TabIndex = 10;
            btnApplyTransaction.Text = "Apply";
            btnApplyTransaction.UseVisualStyleBackColor = false;
            btnApplyTransaction.Click += btnApplyTransaction_Click;
            // 
            // dgvTransactions
            // 
            dgvTransactions.BackgroundColor = SystemColors.ControlLightLight;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(363, 477);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.Size = new Size(1166, 150);
            dgvTransactions.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(442, 294);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 12;
            // 
            // lblCurrentBalance
            // 
            lblCurrentBalance.AutoSize = true;
            lblCurrentBalance.Location = new Point(130, 366);
            lblCurrentBalance.Name = "lblCurrentBalance";
            lblCurrentBalance.Size = new Size(48, 15);
            lblCurrentBalance.TabIndex = 13;
            lblCurrentBalance.Text = "Balance";
            lblCurrentBalance.Click += lblCurrentBalance_Click;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.SteelBlue;
            pnlMenu.Controls.Add(btnToggleMenu);
            pnlMenu.Controls.Add(btnExit);
            pnlMenu.Controls.Add(btnTransactions);
            pnlMenu.Controls.Add(btnAccounts);
            pnlMenu.Controls.Add(btnMembers);
            pnlMenu.Controls.Add(label7);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(313, 651);
            pnlMenu.TabIndex = 14;
            // 
            // btnToggleMenu
            // 
            btnToggleMenu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggleMenu.BorderStyle = BorderStyle.FixedSingle;
            btnToggleMenu.Image = (Image)resources.GetObject("btnToggleMenu.Image");
            btnToggleMenu.Location = new Point(273, 9);
            btnToggleMenu.Name = "btnToggleMenu";
            btnToggleMenu.Size = new Size(37, 36);
            btnToggleMenu.TabIndex = 18;
            btnToggleMenu.TabStop = false;
            btnToggleMenu.Click += btnToggleMenu_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(12, 616);
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 9);
            label7.Name = "label7";
            label7.Size = new Size(256, 30);
            label7.TabIndex = 12;
            label7.Text = "MANUAHORROS - Panel";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDeleteMember);
            panel1.Controls.Add(lblBalanceValue);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(cboMembers);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblCurrentBalance);
            panel1.Controls.Add(cboAccounts);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtAmount);
            panel1.Controls.Add(btnApplyTransaction);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(cboTransactionType);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(636, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(479, 439);
            panel1.TabIndex = 15;
            // 
            // btnDeleteMember
            // 
            btnDeleteMember.Image = (Image)resources.GetObject("btnDeleteMember.Image");
            btnDeleteMember.Location = new Point(346, 366);
            btnDeleteMember.Name = "btnDeleteMember";
            btnDeleteMember.Size = new Size(30, 30);
            btnDeleteMember.TabIndex = 16;
            btnDeleteMember.TabStop = false;
            btnDeleteMember.Click += btnDeleteTransaction_Click;
            // 
            // lblBalanceValue
            // 
            lblBalanceValue.AutoSize = true;
            lblBalanceValue.Location = new Point(184, 366);
            lblBalanceValue.Name = "lblBalanceValue";
            lblBalanceValue.Size = new Size(28, 15);
            lblBalanceValue.TabIndex = 15;
            lblBalanceValue.Text = "0.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(95, 22);
            label8.Name = "label8";
            label8.Size = new Size(261, 30);
            label8.TabIndex = 14;
            label8.Text = "Transaction Management";
            // 
            // TransactionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1584, 651);
            Controls.Add(panel1);
            Controls.Add(pnlMenu);
            Controls.Add(label6);
            Controls.Add(dgvTransactions);
            Name = "TransactionsForm";
            Text = "TransactionsForm";
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnToggleMenu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnDeleteMember).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cboMembers;
        private ComboBox cboTransactionType;
        private ComboBox cboAccounts;
        private TextBox txtAmount;
        private TextBox txtDescription;
        private Button btnApplyTransaction;
        private DataGridView dgvTransactions;
        private Label label6;
        private Label lblCurrentBalance;
        private Panel pnlMenu;
        private Button btnExit;
        private Button btnTransactions;
        private Button btnAccounts;
        private Button btnMembers;
        private Label label7;
        private Panel panel1;
        private Label label8;
        private PictureBox btnToggleMenu;
        private Label lblBalanceValue;
        private PictureBox btnDeleteMember;
    }
}