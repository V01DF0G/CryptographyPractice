
namespace PWManager
{
    partial class PasswordManagerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordManagerControl));
            this.Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PWNameBox = new System.Windows.Forms.TextBox();
            this.PWPasswordBox = new System.Windows.Forms.TextBox();
            this.PWApplicationBox = new System.Windows.Forms.TextBox();
            this.PWCommentBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(3, 15);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(49, 17);
            this.Name.TabIndex = 0;
            this.Name.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Application:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Comment:";
            // 
            // PWNameBox
            // 
            this.PWNameBox.BackColor = System.Drawing.SystemColors.Control;
            this.PWNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PWNameBox.Location = new System.Drawing.Point(90, 17);
            this.PWNameBox.Name = "PWNameBox";
            this.PWNameBox.ReadOnly = true;
            this.PWNameBox.Size = new System.Drawing.Size(123, 15);
            this.PWNameBox.TabIndex = 4;
            // 
            // PWPasswordBox
            // 
            this.PWPasswordBox.BackColor = System.Drawing.SystemColors.Control;
            this.PWPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PWPasswordBox.Location = new System.Drawing.Point(90, 41);
            this.PWPasswordBox.Name = "PWPasswordBox";
            this.PWPasswordBox.PasswordChar = '*';
            this.PWPasswordBox.ReadOnly = true;
            this.PWPasswordBox.Size = new System.Drawing.Size(123, 15);
            this.PWPasswordBox.TabIndex = 5;
            this.PWPasswordBox.UseSystemPasswordChar = true;
            this.PWPasswordBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // PWApplicationBox
            // 
            this.PWApplicationBox.BackColor = System.Drawing.SystemColors.Control;
            this.PWApplicationBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PWApplicationBox.Location = new System.Drawing.Point(90, 70);
            this.PWApplicationBox.Name = "PWApplicationBox";
            this.PWApplicationBox.ReadOnly = true;
            this.PWApplicationBox.Size = new System.Drawing.Size(123, 15);
            this.PWApplicationBox.TabIndex = 6;
            // 
            // PWCommentBox
            // 
            this.PWCommentBox.BackColor = System.Drawing.SystemColors.Control;
            this.PWCommentBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PWCommentBox.Location = new System.Drawing.Point(90, 100);
            this.PWCommentBox.Name = "PWCommentBox";
            this.PWCommentBox.ReadOnly = true;
            this.PWCommentBox.Size = new System.Drawing.Size(123, 15);
            this.PWCommentBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(386, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 60);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(318, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 21);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Show password";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(309, 70);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(71, 60);
            this.UpdateBtn.TabIndex = 10;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(409, 4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(33, 23);
            this.DeleteButton.TabIndex = 11;
            this.DeleteButton.Text = "X";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // PasswordManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PWCommentBox);
            this.Controls.Add(this.PWApplicationBox);
            this.Controls.Add(this.PWPasswordBox);
            this.Controls.Add(this.PWNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Name);
            this.Size = new System.Drawing.Size(446, 133);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PWNameBox;
        private System.Windows.Forms.TextBox PWApplicationBox;
        private System.Windows.Forms.TextBox PWCommentBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button DeleteButton;
        public System.Windows.Forms.TextBox PWPasswordBox;
    }
}
