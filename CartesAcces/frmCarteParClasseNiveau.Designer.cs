
namespace CartesAcces
{
    partial class FrmCarteParClasseNiveau
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label2 = new System.Windows.Forms.Label();
            this.cbbImprSection = new System.Windows.Forms.ComboBox();
            this.btnValiderImpr = new System.Windows.Forms.Button();
            this.lsbListeEleve = new System.Windows.Forms.ListBox();
            this.NbComptageEleveCS = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.cbbImprClasse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(158, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imprimer un classe :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(158, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Imprimer par niveau";
            // 
            // cbbImprSection
            // 
            this.cbbImprSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbImprSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cbbImprSection.FormattingEnabled = true;
            this.cbbImprSection.Items.AddRange(new object[] { "6eme", "5eme", "4eme", "3eme" });
            this.cbbImprSection.Location = new System.Drawing.Point(301, 258);
            this.cbbImprSection.MaximumSize = new System.Drawing.Size(180, 0);
            this.cbbImprSection.MinimumSize = new System.Drawing.Size(180, 0);
            this.cbbImprSection.Name = "cbbImprSection";
            this.cbbImprSection.Size = new System.Drawing.Size(180, 24);
            this.cbbImprSection.TabIndex = 4;
            this.cbbImprSection.SelectionChangeCommitted += new System.EventHandler(this.cbbImprSection_SelectedIndexChanged);
            // 
            // btnValiderImpr
            // 
            this.btnValiderImpr.Enabled = false;
            this.btnValiderImpr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnValiderImpr.Location = new System.Drawing.Point(713, 612);
            this.btnValiderImpr.MaximumSize = new System.Drawing.Size(180, 45);
            this.btnValiderImpr.MinimumSize = new System.Drawing.Size(180, 45);
            this.btnValiderImpr.Name = "btnValiderImpr";
            this.btnValiderImpr.Size = new System.Drawing.Size(180, 45);
            this.btnValiderImpr.TabIndex = 6;
            this.btnValiderImpr.Text = "&Valider la liste à imprimer";
            this.btnValiderImpr.UseVisualStyleBackColor = true;
            this.btnValiderImpr.Click += new System.EventHandler(this.btnValiderImpr_Click);
            // 
            // lsbListeEleve
            // 
            this.lsbListeEleve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lsbListeEleve.FormattingEnabled = true;
            this.lsbListeEleve.ItemHeight = 16;
            this.lsbListeEleve.Location = new System.Drawing.Point(543, 106);
            this.lsbListeEleve.MaximumSize = new System.Drawing.Size(350, 500);
            this.lsbListeEleve.MinimumSize = new System.Drawing.Size(350, 500);
            this.lsbListeEleve.Name = "lsbListeEleve";
            this.lsbListeEleve.Size = new System.Drawing.Size(350, 500);
            this.lsbListeEleve.TabIndex = 7;
            // 
            // NbComptageEleveCS
            // 
            this.NbComptageEleveCS.AutoSize = true;
            this.NbComptageEleveCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.NbComptageEleveCS.Location = new System.Drawing.Point(157, 329);
            this.NbComptageEleveCS.Name = "NbComptageEleveCS";
            this.NbComptageEleveCS.Size = new System.Drawing.Size(311, 16);
            this.NbComptageEleveCS.TabIndex = 25;
            this.NbComptageEleveCS.Text = "Nombre d\'élève de la liste de la classe ou section :";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(474, 329);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(47, 23);
            this.lblCount.TabIndex = 27;
            this.lblCount.Text = "None";
            // 
            // cbbImprClasse
            // 
            this.cbbImprClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbImprClasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cbbImprClasse.FormattingEnabled = true;
            this.cbbImprClasse.Location = new System.Drawing.Point(301, 192);
            this.cbbImprClasse.MaximumSize = new System.Drawing.Size(180, 0);
            this.cbbImprClasse.MinimumSize = new System.Drawing.Size(180, 0);
            this.cbbImprClasse.Name = "cbbImprClasse";
            this.cbbImprClasse.Size = new System.Drawing.Size(180, 24);
            this.cbbImprClasse.TabIndex = 28;
            this.cbbImprClasse.SelectionChangeCommitted += new System.EventHandler(this.cbbImprClasse_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(199, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 24);
            this.label3.TabIndex = 29;
            this.label3.Text = "OU";
            // 
            // frmCarteParClasseNiveau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 749);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbImprClasse);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.NbComptageEleveCS);
            this.Controls.Add(this.lsbListeEleve);
            this.Controls.Add(this.btnValiderImpr);
            this.Controls.Add(this.cbbImprSection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCarteParClasseNiveau";
            this.Text = "frmCreationCarteParClasse";
            this.Load += new System.EventHandler(this.frmMultiplesCartes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label lblCount;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbImprSection;
        private System.Windows.Forms.Button btnValiderImpr;
        private System.Windows.Forms.ListBox lsbListeEleve;
        private System.Windows.Forms.Label NbComptageEleveCS;
        private System.Windows.Forms.ComboBox cbbImprClasse;
    }
}