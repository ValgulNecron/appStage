using System.ComponentModel;

namespace CartesAcces
{
    partial class frmSelectNiveau
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
            this.gpbSelectSection = new System.Windows.Forms.GroupBox();
            this.rdb3eme = new System.Windows.Forms.RadioButton();
            this.rdb4eme = new System.Windows.Forms.RadioButton();
            this.rdb5eme = new System.Windows.Forms.RadioButton();
            this.rdb6eme = new System.Windows.Forms.RadioButton();
            this.btnValider = new System.Windows.Forms.Button();
            this.gpbSelectSection.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quelle section est concernée par ce fichier ?";
            // 
            // gpbSelectSection
            // 
            this.gpbSelectSection.Controls.Add(this.rdb3eme);
            this.gpbSelectSection.Controls.Add(this.rdb4eme);
            this.gpbSelectSection.Controls.Add(this.rdb5eme);
            this.gpbSelectSection.Controls.Add(this.rdb6eme);
            this.gpbSelectSection.Location = new System.Drawing.Point(56, 55);
            this.gpbSelectSection.Name = "gpbSelectSection";
            this.gpbSelectSection.Size = new System.Drawing.Size(133, 156);
            this.gpbSelectSection.TabIndex = 1;
            this.gpbSelectSection.TabStop = false;
            this.gpbSelectSection.Text = "Sections :";
            // 
            // rdb3eme
            // 
            this.rdb3eme.Location = new System.Drawing.Point(22, 113);
            this.rdb3eme.Name = "rdb3eme";
            this.rdb3eme.Size = new System.Drawing.Size(104, 24);
            this.rdb3eme.TabIndex = 3;
            this.rdb3eme.TabStop = true;
            this.rdb3eme.Text = "3eme";
            this.rdb3eme.UseVisualStyleBackColor = true;
            // 
            // rdb4eme
            // 
            this.rdb4eme.Location = new System.Drawing.Point(22, 83);
            this.rdb4eme.Name = "rdb4eme";
            this.rdb4eme.Size = new System.Drawing.Size(104, 24);
            this.rdb4eme.TabIndex = 2;
            this.rdb4eme.TabStop = true;
            this.rdb4eme.Text = "4eme";
            this.rdb4eme.UseVisualStyleBackColor = true;
            // 
            // rdb5eme
            // 
            this.rdb5eme.Location = new System.Drawing.Point(22, 53);
            this.rdb5eme.Name = "rdb5eme";
            this.rdb5eme.Size = new System.Drawing.Size(104, 24);
            this.rdb5eme.TabIndex = 1;
            this.rdb5eme.TabStop = true;
            this.rdb5eme.Text = "5eme";
            this.rdb5eme.UseVisualStyleBackColor = true;
            // 
            // rdb6eme
            // 
            this.rdb6eme.Location = new System.Drawing.Point(22, 23);
            this.rdb6eme.Name = "rdb6eme";
            this.rdb6eme.Size = new System.Drawing.Size(104, 24);
            this.rdb6eme.TabIndex = 0;
            this.rdb6eme.TabStop = true;
            this.rdb6eme.Text = "6eme";
            this.rdb6eme.UseVisualStyleBackColor = true;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(87, 217);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 2;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // frmSelectNiveau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 258);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.gpbSelectSection);
            this.Controls.Add(this.label1);
            this.Name = "frmSelectNiveau";
            this.Text = "frmSelectNiveau";
            this.gpbSelectSection.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnValider;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpbSelectSection;
        private System.Windows.Forms.RadioButton rdb6eme;
        private System.Windows.Forms.RadioButton rdb5eme;
        private System.Windows.Forms.RadioButton rdb4eme;
        private System.Windows.Forms.RadioButton rdb3eme;

        #endregion
    }
}