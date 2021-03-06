﻿namespace TRF
{
    partial class AdminControl
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
            this.LblAdminTitle = new System.Windows.Forms.Label();
            this.LstAdminMembers = new System.Windows.Forms.ListBox();
            this.LstAdminTigers = new System.Windows.Forms.ListBox();
            this.LblAdminMembers = new System.Windows.Forms.Label();
            this.LblAdminTigers = new System.Windows.Forms.Label();
            this.TxtAdminMemberFirstName = new System.Windows.Forms.TextBox();
            this.LblAdminMemberFirstName = new System.Windows.Forms.Label();
            this.LblAdminMemberLastName = new System.Windows.Forms.Label();
            this.TxtAdminMemberLastName = new System.Windows.Forms.TextBox();
            this.LblAdminMemberAdress = new System.Windows.Forms.Label();
            this.TxtAdminMemberAddress = new System.Windows.Forms.TextBox();
            this.LblAdminMemberEmail = new System.Windows.Forms.Label();
            this.TxtAdminMemberEmail = new System.Windows.Forms.TextBox();
            this.LblAdminMemberUserName = new System.Windows.Forms.Label();
            this.TxtAdminMemberUserName = new System.Windows.Forms.TextBox();
            this.LblAdminMemberPass = new System.Windows.Forms.Label();
            this.TxtAdminMemberPass = new System.Windows.Forms.TextBox();
            this.LblAdminTigerName = new System.Windows.Forms.Label();
            this.TxtAdminTigerName = new System.Windows.Forms.TextBox();
            this.LblAdminTigerAge = new System.Windows.Forms.Label();
            this.TxtAdminTigerAge = new System.Windows.Forms.TextBox();
            this.LblAdminTigerSpecies = new System.Windows.Forms.Label();
            this.TxtAdminTigerSpecies = new System.Windows.Forms.TextBox();
            this.BtnAdminLogout = new System.Windows.Forms.Button();
            this.LblAdminMemberId = new System.Windows.Forms.Label();
            this.TxtAdminMemberId = new System.Windows.Forms.TextBox();
            this.BtnAdminAddTiger = new System.Windows.Forms.Button();
            this.BtnAdminAddMember = new System.Windows.Forms.Button();
            this.BtnAdminEditMember = new System.Windows.Forms.Button();
            this.BtnAdminEditTiger = new System.Windows.Forms.Button();
            this.BtnAdminRemoveMember = new System.Windows.Forms.Button();
            this.BtnAdminRemoveTiger = new System.Windows.Forms.Button();
            this.WikiLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // LblAdminTitle
            // 
            this.LblAdminTitle.AutoSize = true;
            this.LblAdminTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAdminTitle.Location = new System.Drawing.Point(280, 20);
            this.LblAdminTitle.Name = "LblAdminTitle";
            this.LblAdminTitle.Size = new System.Drawing.Size(250, 16);
            this.LblAdminTitle.TabIndex = 1;
            this.LblAdminTitle.Text = "Du är inloggad som administratör";
            // 
            // LstAdminMembers
            // 
            this.LstAdminMembers.FormattingEnabled = true;
            this.LstAdminMembers.Location = new System.Drawing.Point(12, 63);
            this.LstAdminMembers.Name = "LstAdminMembers";
            this.LstAdminMembers.Size = new System.Drawing.Size(105, 121);
            this.LstAdminMembers.TabIndex = 2;
            this.LstAdminMembers.SelectedIndexChanged += new System.EventHandler(this.LstAdminMembers_SelectedIndexChanged);
            // 
            // LstAdminTigers
            // 
            this.LstAdminTigers.FormattingEnabled = true;
            this.LstAdminTigers.Location = new System.Drawing.Point(12, 220);
            this.LstAdminTigers.Name = "LstAdminTigers";
            this.LstAdminTigers.Size = new System.Drawing.Size(105, 121);
            this.LstAdminTigers.TabIndex = 3;
            this.LstAdminTigers.SelectedIndexChanged += new System.EventHandler(this.LstAdminTigers_SelectedIndexChanged);
            // 
            // LblAdminMembers
            // 
            this.LblAdminMembers.AutoSize = true;
            this.LblAdminMembers.Location = new System.Drawing.Point(9, 47);
            this.LblAdminMembers.Name = "LblAdminMembers";
            this.LblAdminMembers.Size = new System.Drawing.Size(61, 13);
            this.LblAdminMembers.TabIndex = 4;
            this.LblAdminMembers.Text = "Medlemmar";
            // 
            // LblAdminTigers
            // 
            this.LblAdminTigers.AutoSize = true;
            this.LblAdminTigers.Location = new System.Drawing.Point(9, 204);
            this.LblAdminTigers.Name = "LblAdminTigers";
            this.LblAdminTigers.Size = new System.Drawing.Size(87, 13);
            this.LblAdminTigers.TabIndex = 5;
            this.LblAdminTigers.Text = "Medlemens tigrar";
            // 
            // TxtAdminMemberFirstName
            // 
            this.TxtAdminMemberFirstName.Location = new System.Drawing.Point(180, 63);
            this.TxtAdminMemberFirstName.Name = "TxtAdminMemberFirstName";
            this.TxtAdminMemberFirstName.Size = new System.Drawing.Size(199, 20);
            this.TxtAdminMemberFirstName.TabIndex = 6;
            // 
            // LblAdminMemberFirstName
            // 
            this.LblAdminMemberFirstName.AutoSize = true;
            this.LblAdminMemberFirstName.Location = new System.Drawing.Point(126, 66);
            this.LblAdminMemberFirstName.Name = "LblAdminMemberFirstName";
            this.LblAdminMemberFirstName.Size = new System.Drawing.Size(48, 13);
            this.LblAdminMemberFirstName.TabIndex = 7;
            this.LblAdminMemberFirstName.Text = "Förnamn";
            // 
            // LblAdminMemberLastName
            // 
            this.LblAdminMemberLastName.AutoSize = true;
            this.LblAdminMemberLastName.Location = new System.Drawing.Point(119, 92);
            this.LblAdminMemberLastName.Name = "LblAdminMemberLastName";
            this.LblAdminMemberLastName.Size = new System.Drawing.Size(55, 13);
            this.LblAdminMemberLastName.TabIndex = 9;
            this.LblAdminMemberLastName.Text = "Efternamn";
            // 
            // TxtAdminMemberLastName
            // 
            this.TxtAdminMemberLastName.Location = new System.Drawing.Point(180, 89);
            this.TxtAdminMemberLastName.Name = "TxtAdminMemberLastName";
            this.TxtAdminMemberLastName.Size = new System.Drawing.Size(199, 20);
            this.TxtAdminMemberLastName.TabIndex = 8;
            // 
            // LblAdminMemberAdress
            // 
            this.LblAdminMemberAdress.AutoSize = true;
            this.LblAdminMemberAdress.Location = new System.Drawing.Point(129, 118);
            this.LblAdminMemberAdress.Name = "LblAdminMemberAdress";
            this.LblAdminMemberAdress.Size = new System.Drawing.Size(45, 13);
            this.LblAdminMemberAdress.TabIndex = 11;
            this.LblAdminMemberAdress.Text = "Address";
            // 
            // TxtAdminMemberAddress
            // 
            this.TxtAdminMemberAddress.Location = new System.Drawing.Point(180, 115);
            this.TxtAdminMemberAddress.Name = "TxtAdminMemberAddress";
            this.TxtAdminMemberAddress.Size = new System.Drawing.Size(199, 20);
            this.TxtAdminMemberAddress.TabIndex = 10;
            // 
            // LblAdminMemberEmail
            // 
            this.LblAdminMemberEmail.AutoSize = true;
            this.LblAdminMemberEmail.Location = new System.Drawing.Point(142, 144);
            this.LblAdminMemberEmail.Name = "LblAdminMemberEmail";
            this.LblAdminMemberEmail.Size = new System.Drawing.Size(32, 13);
            this.LblAdminMemberEmail.TabIndex = 13;
            this.LblAdminMemberEmail.Text = "Email";
            // 
            // TxtAdminMemberEmail
            // 
            this.TxtAdminMemberEmail.Location = new System.Drawing.Point(180, 141);
            this.TxtAdminMemberEmail.Name = "TxtAdminMemberEmail";
            this.TxtAdminMemberEmail.Size = new System.Drawing.Size(199, 20);
            this.TxtAdminMemberEmail.TabIndex = 12;
            // 
            // LblAdminMemberUserName
            // 
            this.LblAdminMemberUserName.AutoSize = true;
            this.LblAdminMemberUserName.Location = new System.Drawing.Point(441, 66);
            this.LblAdminMemberUserName.Name = "LblAdminMemberUserName";
            this.LblAdminMemberUserName.Size = new System.Drawing.Size(79, 13);
            this.LblAdminMemberUserName.TabIndex = 15;
            this.LblAdminMemberUserName.Text = "Användarnamn";
            // 
            // TxtAdminMemberUserName
            // 
            this.TxtAdminMemberUserName.Location = new System.Drawing.Point(521, 63);
            this.TxtAdminMemberUserName.Name = "TxtAdminMemberUserName";
            this.TxtAdminMemberUserName.Size = new System.Drawing.Size(191, 20);
            this.TxtAdminMemberUserName.TabIndex = 14;
            // 
            // LblAdminMemberPass
            // 
            this.LblAdminMemberPass.AutoSize = true;
            this.LblAdminMemberPass.Location = new System.Drawing.Point(464, 92);
            this.LblAdminMemberPass.Name = "LblAdminMemberPass";
            this.LblAdminMemberPass.Size = new System.Drawing.Size(51, 13);
            this.LblAdminMemberPass.TabIndex = 17;
            this.LblAdminMemberPass.Text = "Lösenord";
            // 
            // TxtAdminMemberPass
            // 
            this.TxtAdminMemberPass.Location = new System.Drawing.Point(521, 89);
            this.TxtAdminMemberPass.Name = "TxtAdminMemberPass";
            this.TxtAdminMemberPass.Size = new System.Drawing.Size(191, 20);
            this.TxtAdminMemberPass.TabIndex = 16;
            // 
            // LblAdminTigerName
            // 
            this.LblAdminTigerName.AutoSize = true;
            this.LblAdminTigerName.Location = new System.Drawing.Point(139, 223);
            this.LblAdminTigerName.Name = "LblAdminTigerName";
            this.LblAdminTigerName.Size = new System.Drawing.Size(35, 13);
            this.LblAdminTigerName.TabIndex = 19;
            this.LblAdminTigerName.Text = "Namn";
            // 
            // TxtAdminTigerName
            // 
            this.TxtAdminTigerName.Location = new System.Drawing.Point(180, 220);
            this.TxtAdminTigerName.Name = "TxtAdminTigerName";
            this.TxtAdminTigerName.Size = new System.Drawing.Size(199, 20);
            this.TxtAdminTigerName.TabIndex = 18;
            // 
            // LblAdminTigerAge
            // 
            this.LblAdminTigerAge.AutoSize = true;
            this.LblAdminTigerAge.Location = new System.Drawing.Point(143, 249);
            this.LblAdminTigerAge.Name = "LblAdminTigerAge";
            this.LblAdminTigerAge.Size = new System.Drawing.Size(31, 13);
            this.LblAdminTigerAge.TabIndex = 21;
            this.LblAdminTigerAge.Text = "Ålder";
            // 
            // TxtAdminTigerAge
            // 
            this.TxtAdminTigerAge.Location = new System.Drawing.Point(180, 246);
            this.TxtAdminTigerAge.Name = "TxtAdminTigerAge";
            this.TxtAdminTigerAge.Size = new System.Drawing.Size(199, 20);
            this.TxtAdminTigerAge.TabIndex = 20;
            // 
            // LblAdminTigerSpecies
            // 
            this.LblAdminTigerSpecies.AutoSize = true;
            this.LblAdminTigerSpecies.Location = new System.Drawing.Point(126, 275);
            this.LblAdminTigerSpecies.Name = "LblAdminTigerSpecies";
            this.LblAdminTigerSpecies.Size = new System.Drawing.Size(51, 13);
            this.LblAdminTigerSpecies.TabIndex = 23;
            this.LblAdminTigerSpecies.Text = " Underart";
            // 
            // TxtAdminTigerSpecies
            // 
            this.TxtAdminTigerSpecies.Location = new System.Drawing.Point(180, 272);
            this.TxtAdminTigerSpecies.Name = "TxtAdminTigerSpecies";
            this.TxtAdminTigerSpecies.Size = new System.Drawing.Size(199, 20);
            this.TxtAdminTigerSpecies.TabIndex = 22;
            // 
            // BtnAdminLogout
            // 
            this.BtnAdminLogout.Location = new System.Drawing.Point(587, 313);
            this.BtnAdminLogout.Name = "BtnAdminLogout";
            this.BtnAdminLogout.Size = new System.Drawing.Size(125, 28);
            this.BtnAdminLogout.TabIndex = 24;
            this.BtnAdminLogout.Text = "Logga ut!";
            this.BtnAdminLogout.UseVisualStyleBackColor = true;
            this.BtnAdminLogout.Click += new System.EventHandler(this.BtnAdminLogout_Click);
            // 
            // LblAdminMemberId
            // 
            this.LblAdminMemberId.AutoSize = true;
            this.LblAdminMemberId.Location = new System.Drawing.Point(499, 118);
            this.LblAdminMemberId.Name = "LblAdminMemberId";
            this.LblAdminMemberId.Size = new System.Drawing.Size(16, 13);
            this.LblAdminMemberId.TabIndex = 26;
            this.LblAdminMemberId.Text = "Id";
            // 
            // TxtAdminMemberId
            // 
            this.TxtAdminMemberId.Location = new System.Drawing.Point(521, 115);
            this.TxtAdminMemberId.Name = "TxtAdminMemberId";
            this.TxtAdminMemberId.ReadOnly = true;
            this.TxtAdminMemberId.Size = new System.Drawing.Size(191, 20);
            this.TxtAdminMemberId.TabIndex = 25;
            // 
            // BtnAdminAddTiger
            // 
            this.BtnAdminAddTiger.Location = new System.Drawing.Point(180, 313);
            this.BtnAdminAddTiger.Name = "BtnAdminAddTiger";
            this.BtnAdminAddTiger.Size = new System.Drawing.Size(125, 28);
            this.BtnAdminAddTiger.TabIndex = 27;
            this.BtnAdminAddTiger.Text = "Lägg till tiger";
            this.BtnAdminAddTiger.UseVisualStyleBackColor = true;
            this.BtnAdminAddTiger.Click += new System.EventHandler(this.BtnAdminAddTiger_Click);
            // 
            // BtnAdminAddMember
            // 
            this.BtnAdminAddMember.Location = new System.Drawing.Point(180, 167);
            this.BtnAdminAddMember.Name = "BtnAdminAddMember";
            this.BtnAdminAddMember.Size = new System.Drawing.Size(125, 28);
            this.BtnAdminAddMember.TabIndex = 28;
            this.BtnAdminAddMember.Text = "Lägg till medlem";
            this.BtnAdminAddMember.UseVisualStyleBackColor = true;
            this.BtnAdminAddMember.Click += new System.EventHandler(this.BtnAdminAddMember_Click);
            // 
            // BtnAdminEditMember
            // 
            this.BtnAdminEditMember.Location = new System.Drawing.Point(311, 167);
            this.BtnAdminEditMember.Name = "BtnAdminEditMember";
            this.BtnAdminEditMember.Size = new System.Drawing.Size(125, 28);
            this.BtnAdminEditMember.TabIndex = 29;
            this.BtnAdminEditMember.Text = "Ändra medlemsinfo";
            this.BtnAdminEditMember.UseVisualStyleBackColor = true;
            this.BtnAdminEditMember.Click += new System.EventHandler(this.BtnAdminEditMember_Click);
            // 
            // BtnAdminEditTiger
            // 
            this.BtnAdminEditTiger.Location = new System.Drawing.Point(311, 313);
            this.BtnAdminEditTiger.Name = "BtnAdminEditTiger";
            this.BtnAdminEditTiger.Size = new System.Drawing.Size(125, 28);
            this.BtnAdminEditTiger.TabIndex = 30;
            this.BtnAdminEditTiger.Text = "Ändra tigerinfo";
            this.BtnAdminEditTiger.UseVisualStyleBackColor = true;
            this.BtnAdminEditTiger.Click += new System.EventHandler(this.BtnAdminEditTiger_Click);
            // 
            // BtnAdminRemoveMember
            // 
            this.BtnAdminRemoveMember.Location = new System.Drawing.Point(442, 167);
            this.BtnAdminRemoveMember.Name = "BtnAdminRemoveMember";
            this.BtnAdminRemoveMember.Size = new System.Drawing.Size(125, 28);
            this.BtnAdminRemoveMember.TabIndex = 31;
            this.BtnAdminRemoveMember.Text = "Ta bort användare";
            this.BtnAdminRemoveMember.UseVisualStyleBackColor = true;
            this.BtnAdminRemoveMember.Click += new System.EventHandler(this.BtnAdminRemoveMember_Click);
            // 
            // BtnAdminRemoveTiger
            // 
            this.BtnAdminRemoveTiger.Location = new System.Drawing.Point(442, 313);
            this.BtnAdminRemoveTiger.Name = "BtnAdminRemoveTiger";
            this.BtnAdminRemoveTiger.Size = new System.Drawing.Size(125, 28);
            this.BtnAdminRemoveTiger.TabIndex = 32;
            this.BtnAdminRemoveTiger.Text = "Ta bort tiger";
            this.BtnAdminRemoveTiger.UseVisualStyleBackColor = true;
            this.BtnAdminRemoveTiger.Click += new System.EventHandler(this.BtnAdminRemoveTiger_Click);
            // 
            // WikiLink
            // 
            this.WikiLink.AutoSize = true;
            this.WikiLink.LinkColor = System.Drawing.Color.Black;
            this.WikiLink.Location = new System.Drawing.Point(12, 368);
            this.WikiLink.Name = "WikiLink";
            this.WikiLink.Size = new System.Drawing.Size(123, 13);
            this.WikiLink.TabIndex = 33;
            this.WikiLink.TabStop = true;
            this.WikiLink.Text = "Lär dig mer om tigrar här!";
            this.WikiLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WikiLink_LinkClicked);
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 390);
            this.Controls.Add(this.WikiLink);
            this.Controls.Add(this.BtnAdminRemoveTiger);
            this.Controls.Add(this.BtnAdminRemoveMember);
            this.Controls.Add(this.BtnAdminEditTiger);
            this.Controls.Add(this.BtnAdminEditMember);
            this.Controls.Add(this.BtnAdminAddMember);
            this.Controls.Add(this.BtnAdminAddTiger);
            this.Controls.Add(this.LblAdminMemberId);
            this.Controls.Add(this.TxtAdminMemberId);
            this.Controls.Add(this.BtnAdminLogout);
            this.Controls.Add(this.LblAdminTigerSpecies);
            this.Controls.Add(this.TxtAdminTigerSpecies);
            this.Controls.Add(this.LblAdminTigerAge);
            this.Controls.Add(this.TxtAdminTigerAge);
            this.Controls.Add(this.LblAdminTigerName);
            this.Controls.Add(this.TxtAdminTigerName);
            this.Controls.Add(this.LblAdminMemberPass);
            this.Controls.Add(this.TxtAdminMemberPass);
            this.Controls.Add(this.LblAdminMemberUserName);
            this.Controls.Add(this.TxtAdminMemberUserName);
            this.Controls.Add(this.LblAdminMemberEmail);
            this.Controls.Add(this.TxtAdminMemberEmail);
            this.Controls.Add(this.LblAdminMemberAdress);
            this.Controls.Add(this.TxtAdminMemberAddress);
            this.Controls.Add(this.LblAdminMemberLastName);
            this.Controls.Add(this.TxtAdminMemberLastName);
            this.Controls.Add(this.LblAdminMemberFirstName);
            this.Controls.Add(this.TxtAdminMemberFirstName);
            this.Controls.Add(this.LblAdminTigers);
            this.Controls.Add(this.LblAdminMembers);
            this.Controls.Add(this.LstAdminTigers);
            this.Controls.Add(this.LstAdminMembers);
            this.Controls.Add(this.LblAdminTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminControl";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrationspanelen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminControl_FormClosed);
            this.Load += new System.EventHandler(this.AdminControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblAdminTitle;
        private System.Windows.Forms.ListBox LstAdminTigers;
        private System.Windows.Forms.Label LblAdminMembers;
        private System.Windows.Forms.Label LblAdminTigers;
        private System.Windows.Forms.TextBox TxtAdminMemberFirstName;
        private System.Windows.Forms.Label LblAdminMemberFirstName;
        private System.Windows.Forms.Label LblAdminMemberLastName;
        private System.Windows.Forms.TextBox TxtAdminMemberLastName;
        private System.Windows.Forms.Label LblAdminMemberAdress;
        private System.Windows.Forms.TextBox TxtAdminMemberAddress;
        private System.Windows.Forms.Label LblAdminMemberEmail;
        private System.Windows.Forms.TextBox TxtAdminMemberEmail;
        private System.Windows.Forms.Label LblAdminMemberUserName;
        private System.Windows.Forms.TextBox TxtAdminMemberUserName;
        private System.Windows.Forms.Label LblAdminMemberPass;
        private System.Windows.Forms.TextBox TxtAdminMemberPass;
        private System.Windows.Forms.Label LblAdminTigerName;
        private System.Windows.Forms.TextBox TxtAdminTigerName;
        private System.Windows.Forms.Label LblAdminTigerAge;
        private System.Windows.Forms.TextBox TxtAdminTigerAge;
        private System.Windows.Forms.Label LblAdminTigerSpecies;
        private System.Windows.Forms.TextBox TxtAdminTigerSpecies;
        private System.Windows.Forms.Button BtnAdminLogout;
        private System.Windows.Forms.Label LblAdminMemberId;
        private System.Windows.Forms.TextBox TxtAdminMemberId;
        private System.Windows.Forms.Button BtnAdminAddTiger;
        private System.Windows.Forms.Button BtnAdminAddMember;
        private System.Windows.Forms.Button BtnAdminEditMember;
        private System.Windows.Forms.Button BtnAdminEditTiger;
        public System.Windows.Forms.ListBox LstAdminMembers;
        private System.Windows.Forms.Button BtnAdminRemoveMember;
        private System.Windows.Forms.Button BtnAdminRemoveTiger;
        private System.Windows.Forms.LinkLabel WikiLink;
    }
}