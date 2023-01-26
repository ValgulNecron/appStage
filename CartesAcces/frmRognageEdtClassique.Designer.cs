using System.ComponentModel;

namespace CartesAcces
{
    partial class frmRognageEdtClassique
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
            this.pbEdtClassique = new System.Windows.Forms.PictureBox();
            this.btnRogner = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdtClassique)).BeginInit();
            this.SuspendLayout();
            // 
            // pbEdtClassique
            // 
            this.pbEdtClassique.Location = new System.Drawing.Point(12, 12);
            this.pbEdtClassique.Name = "pbEdtClassique";
            this.pbEdtClassique.Size = new System.Drawing.Size(540, 354);
            this.pbEdtClassique.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEdtClassique.TabIndex = 0;
            this.pbEdtClassique.TabStop = false;
            this.pbEdtClassique.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbEdtClassique_MouseDown);
            this.pbEdtClassique.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbEdtClassique_MouseMove);
            this.pbEdtClassique.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbEdtClassique_MouseUp);
            // 
            // btnRogner
            // 
            this.btnRogner.Location = new System.Drawing.Point(12, 387);
            this.btnRogner.Name = "btnRogner";
            this.btnRogner.Size = new System.Drawing.Size(75, 23);
            this.btnRogner.TabIndex = 1;
            this.btnRogner.Text = "Rogner";
            this.btnRogner.UseVisualStyleBackColor = true;
            this.btnRogner.Click += new System.EventHandler(this.btnRogner_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(229, 387);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 2;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(477, 387);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 3;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // frmRognageEdtClassique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 432);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnRogner);
            this.Controls.Add(this.pbEdtClassique);
            this.Name = "frmRognageEdtClassique";
            this.Text = "frmRognageEdtClassique";
            this.Load += new System.EventHandler(this.frmRognageEdtClassique_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEdtClassique)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnRogner;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnValider;

        private System.Windows.Forms.PictureBox pbEdtClassique;

        #endregion
    }
}