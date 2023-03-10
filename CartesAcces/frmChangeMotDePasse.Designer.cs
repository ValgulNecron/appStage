using System.ComponentModel;

namespace CartesAcces
{
    partial class FrmChangeMotDePasse
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
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Confirmer le nouveau mot de passe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nouveau mot de passe";
            // 
            // nouveauMdpValid
            // 
            this.nouveauMdpValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nouveauMdpValid.Location = new System.Drawing.Point(12, 206);
            this.nouveauMdpValid.MaximumSize = new System.Drawing.Size(200, 30);
            this.nouveauMdpValid.MinimumSize = new System.Drawing.Size(200, 30);
            this.nouveauMdpValid.Name = "nouveauMdpValid";
            this.nouveauMdpValid.Size = new System.Drawing.Size(200, 30);
            this.nouveauMdpValid.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Ancien mot de passe";
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Location = new System.Drawing.Point(12, 266);
            this.btnEnregistrer.MaximumSize = new System.Drawing.Size(200, 30);
            this.btnEnregistrer.MinimumSize = new System.Drawing.Size(200, 30);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(200, 30);
            this.btnEnregistrer.TabIndex = 19;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // nouveauMdp
            // 
            this.nouveauMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nouveauMdp.Location = new System.Drawing.Point(12, 138);
            this.nouveauMdp.MaximumSize = new System.Drawing.Size(200, 30);
            this.nouveauMdp.MinimumSize = new System.Drawing.Size(200, 30);
            this.nouveauMdp.Name = "nouveauMdp";
            this.nouveauMdp.Size = new System.Drawing.Size(200, 30);
            this.nouveauMdp.TabIndex = 18;
            // 
            // ancienMdp
            // 
            this.ancienMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ancienMdp.Location = new System.Drawing.Point(12, 36);
            this.ancienMdp.MaximumSize = new System.Drawing.Size(200, 30);
            this.ancienMdp.MinimumSize = new System.Drawing.Size(200, 30);
            this.ancienMdp.Name = "ancienMdp";
            this.ancienMdp.Size = new System.Drawing.Size(200, 30);
            this.ancienMdp.TabIndex = 17;
            // 
            // frmChangeMotDePasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 341);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nouveauMdpValid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.nouveauMdp);
            this.Controls.Add(this.ancienMdp);
            this.Name = "FrmChangeMotDePasse";
            this.Text = "Changer le mot de passe";
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