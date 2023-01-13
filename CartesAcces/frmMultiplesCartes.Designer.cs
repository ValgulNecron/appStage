
namespace CartesAcces
{
    partial class frmMultiplesCartes
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCopierDataGrid = new System.Windows.Forms.Button();
            this.btnRechercheDataGrid = new System.Windows.Forms.Button();
            this.DataGridResultats = new System.Windows.Forms.DataGridView();
            this.txtRechercheDataGrid = new System.Windows.Forms.TextBox();
            this.DataGridParametres = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbListePerso = new System.Windows.Forms.RadioButton();
            this.rdbClasseSection = new System.Windows.Forms.RadioButton();
            this.NbComptageEleveCS = new System.Windows.Forms.Label();
            this.NbComptageEleveLP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridResultats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridParametres)).BeginInit();
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
            this.btnValiderImpr.Location = new System.Drawing.Point(12, 81);
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
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(929, 281);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCopierDataGrid
            // 
            this.btnCopierDataGrid.Location = new System.Drawing.Point(485, 462);
            this.btnCopierDataGrid.Name = "btnCopierDataGrid";
            this.btnCopierDataGrid.Size = new System.Drawing.Size(55, 33);
            this.btnCopierDataGrid.TabIndex = 22;
            this.btnCopierDataGrid.Text = "-->";
            this.btnCopierDataGrid.UseVisualStyleBackColor = true;
            this.btnCopierDataGrid.Click += new System.EventHandler(this.btnCopierDataGrid_Click);
            // 
            // btnRechercheDataGrid
            // 
            this.btnRechercheDataGrid.Location = new System.Drawing.Point(322, 284);
            this.btnRechercheDataGrid.Name = "btnRechercheDataGrid";
            this.btnRechercheDataGrid.Size = new System.Drawing.Size(91, 23);
            this.btnRechercheDataGrid.TabIndex = 21;
            this.btnRechercheDataGrid.Text = "Rechercher..";
            this.btnRechercheDataGrid.UseVisualStyleBackColor = true;
            this.btnRechercheDataGrid.Click += new System.EventHandler(this.btnRechercheDataGrid_Click);
            // 
            // DataGridResultats
            // 
            this.DataGridResultats.AllowUserToAddRows = false;
            this.DataGridResultats.AllowUserToDeleteRows = false;
            this.DataGridResultats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridResultats.Location = new System.Drawing.Point(546, 310);
            this.DataGridResultats.Name = "DataGridResultats";
            this.DataGridResultats.ReadOnly = true;
            this.DataGridResultats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridResultats.Size = new System.Drawing.Size(458, 513);
            this.DataGridResultats.TabIndex = 20;
            this.DataGridResultats.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridResultats_RowsAdded);
            this.DataGridResultats.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DataGridResultats_RowsRemoved);
            // 
            // txtRechercheDataGrid
            // 
            this.txtRechercheDataGrid.Location = new System.Drawing.Point(12, 284);
            this.txtRechercheDataGrid.Name = "txtRechercheDataGrid";
            this.txtRechercheDataGrid.Size = new System.Drawing.Size(280, 20);
            this.txtRechercheDataGrid.TabIndex = 19;
            this.txtRechercheDataGrid.TextChanged += new System.EventHandler(this.txtRechercheDataGrid_TextChanged);
            // 
            // DataGridParametres
            // 
            this.DataGridParametres.AllowUserToAddRows = false;
            this.DataGridParametres.AllowUserToDeleteRows = false;
            this.DataGridParametres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridParametres.Location = new System.Drawing.Point(12, 313);
            this.DataGridParametres.Name = "DataGridParametres";
            this.DataGridParametres.ReadOnly = true;
            this.DataGridParametres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridParametres.Size = new System.Drawing.Size(467, 510);
            this.DataGridParametres.TabIndex = 18;
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
            // NbComptageEleveLP
            // 
            this.NbComptageEleveLP.AutoSize = true;
            this.NbComptageEleveLP.Location = new System.Drawing.Point(543, 294);
            this.NbComptageEleveLP.Name = "NbComptageEleveLP";
            this.NbComptageEleveLP.Size = new System.Drawing.Size(196, 13);
            this.NbComptageEleveLP.TabIndex = 26;
            this.NbComptageEleveLP.Text = "Nombre d\'élève de la liste personnalisée";
            // 
            // frmMultiplesCartes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 749);
            this.Controls.Add(this.NbComptageEleveLP);
            this.Controls.Add(this.NbComptageEleveCS);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCopierDataGrid);
            this.Controls.Add(this.btnRechercheDataGrid);
            this.Controls.Add(this.DataGridResultats);
            this.Controls.Add(this.txtRechercheDataGrid);
            this.Controls.Add(this.DataGridParametres);
            this.Controls.Add(this.lsbListeEleve);
            this.Controls.Add(this.btnValiderImpr);
            this.Controls.Add(this.cbbImprSection);
            this.Controls.Add(this.cbbImprClasse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMultiplesCartes";
            this.Text = "frmCreationCarteParClasse";
            this.Load += new System.EventHandler(this.frmMultiplesCartes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridResultats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridParametres)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbImprClasse;
        private System.Windows.Forms.ComboBox cbbImprSection;
        private System.Windows.Forms.Button btnValiderImpr;
        private System.Windows.Forms.ListBox lsbListeEleve;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCopierDataGrid;
        private System.Windows.Forms.Button btnRechercheDataGrid;
        private System.Windows.Forms.DataGridView DataGridResultats;
        private System.Windows.Forms.TextBox txtRechercheDataGrid;
        private System.Windows.Forms.DataGridView DataGridParametres;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbListePerso;
        private System.Windows.Forms.RadioButton rdbClasseSection;
        private System.Windows.Forms.Label NbComptageEleveCS;
        private System.Windows.Forms.Label NbComptageEleveLP;
    }
}