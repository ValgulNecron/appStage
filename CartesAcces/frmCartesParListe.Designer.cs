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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Ceme = new System.Windows.Forms.RadioButton();
            this.tout = new System.Windows.Forms.RadioButton();
            this.Teme = new System.Windows.Forms.RadioButton();
            this.Qeme = new System.Windows.Forms.RadioButton();
            this.Seme = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Eleves
            // 
            this.Eleves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Eleves.FormattingEnabled = true;
            this.Eleves.ItemHeight = 16;
            this.Eleves.Location = new System.Drawing.Point(23, 123);
            this.Eleves.MaximumSize = new System.Drawing.Size(350, 500);
            this.Eleves.MinimumSize = new System.Drawing.Size(350, 500);
            this.Eleves.Name = "Eleves";
            this.Eleves.Size = new System.Drawing.Size(350, 500);
            this.Eleves.TabIndex = 0;
            // 
            // Impression
            // 
            this.Impression.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Impression.FormattingEnabled = true;
            this.Impression.ItemHeight = 16;
            this.Impression.Location = new System.Drawing.Point(615, 123);
            this.Impression.MaximumSize = new System.Drawing.Size(350, 500);
            this.Impression.MinimumSize = new System.Drawing.Size(350, 500);
            this.Impression.Name = "Impression";
            this.Impression.Size = new System.Drawing.Size(350, 500);
            this.Impression.TabIndex = 1;
            // 
            // btnAjout
            // 
            this.btnAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnAjout.Location = new System.Drawing.Point(397, 307);
            this.btnAjout.MaximumSize = new System.Drawing.Size(180, 45);
            this.btnAjout.MinimumSize = new System.Drawing.Size(180, 45);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(180, 45);
            this.btnAjout.TabIndex = 2;
            this.btnAjout.Text = "Ajouter =>";
            this.btnAjout.UseVisualStyleBackColor = true;
            // 
            // btnRetirer
            // 
            this.btnRetirer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnRetirer.Location = new System.Drawing.Point(397, 385);
            this.btnRetirer.MaximumSize = new System.Drawing.Size(180, 45);
            this.btnRetirer.MinimumSize = new System.Drawing.Size(180, 45);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(180, 45);
            this.btnRetirer.TabIndex = 3;
            this.btnRetirer.Text = "<= Retirer";
            this.btnRetirer.UseVisualStyleBackColor = true;
            // 
            // btnValider
            // 
            this.btnValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnValider.Location = new System.Drawing.Point(785, 641);
            this.btnValider.MaximumSize = new System.Drawing.Size(180, 45);
            this.btnValider.MinimumSize = new System.Drawing.Size(180, 45);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(180, 45);
            this.btnValider.TabIndex = 4;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre d\'élèves :";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblCount.Location = new System.Drawing.Point(103, 9);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(100, 23);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "none";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rechercher : ";
            // 
            // txtRecherche
            // 
            this.txtRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtRecherche.Location = new System.Drawing.Point(106, 51);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(259, 22);
            this.txtRecherche.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Ceme);
            this.groupBox1.Controls.Add(this.tout);
            this.groupBox1.Controls.Add(this.Teme);
            this.groupBox1.Controls.Add(this.Qeme);
            this.groupBox1.Controls.Add(this.Seme);
            this.groupBox1.Location = new System.Drawing.Point(383, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 84);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Ceme
            // 
            this.Ceme.Location = new System.Drawing.Point(20, 44);
            this.Ceme.Name = "Ceme";
            this.Ceme.Size = new System.Drawing.Size(94, 22);
            this.Ceme.TabIndex = 4;
            this.Ceme.Text = "5eme";
            this.Ceme.UseVisualStyleBackColor = true;
            // 
            // tout
            // 
            this.tout.Checked = true;
            this.tout.Location = new System.Drawing.Point(232, 44);
            this.tout.Name = "tout";
            this.tout.Size = new System.Drawing.Size(94, 22);
            this.tout.TabIndex = 3;
            this.tout.TabStop = true;
            this.tout.Text = "tout";
            this.tout.UseVisualStyleBackColor = true;
            // 
            // Teme
            // 
            this.Teme.Location = new System.Drawing.Point(129, 44);
            this.Teme.Name = "Teme";
            this.Teme.Size = new System.Drawing.Size(94, 22);
            this.Teme.TabIndex = 2;
            this.Teme.Text = "3eme";
            this.Teme.UseVisualStyleBackColor = true;
            // 
            // Qeme
            // 
            this.Qeme.Location = new System.Drawing.Point(129, 16);
            this.Qeme.Name = "Qeme";
            this.Qeme.Size = new System.Drawing.Size(94, 22);
            this.Qeme.TabIndex = 1;
            this.Qeme.Text = "4eme";
            this.Qeme.UseVisualStyleBackColor = true;
            // 
            // Seme
            // 
            this.Seme.Location = new System.Drawing.Point(20, 16);
            this.Seme.Name = "Seme";
            this.Seme.Size = new System.Drawing.Size(94, 22);
            this.Seme.TabIndex = 0;
            this.Seme.Text = "6eme";
            this.Seme.UseVisualStyleBackColor = true;
            // 
            // frmCartesParListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 694);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Seme;
        private System.Windows.Forms.RadioButton Qeme;
        private System.Windows.Forms.RadioButton Teme;
        private System.Windows.Forms.RadioButton tout;
        private System.Windows.Forms.RadioButton Ceme;

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