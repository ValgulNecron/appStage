﻿
namespace CartesAcces
{
    partial class frmImportation
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
            this.btnImporterEleves = new System.Windows.Forms.Button();
            this.btnImportEDT = new System.Windows.Forms.Button();
            this.btnImportPhoto = new System.Windows.Forms.Button();
            this.lblDateImport = new System.Windows.Forms.Label();
            this.lblDateListeEleve = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEdtEleve = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPhotoEleve = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImporterEleves
            // 
            this.btnImporterEleves.Location = new System.Drawing.Point(12, 21);
            this.btnImporterEleves.Name = "btnImporterEleves";
            this.btnImporterEleves.Size = new System.Drawing.Size(237, 23);
            this.btnImporterEleves.TabIndex = 0;
            this.btnImporterEleves.Text = "Importer une nouvelle liste d\'élève";
            this.btnImporterEleves.UseVisualStyleBackColor = true;
            this.btnImporterEleves.Click += new System.EventHandler(this.btnImporterEleves_Click);
            // 
            // btnImportEDT
            // 
            this.btnImportEDT.Location = new System.Drawing.Point(12, 62);
            this.btnImportEDT.Name = "btnImportEDT";
            this.btnImportEDT.Size = new System.Drawing.Size(237, 23);
            this.btnImportEDT.TabIndex = 1;
            this.btnImportEDT.Text = "Importer des emplois du temps..";
            this.btnImportEDT.UseVisualStyleBackColor = true;
            this.btnImportEDT.Click += new System.EventHandler(this.btnImportEDT_Click);
            // 
            // btnImportPhoto
            // 
            this.btnImportPhoto.Location = new System.Drawing.Point(12, 101);
            this.btnImportPhoto.Name = "btnImportPhoto";
            this.btnImportPhoto.Size = new System.Drawing.Size(237, 23);
            this.btnImportPhoto.TabIndex = 2;
            this.btnImportPhoto.Text = "Choisir le dossier qui comporte les photos";
            this.btnImportPhoto.UseVisualStyleBackColor = true;
            this.btnImportPhoto.Click += new System.EventHandler(this.btnImportPhoto_Click);
            // 
            // lblDateImport
            // 
            this.lblDateImport.AutoSize = true;
            this.lblDateImport.Location = new System.Drawing.Point(559, 651);
            this.lblDateImport.Name = "lblDateImport";
            this.lblDateImport.Size = new System.Drawing.Size(0, 13);
            this.lblDateImport.TabIndex = 23;
            // 
            // lblDateListeEleve
            // 
            this.lblDateListeEleve.Location = new System.Drawing.Point(374, 26);
            this.lblDateListeEleve.Name = "lblDateListeEleve";
            this.lblDateListeEleve.Size = new System.Drawing.Size(199, 23);
            this.lblDateListeEleve.TabIndex = 26;
            this.lblDateListeEleve.Text = "Aucune Importation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Dernière importation :";
            // 
            // lblEdtEleve
            // 
            this.lblEdtEleve.Location = new System.Drawing.Point(374, 68);
            this.lblEdtEleve.Name = "lblEdtEleve";
            this.lblEdtEleve.Size = new System.Drawing.Size(199, 23);
            this.lblEdtEleve.TabIndex = 28;
            this.lblEdtEleve.Text = "Aucune Importation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Dernière importation :";
            // 
            // lblPhotoEleve
            // 
            this.lblPhotoEleve.Location = new System.Drawing.Point(374, 108);
            this.lblPhotoEleve.Name = "lblPhotoEleve";
            this.lblPhotoEleve.Size = new System.Drawing.Size(199, 23);
            this.lblPhotoEleve.TabIndex = 30;
            this.lblPhotoEleve.Text = "Aucune Importation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Dernière importation :";
            // 
            // frmImportation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1109, 722);
            this.Controls.Add(this.lblPhotoEleve);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblEdtEleve);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDateListeEleve);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDateImport);
            this.Controls.Add(this.btnImportPhoto);
            this.Controls.Add(this.btnImportEDT);
            this.Controls.Add(this.btnImporterEleves);
            this.Name = "frmImportation";
            this.Text = "frmImportation";
            this.Load += new System.EventHandler(this.frmParametres_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblDateListeEleve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEdtEleve;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPhotoEleve;
        private System.Windows.Forms.Label label7;

        #endregion

        private System.Windows.Forms.Button btnImporterEleves;
        private System.Windows.Forms.Button btnImportEDT;
        private System.Windows.Forms.Button btnImportPhoto;
        private System.Windows.Forms.Label lblDateImport;
    }
}