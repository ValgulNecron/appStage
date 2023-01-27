
namespace CartesAcces
{
    partial class frmCarteParClasseNiveau
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
            this.cbbImprClasse = new System.Windows.Forms.ComboBox();
            this.cbbImprSection = new System.Windows.Forms.ComboBox();
            this.btnValiderImpr = new System.Windows.Forms.Button();
            this.lsbListeEleve = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbListePerso = new System.Windows.Forms.RadioButton();
            this.rdbClasseSection = new System.Windows.Forms.RadioButton();
            this.NbComptageEleveCS = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(441, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imprimer un classe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Imprimer une section";
            // 
            // cbbImprClasse
            // 
            this.cbbImprClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbImprClasse.FormattingEnabled = true;
            this.cbbImprClasse.Location = new System.Drawing.Point(551, 12);
            this.cbbImprClasse.Name = "cbbImprClasse";
            this.cbbImprClasse.Size = new System.Drawing.Size(147, 21);
            this.cbbImprClasse.TabIndex = 3;
            this.cbbImprClasse.SelectionChangeCommitted += new System.EventHandler(this.cbbImprClasse_SelectedIndexChanged);
            // 
            // cbbImprSection
            // 
            this.cbbImprSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbImprSection.FormattingEnabled = true;
            this.cbbImprSection.Items.AddRange(new object[] { "6eme", "5eme", "4eme", "3eme" });
            this.cbbImprSection.Location = new System.Drawing.Point(551, 53);
            this.cbbImprSection.Name = "cbbImprSection";
            this.cbbImprSection.Size = new System.Drawing.Size(147, 21);
            this.cbbImprSection.TabIndex = 4;
            this.cbbImprSection.SelectionChangeCommitted += new System.EventHandler(this.cbbImprSection_SelectedIndexChanged);
            // 
            // btnValiderImpr
            // 
            this.btnValiderImpr.Enabled = false;
            this.btnValiderImpr.Location = new System.Drawing.Point(745, 301);
            this.btnValiderImpr.Name = "btnValiderImpr";
            this.btnValiderImpr.Size = new System.Drawing.Size(254, 45);
            this.btnValiderImpr.TabIndex = 6;
            this.btnValiderImpr.Text = "&Valider la liste à imprimer";
            this.btnValiderImpr.UseVisualStyleBackColor = true;
            this.btnValiderImpr.Click += new System.EventHandler(this.btnValiderImpr_Click);
            // 
            // lsbListeEleve
            // 
            this.lsbListeEleve.FormattingEnabled = true;
            this.lsbListeEleve.Location = new System.Drawing.Point(757, 12);
            this.lsbListeEleve.Name = "lsbListeEleve";
            this.lsbListeEleve.Size = new System.Drawing.Size(242, 238);
            this.lsbListeEleve.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbListePerso);
            this.groupBox1.Controls.Add(this.rdbClasseSection);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 46);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // rdbListePerso
            // 
            this.rdbListePerso.AutoSize = true;
            this.rdbListePerso.Location = new System.Drawing.Point(133, 19);
            this.rdbListePerso.Name = "rdbListePerso";
            this.rdbListePerso.Size = new System.Drawing.Size(115, 17);
            this.rdbListePerso.TabIndex = 1;
            this.rdbListePerso.TabStop = true;
            this.rdbListePerso.Text = "Liste personnalisée";
            this.rdbListePerso.UseVisualStyleBackColor = true;
            this.rdbListePerso.CheckedChanged += new System.EventHandler(this.rdbListePerso_CheckedChanged);
            // 
            // rdbClasseSection
            // 
            this.rdbClasseSection.AutoSize = true;
            this.rdbClasseSection.Checked = true;
            this.rdbClasseSection.Location = new System.Drawing.Point(6, 19);
            this.rdbClasseSection.Name = "rdbClasseSection";
            this.rdbClasseSection.Size = new System.Drawing.Size(110, 17);
            this.rdbClasseSection.TabIndex = 0;
            this.rdbClasseSection.TabStop = true;
            this.rdbClasseSection.Text = "Classe ou Section";
            this.rdbClasseSection.UseVisualStyleBackColor = true;
            this.rdbClasseSection.CheckedChanged += new System.EventHandler(this.rdbClasseSection_CheckedChanged);
            // 
            // NbComptageEleveCS
            // 
            this.NbComptageEleveCS.AutoSize = true;
            this.NbComptageEleveCS.Location = new System.Drawing.Point(441, 91);
            this.NbComptageEleveCS.Name = "NbComptageEleveCS";
            this.NbComptageEleveCS.Size = new System.Drawing.Size(245, 13);
            this.NbComptageEleveCS.TabIndex = 25;
            this.NbComptageEleveCS.Text = "Nombre d\'élève de la liste de la classe ou section :";
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(682, 91);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(47, 23);
            this.lblCount.TabIndex = 27;
            this.lblCount.Text = "None";
            // 
            // frmCarteParClasseNiveau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 749);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.NbComptageEleveCS);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsbListeEleve);
            this.Controls.Add(this.btnValiderImpr);
            this.Controls.Add(this.cbbImprSection);
            this.Controls.Add(this.cbbImprClasse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCarteParClasseNiveau";
            this.Text = "frmCreationCarteParClasse";
            this.Load += new System.EventHandler(this.frmMultiplesCartes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblCount;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbImprClasse;
        private System.Windows.Forms.ComboBox cbbImprSection;
        private System.Windows.Forms.Button btnValiderImpr;
        private System.Windows.Forms.ListBox lsbListeEleve;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbListePerso;
        private System.Windows.Forms.RadioButton rdbClasseSection;
        private System.Windows.Forms.Label NbComptageEleveCS;
    }
}