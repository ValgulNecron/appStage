using System.ComponentModel;

namespace CartesAcces
{
    partial class FrmMotDePasse
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button1.Location = new System.Drawing.Point(298, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "Valider le mot de passe de chiffrement";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 165);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 26);
            this.textBox1.TabIndex = 1;
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblMotDePasse.Location = new System.Drawing.Point(102, 88);
            this.lblMotDePasse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(291, 74);
            this.lblMotDePasse.TabIndex = 2;
            this.lblMotDePasse.Text = "Veuillez saisir un mot de passe de chiffrement pour continuer :";
            // 
            // FrmMotDePasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 354);
            this.Controls.Add(this.lblMotDePasse);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "FrmMotDePasse";
            this.Text = "frmMotDePasse";
            this.Load += new System.EventHandler(this.FrmMotDePasse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMotDePasse;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}