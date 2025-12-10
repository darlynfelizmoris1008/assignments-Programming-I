namespace manuahorros.ui
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblInstruction = new Label();
            btnMembers = new Button();
            btnAccounts = new Button();
            btnExit = new Button();
            btnTransactions = new Button();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(602, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(233, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MANUAHORROS";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.Location = new Point(621, 86);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(203, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Student Savings Control System";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtitle.Click += lblSubtitle_Click;
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Font = new Font("Segoe UI", 10F);
            lblInstruction.Location = new Point(83, 43);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(222, 19);
            lblInstruction.TabIndex = 2;
            lblInstruction.Text = "Please select an option to continue";
            // 
            // btnMembers
            // 
            btnMembers.Location = new Point(130, 114);
            btnMembers.Name = "btnMembers";
            btnMembers.Size = new Size(134, 23);
            btnMembers.TabIndex = 3;
            btnMembers.Text = "Members";
            btnMembers.UseVisualStyleBackColor = true;
            btnMembers.Click += btnMembers_Click;
            // 
            // btnAccounts
            // 
            btnAccounts.Location = new Point(130, 215);
            btnAccounts.Name = "btnAccounts";
            btnAccounts.Size = new Size(134, 23);
            btnAccounts.TabIndex = 4;
            btnAccounts.Text = "Accounts";
            btnAccounts.UseVisualStyleBackColor = true;
            btnAccounts.Click += btnAccounts_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(12, 616);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnTransactions
            // 
            btnTransactions.Location = new Point(130, 313);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Size = new Size(134, 23);
            btnTransactions.TabIndex = 6;
            btnTransactions.Text = "Transactions";
            btnTransactions.UseVisualStyleBackColor = true;
            btnTransactions.Click += btnTransactions_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(45, 161);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(390, 294);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblInstruction);
            panel1.Controls.Add(btnMembers);
            panel1.Controls.Add(btnTransactions);
            panel1.Controls.Add(btnAccounts);
            panel1.Location = new Point(519, 132);
            panel1.Name = "panel1";
            panel1.Size = new Size(412, 507);
            panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1007, 175);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(277, 257);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1569, 651);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(btnExit);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MANUAHORROS - Main Menu";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblInstruction;
        private Button btnMembers;
        private Button btnAccounts;
        private Button btnExit;
        private Button btnTransactions;
        private PictureBox pictureBox2;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}