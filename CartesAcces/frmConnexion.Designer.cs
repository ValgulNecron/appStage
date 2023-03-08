using System.ComponentModel;

namespace CartesAcces
{
    partial class FrmConnexion
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
            this.lblMdp = new System.Windows.Forms.Label();
            this.lblIdent = new System.Windows.Forms.Label();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.txtIdentifiant = new System.Windows.Forms.TextBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.btnRetry = new System.Windows.Forms.Button();
            this.lbConnection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMdp
            // 
            this.lblMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblMdp.Location = new System.Drawing.Point(688, 458);
            this.lblMdp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMdp.Name = "lblMdp";
            this.lblMdp.Size = new System.Drawing.Size(176, 35);
            this.lblMdp.TabIndex = 2;
            this.lblMdp.Text = "MOT DE PASSE :";
            // 
            // lblIdent
            // 
            this.lblIdent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblIdent.Location = new System.Drawing.Point(714, 382);
            this.lblIdent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdent.Name = "lblIdent";
            this.lblIdent.Size = new System.Drawing.Size(150, 35);
            this.lblIdent.TabIndex = 1;
            this.lblIdent.Text = "IDENTIFIANT :";
            // 
            // btnConnexion
            // 
            this.btnConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnConnexion.Location = new System.Drawing.Point(879, 522);
            this.btnConnexion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnexion.MinimumSize = new System.Drawing.Size(262, 43);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(262, 46);
            this.btnConnexion.TabIndex = 3;
            this.btnConnexion.Text = "S\'IDENTIFIER";
            this.btnConnexion.UseVisualStyleBackColor = true;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // txtIdentifiant
            // 
            this.txtIdentifiant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtIdentifiant.Location = new System.Drawing.Point(879, 374);
            this.txtIdentifiant.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdentifiant.MaximumSize = new System.Drawing.Size(260, 28);
            this.txtIdentifiant.MinimumSize = new System.Drawing.Size(260, 28);
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.Size = new System.Drawing.Size(260, 33);
            this.txtIdentifiant.TabIndex = 0;
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtMotDePasse.Location = new System.Drawing.Point(879, 451);
            this.txtMotDePasse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMotDePasse.MaximumSize = new System.Drawing.Size(260, 28);
            this.txtMotDePasse.MinimumSize = new System.Drawing.Size(260, 28);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(260, 33);
            this.txtMotDePasse.TabIndex = 1;
            this.txtMotDePasse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMotDePasse_KeyDown);
            // 
            // btnRetry
            // 
            this.btnRetry.Location = new System.Drawing.Point(1320, 75);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(304, 40);
            this.btnRetry.TabIndex = 4;
            this.btnRetry.Text = "réassayer la connection";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // lbConnection
            // 
            this.lbConnection.Location = new System.Drawing.Point(1320, 15);
            this.lbConnection.Name = "lbConnection";
            this.lbConnection.Size = new System.Drawing.Size(295, 57);
            this.lbConnection.TabIndex = 5;
            this.lbConnection.Text = "Est connecter";
            // 
            // FrmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1636, 911);
            this.Controls.Add(this.lbConnection);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.txtIdentifiant);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.lblIdent);
            this.Controls.Add(this.lblMdp);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(252, 56);
            this.Name = "FrmConnexion";
            this.Text = "frmConnexion";
            this.Load += new System.EventHandler(this.frmConnexion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Label lbConnection;

        #endregion

        private System.Windows.Forms.Label lblMdp;
        private System.Windows.Forms.Label lblIdent;
        private System.Windows.Forms.Button btnConnexion;
        private System.Windows.Forms.TextBox txtIdentifiant;
        private System.Windows.Forms.TextBox txtMotDePasse;
    }
}