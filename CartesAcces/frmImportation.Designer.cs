
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
            this.lblDateListeEleve = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEdtEleve = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPhotoEleve = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnImportEdtClassique = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblImportEdtClassique = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnImporterUnEtablissement = new System.Windows.Forms.Button();
            this.btCreationUtilisateur = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImporterEleves
            // 
            this.btnImporterEleves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImporterEleves.Location = new System.Drawing.Point(210, 248);
            this.btnImporterEleves.MaximumSize = new System.Drawing.Size(320, 35);
            this.btnImporterEleves.MinimumSize = new System.Drawing.Size(320, 35);
            this.btnImporterEleves.Name = "btnImporterEleves";
            this.btnImporterEleves.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnImporterEleves.Size = new System.Drawing.Size(320, 35);
            this.btnImporterEleves.TabIndex = 0;
            this.btnImporterEleves.Text = "Importer une nouvelle liste d\'élève";
            this.btnImporterEleves.UseVisualStyleBackColor = true;
            this.btnImporterEleves.Click += new System.EventHandler(this.btnImporterEleves_Click);
            // 
            // btnImportEDT
            // 
            this.btnImportEDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportEDT.Location = new System.Drawing.Point(210, 313);
            this.btnImportEDT.MaximumSize = new System.Drawing.Size(320, 35);
            this.btnImportEDT.MinimumSize = new System.Drawing.Size(320, 35);            
            this.btnImportEDT.Name = "btnImportEDT"; 
            this.btnImportEDT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnImportEDT.Size = new System.Drawing.Size(320, 35);
            this.btnImportEDT.TabIndex = 1;
            this.btnImportEDT.Text = "Importer des emplois du temps";
            this.btnImportEDT.UseVisualStyleBackColor = true;
            this.btnImportEDT.Click += new System.EventHandler(this.btnImportEDT_Click);
            // 
            // btnImportPhoto
            // 
            this.btnImportPhoto.AutoSize = true;
            this.btnImportPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportPhoto.Location = new System.Drawing.Point(210, 379);
            this.btnImportPhoto.MaximumSize = new System.Drawing.Size(320, 35);
            this.btnImportPhoto.MinimumSize = new System.Drawing.Size(320, 35);
            this.btnImportPhoto.Name = "btnImportPhoto";
            this.btnImportPhoto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnImportPhoto.Size = new System.Drawing.Size(320, 35);
            this.btnImportPhoto.TabIndex = 2;
            this.btnImportPhoto.Text = "Choisir le dossier qui comporte les photos";
            this.btnImportPhoto.UseVisualStyleBackColor = true;
            this.btnImportPhoto.Click += new System.EventHandler(this.btnImportPhoto_Click);
            // 
            // lblDateListeEleve
            // 
            this.lblDateListeEleve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateListeEleve.Location = new System.Drawing.Point(686, 255);
            this.lblDateListeEleve.Name = "lblDateListeEleve";
            this.lblDateListeEleve.Size = new System.Drawing.Size(258, 23);
            this.lblDateListeEleve.TabIndex = 26;
            this.lblDateListeEleve.Text = "Aucune Importation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(545, 257);            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Dernière importation :";
            // 
            // lblEdtEleve
            // 
            this.lblEdtEleve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdtEleve.Location = new System.Drawing.Point(686, 322);
            this.lblEdtEleve.Name = "lblEdtEleve";
            this.lblEdtEleve.Size = new System.Drawing.Size(258, 23);
            this.lblEdtEleve.TabIndex = 28;
            this.lblEdtEleve.Text = "Aucune Importation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(545, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Dernière importation :";
            // 
            // lblPhotoEleve
            // 
            this.lblPhotoEleve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhotoEleve.Location = new System.Drawing.Point(686, 388);
            this.lblPhotoEleve.Name = "lblPhotoEleve";
            this.lblPhotoEleve.Size = new System.Drawing.Size(258, 23);
            this.lblPhotoEleve.TabIndex = 30;
            this.lblPhotoEleve.Text = "Aucune Importation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(545, 388);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Dernière importation :";
            // 
            // btnImportEdtClassique
            // 
            this.btnImportEdtClassique.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportEdtClassique.Location = new System.Drawing.Point(210, 443);
            this.btnImportEdtClassique.MaximumSize = new System.Drawing.Size(320, 35);
            this.btnImportEdtClassique.MinimumSize = new System.Drawing.Size(320, 35);
            this.btnImportEdtClassique.Name = "btnImportEdtClassique";
            this.btnImportEdtClassique.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnImportEdtClassique.Size = new System.Drawing.Size(320, 35);
            this.btnImportEdtClassique.TabIndex = 31;
            this.btnImportEdtClassique.Text = "Importer des emplois du temps pour les classes";
            this.btnImportEdtClassique.UseVisualStyleBackColor = true;
            this.btnImportEdtClassique.Click += new System.EventHandler(this.btnImportEdtClassique_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(545, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Dernière importation :";
            // 
            // lblImportEdtClassique
            // 
            this.lblImportEdtClassique.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportEdtClassique.Location = new System.Drawing.Point(686, 452);
            this.lblImportEdtClassique.Name = "lblImportEdtClassique";
            this.lblImportEdtClassique.Size = new System.Drawing.Size(258, 23);
            this.lblImportEdtClassique.TabIndex = 35;
            this.lblImportEdtClassique.Text = "Aucune Importation";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(907, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // btnImporterUnEtablissement
            // 
            this.btnImporterUnEtablissement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImporterUnEtablissement.Location = new System.Drawing.Point(210, 125);
            this.btnImporterUnEtablissement.MaximumSize = new System.Drawing.Size(320, 45);
            this.btnImporterUnEtablissement.MinimumSize = new System.Drawing.Size(320, 45);
            this.btnImporterUnEtablissement.Name = "btnImporterUnEtablissement";
            this.btnImporterUnEtablissement.Size = new System.Drawing.Size(320, 45);
            this.btnImporterUnEtablissement.TabIndex = 37;
            this.btnImporterUnEtablissement.Text = "Importer un nouvel établissement";
            this.btnImporterUnEtablissement.UseVisualStyleBackColor = true;
            this.btnImporterUnEtablissement.Click += new System.EventHandler(this.btnImporterUnEtablissement_Click);
            // 
            // btCreationUtilisateur
            // 
            this.btCreationUtilisateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCreationUtilisateur.Location = new System.Drawing.Point(581, 125);
            this.btCreationUtilisateur.MaximumSize = new System.Drawing.Size(320, 45);
            this.btCreationUtilisateur.MinimumSize = new System.Drawing.Size(320, 45);
            this.btCreationUtilisateur.Name = "btCreationUtilisateur";
            this.btCreationUtilisateur.Size = new System.Drawing.Size(320, 45);
            this.btCreationUtilisateur.TabIndex = 38;
            this.btCreationUtilisateur.Text = "Créer un utilisateur ";
            this.btCreationUtilisateur.UseVisualStyleBackColor = true;
            this.btCreationUtilisateur.Click += new System.EventHandler(this.btCreationUtilisateur_Click);
            // 
            // frmImportation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1196, 776);
            this.Controls.Add(this.btCreationUtilisateur);
            this.Controls.Add(this.btnImporterUnEtablissement);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblImportEdtClassique);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImportEdtClassique);
            this.Controls.Add(this.lblPhotoEleve);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblEdtEleve);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDateListeEleve);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnImportPhoto);
            this.Controls.Add(this.btnImportEDT);
            this.Controls.Add(this.btnImporterEleves);
            this.Name = "frmImportation";
            this.Text = "frmImportation";
            this.Load += new System.EventHandler(this.frmParametres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btCreationUtilisateur;

        private System.Windows.Forms.Button btnImporterUnEtablissement;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Button btnImportEdtClassique;

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblImportEdtClassique;
    }
}