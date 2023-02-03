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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quelle section est concernée par ce fichier ?";
            // 
            // gpbSelectSection
            // 
            this.gpbSelectSection.Controls.Add(this.rdb3eme);
            this.gpbSelectSection.Controls.Add(this.rdb4eme);
            this.gpbSelectSection.Controls.Add(this.rdb5eme);
            this.gpbSelectSection.Controls.Add(this.rdb6eme);
            this.gpbSelectSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbSelectSection.Location = new System.Drawing.Point(44, 57);
            this.gpbSelectSection.Name = "gpbSelectSection";
            this.gpbSelectSection.Size = new System.Drawing.Size(150, 171);
            this.gpbSelectSection.TabIndex = 1;
            this.gpbSelectSection.TabStop = false;
            this.gpbSelectSection.Text = "Section";
            // 
            // rdb3eme
            // 
            this.rdb3eme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb3eme.Location = new System.Drawing.Point(45, 123);
            this.rdb3eme.Name = "rdb3eme";
            this.rdb3eme.Size = new System.Drawing.Size(61, 24);
            this.rdb3eme.TabIndex = 3;
            this.rdb3eme.TabStop = true;
            this.rdb3eme.Text = "3eme";
            this.rdb3eme.UseVisualStyleBackColor = true;
            // 
            // rdb4eme
            // 
            this.rdb4eme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb4eme.Location = new System.Drawing.Point(45, 93);
            this.rdb4eme.Name = "rdb4eme";
            this.rdb4eme.Size = new System.Drawing.Size(61, 24);
            this.rdb4eme.TabIndex = 2;
            this.rdb4eme.TabStop = true;
            this.rdb4eme.Text = "4eme";
            this.rdb4eme.UseVisualStyleBackColor = true;
            // 
            // rdb5eme
            // 
            this.rdb5eme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb5eme.Location = new System.Drawing.Point(45, 63);
            this.rdb5eme.Name = "rdb5eme";
            this.rdb5eme.Size = new System.Drawing.Size(61, 24);
            this.rdb5eme.TabIndex = 1;
            this.rdb5eme.TabStop = true;
            this.rdb5eme.Text = "5eme";
            this.rdb5eme.UseVisualStyleBackColor = true;
            // 
            // rdb6eme
            // 
            this.rdb6eme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb6eme.Location = new System.Drawing.Point(45, 33);
            this.rdb6eme.Name = "rdb6eme";
            this.rdb6eme.Size = new System.Drawing.Size(61, 24);
            this.rdb6eme.TabIndex = 0;
            this.rdb6eme.TabStop = true;
            this.rdb6eme.Text = "6eme";
            this.rdb6eme.UseVisualStyleBackColor = true;
            // 
            // btnValider
            // 
            this.btnValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Location = new System.Drawing.Point(89, 246);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(105, 23);
            this.btnValider.TabIndex = 2;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // frmSelectNiveau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 300);
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