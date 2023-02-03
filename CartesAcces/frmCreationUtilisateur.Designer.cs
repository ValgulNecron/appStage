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
            this.gbTypeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.gbTypeUser.Location = new System.Drawing.Point(236, 23);
            this.gbTypeUser.Name = "gbTypeUser";
            this.gbTypeUser.Size = new System.Drawing.Size(303, 58);
            this.gbTypeUser.TabIndex = 0;
            this.gbTypeUser.TabStop = false;
            this.gbTypeUser.Text = "TYPE D\'UTILISATEUR";
            // 
            // rdUser
            // 
            this.rdUser.Checked = true;
            this.rdUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.rdUser.Location = new System.Drawing.Point(193, 25);
            this.rdUser.Name = "rdUser";
            this.rdUser.Size = new System.Drawing.Size(88, 18);
            this.rdUser.TabIndex = 1;
            this.rdUser.TabStop = true;
            this.rdUser.Text = "utilisateur";
            this.rdUser.UseVisualStyleBackColor = true;
            // 
            // rdAdmin
            // 
            this.rdAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.rdAdmin.Location = new System.Drawing.Point(20, 19);
            this.rdAdmin.Name = "rdAdmin";
            this.rdAdmin.Size = new System.Drawing.Size(97, 30);
            this.rdAdmin.TabIndex = 0;
            this.rdAdmin.Text = "admin";
            this.rdAdmin.UseVisualStyleBackColor = true;
            // 
            // tbUser
            // 
            this.tbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tbUser.Location = new System.Drawing.Point(236, 124);
            this.tbUser.MaximumSize = new System.Drawing.Size(180, 22);
            this.tbUser.MinimumSize = new System.Drawing.Size(180, 22);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(180, 22);
            this.tbUser.TabIndex = 1;
            // 
            // tbMdp
            // 
            this.tbMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tbMdp.Location = new System.Drawing.Point(236, 188);
            this.tbMdp.MaximumSize = new System.Drawing.Size(180, 22);
            this.tbMdp.MinimumSize = new System.Drawing.Size(180, 22);
            this.tbMdp.Name = "tbMdp";
            this.tbMdp.Size = new System.Drawing.Size(180, 22);
            this.tbMdp.TabIndex = 2;
            // 
            // tbValidMdp
            // 
            this.tbValidMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tbValidMdp.Location = new System.Drawing.Point(236, 256);
            this.tbValidMdp.MaximumSize = new System.Drawing.Size(180, 22);
            this.tbValidMdp.MinimumSize = new System.Drawing.Size(180, 22);
            this.tbValidMdp.Name = "tbValidMdp";
            this.tbValidMdp.Size = new System.Drawing.Size(180, 22);
            this.tbValidMdp.TabIndex = 3;
            // 
            // lbNomUtilisateur
            // 
            this.lbNomUtilisateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lbNomUtilisateur.Location = new System.Drawing.Point(233, 101);
            this.lbNomUtilisateur.Name = "lbNomUtilisateur";
            this.lbNomUtilisateur.Size = new System.Drawing.Size(138, 20);
            this.lbNomUtilisateur.TabIndex = 4;
            this.lbNomUtilisateur.Text = "Nom utilisateur";
            // 
            // lblMdpValide
            // 
            this.lblMdpValide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblMdpValide.Location = new System.Drawing.Point(233, 233);
            this.lblMdpValide.Name = "lblMdpValide";
            this.lblMdpValide.Size = new System.Drawing.Size(138, 20);
            this.lblMdpValide.TabIndex = 5;
            this.lblMdpValide.Text = "Valider mot de passe";
            // 
            // lblMdp
            // 
            this.lblMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblMdp.Location = new System.Drawing.Point(233, 165);
            this.lblMdp.Name = "lblMdp";
            this.lblMdp.Size = new System.Drawing.Size(138, 20);
            this.lblMdp.TabIndex = 6;
            this.lblMdp.Text = "Mot de passe";
            // 
            // btValid
            // 
            this.btValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btValid.Location = new System.Drawing.Point(236, 300);
            this.btValid.MaximumSize = new System.Drawing.Size(303, 45);
            this.btValid.MinimumSize = new System.Drawing.Size(303, 45);
            this.btValid.Name = "btValid";
            this.btValid.Size = new System.Drawing.Size(303, 45);
            this.btValid.TabIndex = 7;
            this.btValid.Text = "Valider";
            this.btValid.UseVisualStyleBackColor = true;
            this.btValid.Click += new System.EventHandler(this.btValid_Click);
            // 
            // frmCreationUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 362);
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
            this.Load += new System.EventHandler(this.frmCreationUtilisateur_Load);
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