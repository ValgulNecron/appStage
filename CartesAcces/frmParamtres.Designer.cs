
namespace CartesAcces
{
    partial class frmParametres
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametres));
            this.btnImporterEleves = new System.Windows.Forms.Button();
            this.btnImportEDT = new System.Windows.Forms.Button();
            this.btnImportPhoto = new System.Windows.Forms.Button();
            this.txtPathEleve = new System.Windows.Forms.TextBox();
            this.btnValiderEleve = new System.Windows.Forms.Button();
            this.txtPathEDT = new System.Windows.Forms.TextBox();
            this.btnValiderEDT = new System.Windows.Forms.Button();
            this.txtPathPhoto = new System.Windows.Forms.TextBox();
            this.btnValiderPhoto = new System.Windows.Forms.Button();
            this.DataGridParametres = new System.Windows.Forms.DataGridView();
            this.txtRechercheDataGrid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelV = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDateImport = new System.Windows.Forms.Label();
            this.btnImportPhotoUnique = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridParametres)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImporterEleves
            // 
            this.btnImporterEleves.Location = new System.Drawing.Point(15, 631);
            this.btnImporterEleves.Name = "btnImporterEleves";
            this.btnImporterEleves.Size = new System.Drawing.Size(132, 53);
            this.btnImporterEleves.TabIndex = 0;
            this.btnImporterEleves.Text = "Importer une nouvelle liste d\'élève";
            this.btnImporterEleves.UseVisualStyleBackColor = true;
            this.btnImporterEleves.Click += new System.EventHandler(this.btnImporterEleves_Click);
            // 
            // btnImportEDT
            // 
            this.btnImportEDT.Location = new System.Drawing.Point(467, 12);
            this.btnImportEDT.Name = "btnImportEDT";
            this.btnImportEDT.Size = new System.Drawing.Size(237, 23);
            this.btnImportEDT.TabIndex = 1;
            this.btnImportEDT.Text = "Importer des emplois du temps..";
            this.btnImportEDT.UseVisualStyleBackColor = true;
            this.btnImportEDT.Click += new System.EventHandler(this.btnImportEDT_Click);
            // 
            // btnImportPhoto
            // 
            this.btnImportPhoto.Location = new System.Drawing.Point(467, 56);
            this.btnImportPhoto.Name = "btnImportPhoto";
            this.btnImportPhoto.Size = new System.Drawing.Size(237, 23);
            this.btnImportPhoto.TabIndex = 2;
            this.btnImportPhoto.Text = "Choisir le dossier qui comporte les photos";
            this.btnImportPhoto.UseVisualStyleBackColor = true;
            this.btnImportPhoto.Click += new System.EventHandler(this.btnImportPhoto_Click);
            // 
            // txtPathEleve
            // 
            this.txtPathEleve.Enabled = false;
            this.txtPathEleve.Location = new System.Drawing.Point(153, 648);
            this.txtPathEleve.Name = "txtPathEleve";
            this.txtPathEleve.Size = new System.Drawing.Size(193, 20);
            this.txtPathEleve.TabIndex = 5;
            // 
            // btnValiderEleve
            // 
            this.btnValiderEleve.Enabled = false;
            this.btnValiderEleve.Location = new System.Drawing.Point(352, 646);
            this.btnValiderEleve.Name = "btnValiderEleve";
            this.btnValiderEleve.Size = new System.Drawing.Size(75, 23);
            this.btnValiderEleve.TabIndex = 6;
            this.btnValiderEleve.Text = "&Valider";
            this.btnValiderEleve.UseVisualStyleBackColor = true;
            this.btnValiderEleve.Click += new System.EventHandler(this.btnValiderEleve_Click);
            // 
            // txtPathEDT
            // 
            this.txtPathEDT.Enabled = false;
            this.txtPathEDT.Location = new System.Drawing.Point(727, 12);
            this.txtPathEDT.Name = "txtPathEDT";
            this.txtPathEDT.Size = new System.Drawing.Size(296, 20);
            this.txtPathEDT.TabIndex = 7;
            // 
            // btnValiderEDT
            // 
            this.btnValiderEDT.Enabled = false;
            this.btnValiderEDT.Location = new System.Drawing.Point(1029, 10);
            this.btnValiderEDT.Name = "btnValiderEDT";
            this.btnValiderEDT.Size = new System.Drawing.Size(75, 23);
            this.btnValiderEDT.TabIndex = 8;
            this.btnValiderEDT.Text = "&Valider";
            this.btnValiderEDT.UseVisualStyleBackColor = true;
            this.btnValiderEDT.Click += new System.EventHandler(this.btnValiderEDT_Click);
            // 
            // txtPathPhoto
            // 
            this.txtPathPhoto.Enabled = false;
            this.txtPathPhoto.Location = new System.Drawing.Point(727, 56);
            this.txtPathPhoto.Name = "txtPathPhoto";
            this.txtPathPhoto.Size = new System.Drawing.Size(296, 20);
            this.txtPathPhoto.TabIndex = 9;
            // 
            // btnValiderPhoto
            // 
            this.btnValiderPhoto.Enabled = false;
            this.btnValiderPhoto.Location = new System.Drawing.Point(1029, 54);
            this.btnValiderPhoto.Name = "btnValiderPhoto";
            this.btnValiderPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnValiderPhoto.TabIndex = 10;
            this.btnValiderPhoto.Text = "&Valider";
            this.btnValiderPhoto.UseVisualStyleBackColor = true;
            this.btnValiderPhoto.Click += new System.EventHandler(this.btnValiderPhoto_Click);
            // 
            // DataGridParametres
            // 
            this.DataGridParametres.AllowUserToAddRows = false;
            this.DataGridParametres.AllowUserToDeleteRows = false;
            this.DataGridParametres.AllowUserToOrderColumns = true;
            this.DataGridParametres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridParametres.Location = new System.Drawing.Point(12, 56);
            this.DataGridParametres.Name = "DataGridParametres";
            this.DataGridParametres.ReadOnly = true;
            this.DataGridParametres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridParametres.Size = new System.Drawing.Size(444, 484);
            this.DataGridParametres.TabIndex = 11;
            this.DataGridParametres.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridParametres_CellContentClick);
            // 
            // txtRechercheDataGrid
            // 
            this.txtRechercheDataGrid.Location = new System.Drawing.Point(125, 15);
            this.txtRechercheDataGrid.Name = "txtRechercheDataGrid";
            this.txtRechercheDataGrid.Size = new System.Drawing.Size(331, 20);
            this.txtRechercheDataGrid.TabIndex = 12;
            this.txtRechercheDataGrid.TextChanged += new System.EventHandler(this.txtRechercheDataGrid_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Rechercher un élève";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 554);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 74);
            this.label2.TabIndex = 19;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelV
            // 
            this.labelV.AutoSize = true;
            this.labelV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelV.Location = new System.Drawing.Point(635, 310);
            this.labelV.Name = "labelV";
            this.labelV.Size = new System.Drawing.Size(345, 20);
            this.labelV.TabIndex = 20;
            this.labelV.Text = "Importation en cours, merci de patienter...";
            this.labelV.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Liste actuellement importée dans l\'application :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(446, 651);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Dernière importation :";
            // 
            // lblDateImport
            // 
            this.lblDateImport.AutoSize = true;
            this.lblDateImport.Location = new System.Drawing.Point(559, 651);
            this.lblDateImport.Name = "lblDateImport";
            this.lblDateImport.Size = new System.Drawing.Size(0, 13);
            this.lblDateImport.TabIndex = 23;
            // 
            // btnImportPhotoUnique
            // 
            this.btnImportPhotoUnique.Location = new System.Drawing.Point(467, 104);
            this.btnImportPhotoUnique.Name = "btnImportPhotoUnique";
            this.btnImportPhotoUnique.Size = new System.Drawing.Size(237, 23);
            this.btnImportPhotoUnique.TabIndex = 24;
            this.btnImportPhotoUnique.Text = "Importer une photo unique";
            this.btnImportPhotoUnique.UseVisualStyleBackColor = true;
            this.btnImportPhotoUnique.Click += new System.EventHandler(this.btnImportPhotoUnique_Click);
            // 
            // frmParametres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1109, 722);
            this.Controls.Add(this.btnImportPhotoUnique);
            this.Controls.Add(this.lblDateImport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRechercheDataGrid);
            this.Controls.Add(this.DataGridParametres);
            this.Controls.Add(this.btnValiderPhoto);
            this.Controls.Add(this.txtPathPhoto);
            this.Controls.Add(this.btnValiderEDT);
            this.Controls.Add(this.txtPathEDT);
            this.Controls.Add(this.btnValiderEleve);
            this.Controls.Add(this.txtPathEleve);
            this.Controls.Add(this.btnImportPhoto);
            this.Controls.Add(this.btnImportEDT);
            this.Controls.Add(this.btnImporterEleves);
            this.Name = "frmParametres";
            this.Text = "frmParametres";
            this.Load += new System.EventHandler(this.frmParametres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridParametres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImporterEleves;
        private System.Windows.Forms.Button btnImportEDT;
        private System.Windows.Forms.Button btnImportPhoto;
        private System.Windows.Forms.TextBox txtPathEleve;
        private System.Windows.Forms.Button btnValiderEleve;
        private System.Windows.Forms.TextBox txtPathEDT;
        private System.Windows.Forms.Button btnValiderEDT;
        private System.Windows.Forms.TextBox txtPathPhoto;
        private System.Windows.Forms.Button btnValiderPhoto;
        private System.Windows.Forms.DataGridView DataGridParametres;
        private System.Windows.Forms.TextBox txtRechercheDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDateImport;
        private System.Windows.Forms.Button btnImportPhotoUnique;
    }
}