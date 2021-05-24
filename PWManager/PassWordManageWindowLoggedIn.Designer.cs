
namespace PWManager
{
    partial class PassWordManageWindowLoggedIn
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.DecryptBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "PASSWORDS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(869, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 57);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add New Password";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(869, 388);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 50);
            this.button3.TabIndex = 5;
            this.button3.Text = "UpdateList";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 47);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(544, 372);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(563, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 171);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(855, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search";
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(796, 37);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(153, 22);
            this.SearchBox.TabIndex = 8;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(955, 37);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 9;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // DecryptBtn
            // 
            this.DecryptBtn.Location = new System.Drawing.Point(715, 35);
            this.DecryptBtn.Name = "DecryptBtn";
            this.DecryptBtn.Size = new System.Drawing.Size(75, 25);
            this.DecryptBtn.TabIndex = 10;
            this.DecryptBtn.Text = "Decrypt";
            this.DecryptBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DecryptBtn.UseVisualStyleBackColor = false;
            this.DecryptBtn.Visible = false;
            this.DecryptBtn.Click += new System.EventHandler(this.DecryptBtn_Click);
            // 
            // PassWordManageWindowLoggedIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 450);
            this.Controls.Add(this.DecryptBtn);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "PassWordManageWindowLoggedIn";
            this.Text = "PassWordManageWindowLoggedIn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PasswordManagerWindow_Closed);
            this.Load += new System.EventHandler(this.PassWordManageWindowLoggedIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button DecryptBtn;
    }
}