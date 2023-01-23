using System.ComponentModel;

namespace CartesAcces
{
    partial class frmListeEleve
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.Liste = new System.Windows.Forms.ListBox();
            this.txtRechercher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombres d\'élèves actuellement enregistré : ";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(234, 18);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "none";
            // 
            // Liste
            // 
            this.Liste.FormattingEnabled = true;
            this.Liste.Location = new System.Drawing.Point(27, 70);
            this.Liste.Name = "Liste";
            this.Liste.Size = new System.Drawing.Size(343, 355);
            this.Liste.TabIndex = 2;
            // 
            // txtRechercher
            // 
            this.txtRechercher.Location = new System.Drawing.Point(102, 44);
            this.txtRechercher.Name = "txtRechercher";
            this.txtRechercher.Size = new System.Drawing.Size(268, 20);
            this.txtRechercher.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(27, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rechercher : ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // frmListeEleve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRechercher);
            this.Controls.Add(this.Liste);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Name = "frmListeEleve";
            this.Text = "frmListeEleve";
            this.Load += new System.EventHandler(this.frmListeEleve_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ListBox Liste;
        private System.Windows.Forms.TextBox txtRechercher;
        private System.Windows.Forms.Label label2;

        #endregion
    }
}