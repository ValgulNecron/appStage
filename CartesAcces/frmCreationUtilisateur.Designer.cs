using System.ComponentModel;

namespace CartesAcces
{
    partial class frmCreationUtilisateur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.gbTypeUser = new System.Windows.Forms.GroupBox();
            this.rdUser = new System.Windows.Forms.RadioButton();
            this.rdAdmin = new System.Windows.Forms.RadioButton();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbMdp = new System.Windows.Forms.TextBox();
            this.tbValidMdp = new System.Windows.Forms.TextBox();
            this.lbNomUtilisateur = new System.Windows.Forms.Label();
            this.lblMdpValide = new System.Windows.Forms.Label();
            this.lblMdp = new System.Windows.Forms.Label();
            this.btValid = new System.Windows.Forms.Button();
            this.gbTypeUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTypeUser
            // 
            this.gbTypeUser.Controls.Add(this.rdUser);
            this.gbTypeUser.Controls.Add(this.rdAdmin);
            this.gbTypeUser.Location = new System.Drawing.Point(20, 17);
            this.gbTypeUser.Name = "gbTypeUser";
            this.gbTypeUser.Size = new System.Drawing.Size(262, 187);
            this.gbTypeUser.TabIndex = 0;
            this.gbTypeUser.TabStop = false;
            this.gbTypeUser.Text = "Type utilisateur";
            // 
            // rdUser
            // 
            this.rdUser.Checked = true;
            this.rdUser.Location = new System.Drawing.Point(32, 120);
            this.rdUser.Name = "rdUser";
            this.rdUser.Size = new System.Drawing.Size(180, 18);
            this.rdUser.TabIndex = 1;
            this.rdUser.TabStop = true;
            this.rdUser.Text = "utilisateur";
            this.rdUser.UseVisualStyleBackColor = true;
            // 
            // rdAdmin
            // 
            this.rdAdmin.Location = new System.Drawing.Point(4, 19);
            this.rdAdmin.Name = "rdAdmin";
            this.rdAdmin.Size = new System.Drawing.Size(208, 63);
            this.rdAdmin.TabIndex = 0;
            this.rdAdmin.Text = "admin";
            this.rdAdmin.UseVisualStyleBackColor = true;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(35, 283);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(173, 20);
            this.tbUser.TabIndex = 1;
            // 
            // tbMdp
            // 
            this.tbMdp.Location = new System.Drawing.Point(299, 265);
            this.tbMdp.Name = "tbMdp";
            this.tbMdp.Size = new System.Drawing.Size(131, 20);
            this.tbMdp.TabIndex = 2;
            // 
            // tbValidMdp
            // 
            this.tbValidMdp.Location = new System.Drawing.Point(485, 259);
            this.tbValidMdp.Name = "tbValidMdp";
            this.tbValidMdp.Size = new System.Drawing.Size(175, 20);
            this.tbValidMdp.TabIndex = 3;
            // 
            // lbNomUtilisateur
            // 
            this.lbNomUtilisateur.Location = new System.Drawing.Point(52, 238);
            this.lbNomUtilisateur.Name = "lbNomUtilisateur";
            this.lbNomUtilisateur.Size = new System.Drawing.Size(138, 11);
            this.lbNomUtilisateur.TabIndex = 4;
            this.lbNomUtilisateur.Text = "Nom utilisateur";
            // 
            // lblMdpValide
            // 
            this.lblMdpValide.Location = new System.Drawing.Point(494, 228);
            this.lblMdpValide.Name = "lblMdpValide";
            this.lblMdpValide.Size = new System.Drawing.Size(138, 11);
            this.lblMdpValide.TabIndex = 5;
            this.lblMdpValide.Text = "Valider mot de passe";
            // 
            // lblMdp
            // 
            this.lblMdp.Location = new System.Drawing.Point(292, 251);
            this.lblMdp.Name = "lblMdp";
            this.lblMdp.Size = new System.Drawing.Size(138, 11);
            this.lblMdp.TabIndex = 6;
            this.lblMdp.Text = "Mot de passe";
            // 
            // btValid
            // 
            this.btValid.Location = new System.Drawing.Point(227, 322);
            this.btValid.Name = "btValid";
            this.btValid.Size = new System.Drawing.Size(279, 94);
            this.btValid.TabIndex = 7;
            this.btValid.Text = "valider";
            this.btValid.UseVisualStyleBackColor = true;
            this.btValid.Click += new System.EventHandler(this.btValid_Click);
            // 
            // frmCreationUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btValid);
            this.Controls.Add(this.lblMdp);
            this.Controls.Add(this.lblMdpValide);
            this.Controls.Add(this.lbNomUtilisateur);
            this.Controls.Add(this.tbValidMdp);
            this.Controls.Add(this.tbMdp);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.gbTypeUser);
            this.Name = "frmCreationUtilisateur";
            this.Text = "frmCreationUtilisateur";
            this.gbTypeUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btValid;

        private System.Windows.Forms.TextBox tbUser;

        private System.Windows.Forms.TextBox tbMdp;

        private System.Windows.Forms.TextBox tbValidMdp;

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lbNomUtilisateur;
        private System.Windows.Forms.Label lblMdpValide;
        private System.Windows.Forms.Label lblMdp;

        private System.Windows.Forms.RadioButton rdAdmin;
        private System.Windows.Forms.RadioButton rdUser;

        private System.Windows.Forms.GroupBox gbTypeUser;

        #endregion
    }
}