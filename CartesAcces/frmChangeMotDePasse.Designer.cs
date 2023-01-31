using System.ComponentModel;

namespace CartesAcces
{
    partial class frmChangeMotDePasse
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nouveauMdpValid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.nouveauMdp = new System.Windows.Forms.TextBox();
            this.ancienMdp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Confirmer le nouveau mot de passe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nouveau mot de passe";
            // 
            // nouveauMdpValid
            // 
            this.nouveauMdpValid.Location = new System.Drawing.Point(187, 109);
            this.nouveauMdpValid.Name = "nouveauMdpValid";
            this.nouveauMdpValid.Size = new System.Drawing.Size(96, 20);
            this.nouveauMdpValid.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Ancien mot de passe";
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(208, 150);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(75, 23);
            this.btnEnregistrer.TabIndex = 19;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // nouveauMdp
            // 
            this.nouveauMdp.Location = new System.Drawing.Point(24, 109);
            this.nouveauMdp.Name = "nouveauMdp";
            this.nouveauMdp.Size = new System.Drawing.Size(100, 20);
            this.nouveauMdp.TabIndex = 18;
            // 
            // ancienMdp
            // 
            this.ancienMdp.Location = new System.Drawing.Point(24, 32);
            this.ancienMdp.Name = "ancienMdp";
            this.ancienMdp.Size = new System.Drawing.Size(100, 20);
            this.ancienMdp.TabIndex = 17;
            // 
            // frmChangeMotDePasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 211);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nouveauMdpValid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.nouveauMdp);
            this.Controls.Add(this.ancienMdp);
            this.Name = "frmChangeMotDePasse";
            this.Text = "frmChangeMotDePasse";
            this.Load += new System.EventHandler(this.frmChangeMotDePasse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nouveauMdpValid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.TextBox nouveauMdp;
        private System.Windows.Forms.TextBox ancienMdp;

        #endregion
    }
}