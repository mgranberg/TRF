namespace TRF
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblLoginUserName = new System.Windows.Forms.Label();
            this.TxtLoginUserName = new System.Windows.Forms.TextBox();
            this.TxtLoginPass = new System.Windows.Forms.TextBox();
            this.LblLoginPass = new System.Windows.Forms.Label();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnNewUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Välkommen till TRF:s Medlemsregister";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Logga in";
            // 
            // LblLoginUserName
            // 
            this.LblLoginUserName.AutoSize = true;
            this.LblLoginUserName.Location = new System.Drawing.Point(41, 135);
            this.LblLoginUserName.Name = "LblLoginUserName";
            this.LblLoginUserName.Size = new System.Drawing.Size(79, 13);
            this.LblLoginUserName.TabIndex = 2;
            this.LblLoginUserName.Text = "Användarnamn";
            // 
            // TxtLoginUserName
            // 
            this.TxtLoginUserName.Location = new System.Drawing.Point(123, 132);
            this.TxtLoginUserName.Name = "TxtLoginUserName";
            this.TxtLoginUserName.Size = new System.Drawing.Size(100, 20);
            this.TxtLoginUserName.TabIndex = 3;
            // 
            // TxtLoginPass
            // 
            this.TxtLoginPass.Location = new System.Drawing.Point(123, 172);
            this.TxtLoginPass.Name = "TxtLoginPass";
            this.TxtLoginPass.PasswordChar = '*';
            this.TxtLoginPass.Size = new System.Drawing.Size(100, 20);
            this.TxtLoginPass.TabIndex = 5;
            // 
            // LblLoginPass
            // 
            this.LblLoginPass.AutoSize = true;
            this.LblLoginPass.Location = new System.Drawing.Point(66, 175);
            this.LblLoginPass.Name = "LblLoginPass";
            this.LblLoginPass.Size = new System.Drawing.Size(51, 13);
            this.LblLoginPass.TabIndex = 4;
            this.LblLoginPass.Text = "Lösenord";
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(123, 209);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 23);
            this.BtnLogin.TabIndex = 6;
            this.BtnLogin.Text = "Logga in!";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnNewUser
            // 
            this.BtnNewUser.Location = new System.Drawing.Point(123, 249);
            this.BtnNewUser.Name = "BtnNewUser";
            this.BtnNewUser.Size = new System.Drawing.Size(75, 23);
            this.BtnNewUser.TabIndex = 7;
            this.BtnNewUser.Text = "Ny Medlem";
            this.BtnNewUser.UseVisualStyleBackColor = true;
            this.BtnNewUser.Click += new System.EventHandler(this.BtnNewUser_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 381);
            this.Controls.Add(this.BtnNewUser);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.TxtLoginPass);
            this.Controls.Add(this.LblLoginPass);
            this.Controls.Add(this.TxtLoginUserName);
            this.Controls.Add(this.LblLoginUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblLoginUserName;
        private System.Windows.Forms.TextBox TxtLoginUserName;
        private System.Windows.Forms.TextBox TxtLoginPass;
        private System.Windows.Forms.Label LblLoginPass;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button BtnNewUser;
    }
}

