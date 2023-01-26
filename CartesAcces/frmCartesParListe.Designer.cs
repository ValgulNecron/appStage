using System.ComponentModel;

namespace CartesAcces
{
    partial class frmCartesParListe
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
            this.Eleves = new System.Windows.Forms.ListBox();
            this.Impression = new System.Windows.Forms.ListBox();
            this.btnAjout = new System.Windows.Forms.Button();
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Eleves
            // 
            this.Eleves.FormattingEnabled = true;
            this.Eleves.Location = new System.Drawing.Point(12, 77);
            this.Eleves.Name = "Eleves";
            this.Eleves.Size = new System.Drawing.Size(293, 329);
            this.Eleves.TabIndex = 0;
            // 
            // Impression
            // 
            this.Impression.FormattingEnabled = true;
            this.Impression.Location = new System.Drawing.Point(502, 77);
            this.Impression.Name = "Impression";
            this.Impression.Size = new System.Drawing.Size(286, 329);
            this.Impression.TabIndex = 1;
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(363, 191);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(75, 23);
            this.btnAjout.TabIndex = 2;
            this.btnAjout.Text = "Ajouter";
            this.btnAjout.UseVisualStyleBackColor = true;
            // 
            // btnRetirer
            // 
            this.btnRetirer.Location = new System.Drawing.Point(363, 269);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(75, 23);
            this.btnRetirer.TabIndex = 3;
            this.btnRetirer.Text = "Retirer";
            this.btnRetirer.UseVisualStyleBackColor = true;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(713, 415);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 4;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre d\'élèves :";
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(103, 9);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(100, 23);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "none";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rechercher : ";
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(85, 48);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(220, 20);
            this.txtRecherche.TabIndex = 8;
            // 
            // frmCartesParListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnRetirer);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.Impression);
            this.Controls.Add(this.Eleves);
            this.Name = "frmCartesParListe";
            this.Text = "frmCartesParListe";
            this.Load += new System.EventHandler(this.frmCartesParListe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox Eleves;
        private System.Windows.Forms.ListBox Impression;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnRetirer;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRecherche;

        #endregion
    }
}