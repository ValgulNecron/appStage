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
            ((System.ComponentModel.ISupportInitialize)(this.pbEdtClassique)).BeginInit();
            this.SuspendLayout();
            // 
            // pbEdtClassique
            // 
            this.pbEdtClassique.Location = new System.Drawing.Point(12, 12);
            this.pbEdtClassique.Name = "pbEdtClassique";
            this.pbEdtClassique.Size = new System.Drawing.Size(489, 300);
            this.pbEdtClassique.TabIndex = 0;
            this.pbEdtClassique.TabStop = false;
            // 
            // frmRognageEdtClassique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 466);
            this.Controls.Add(this.pbEdtClassique);
            this.Name = "frmRognageEdtClassique";
            this.Text = "frmRognageEdtClassique";
            this.Load += new System.EventHandler(this.frmRognageEdtClassique_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEdtClassique)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pbEdtClassique;

        #endregion
    }
}