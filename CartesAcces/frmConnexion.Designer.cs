﻿using System.ComponentModel;

namespace CartesAcces
{
    partial class frmConnexion
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnChiffre = new System.Windows.Forms.Button();
            this.btnDechiffre = new System.Windows.Forms.Button();
            this.lblMdp = new System.Windows.Forms.Label();
            this.lblIdent = new System.Windows.Forms.Label();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.txtIdentifiant = new System.Windows.Forms.TextBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(229, 488);
            this.maskedTextBox1.MinimumSize = new System.Drawing.Size(175, 30);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(175, 30);
            this.maskedTextBox1.TabIndex = 5;
            this.maskedTextBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 541);
            this.button1.MinimumSize = new System.Drawing.Size(175, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Connexion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnChiffre
            // 
            this.btnChiffre.Location = new System.Drawing.Point(12, 541);
            this.btnChiffre.MinimumSize = new System.Drawing.Size(175, 30);
            this.btnChiffre.Name = "btnChiffre";
            this.btnChiffre.Size = new System.Drawing.Size(175, 30);
            this.btnChiffre.TabIndex = 7;
            this.btnChiffre.Text = "Chiffrer";
            this.btnChiffre.UseVisualStyleBackColor = true;
            this.btnChiffre.Click += new System.EventHandler(this.btnChiffre_Click);
            // 
            // btnDechiffre
            // 
            this.btnDechiffre.Location = new System.Drawing.Point(12, 488);
            this.btnDechiffre.MinimumSize = new System.Drawing.Size(175, 30);
            this.btnDechiffre.Name = "btnDechiffre";
            this.btnDechiffre.Size = new System.Drawing.Size(175, 30);
            this.btnDechiffre.TabIndex = 8;
            this.btnDechiffre.Text = "Dechiffrer";
            this.btnDechiffre.UseVisualStyleBackColor = true;
            this.btnDechiffre.Click += new System.EventHandler(this.btnDechiffre_Click);
            // 
            // lblMdp
            // 
            this.lblMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMdp.Location = new System.Drawing.Point(459, 298);
            this.lblMdp.Name = "lblMdp";
            this.lblMdp.Size = new System.Drawing.Size(117, 23);
            this.lblMdp.TabIndex = 2;
            this.lblMdp.Text = "MOT DE PASSE :";
            // 
            // lblIdent
            // 
            this.lblIdent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdent.Location = new System.Drawing.Point(476, 248);
            this.lblIdent.Name = "lblIdent";
            this.lblIdent.Size = new System.Drawing.Size(100, 23);
            this.lblIdent.TabIndex = 1;
            this.lblIdent.Text = "IDENTIFIANT :";
            // 
            // btnConnexion
            // 
            this.btnConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnexion.Location = new System.Drawing.Point(586, 339);
            this.btnConnexion.MinimumSize = new System.Drawing.Size(175, 28);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(175, 30);
            this.btnConnexion.TabIndex = 0;
            this.btnConnexion.Text = "S\'IDENTIFIER";
            this.btnConnexion.UseVisualStyleBackColor = true;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // txtIdentifiant
            // 
            this.txtIdentifiant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentifiant.Location = new System.Drawing.Point(586, 243);
            this.txtIdentifiant.MaximumSize = new System.Drawing.Size(175, 28);
            this.txtIdentifiant.MinimumSize = new System.Drawing.Size(175, 28);
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.Size = new System.Drawing.Size(175, 28);
            this.txtIdentifiant.TabIndex = 3;
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotDePasse.Location = new System.Drawing.Point(586, 293);
            this.txtMotDePasse.MaximumSize = new System.Drawing.Size(175, 28);
            this.txtMotDePasse.MinimumSize = new System.Drawing.Size(175, 28);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(175, 28);
            this.txtMotDePasse.TabIndex = 9;
            // 
            // frmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 592);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.txtIdentifiant);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.btnDechiffre);
            this.Controls.Add(this.lblIdent);
            this.Controls.Add(this.lblMdp);
            this.Controls.Add(this.btnChiffre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.maskedTextBox1);
            this.MinimumSize = new System.Drawing.Size(175, 28);
            this.Name = "frmConnexion";
            this.Text = "frmConnexion";
            this.Load += new System.EventHandler(this.frmConnexion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnChiffre;
        private System.Windows.Forms.Button btnDechiffre;

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblMdp;
        private System.Windows.Forms.Label lblIdent;
        private System.Windows.Forms.Button btnConnexion;
        private System.Windows.Forms.TextBox txtIdentifiant;
        private System.Windows.Forms.TextBox txtMotDePasse;
    }
}