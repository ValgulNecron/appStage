
namespace CartesAcces
{
    partial class frmCarteIndividuelle
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEdtPerso = new System.Windows.Forms.Button();
            this.rdbClRelais = new System.Windows.Forms.RadioButton();
            this.rdbRas = new System.Windows.Forms.RadioButton();
            this.rdbUPE2A = new System.Windows.Forms.RadioButton();
            this.rdbUlis = new System.Windows.Forms.RadioButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.cbbClasse = new System.Windows.Forms.ComboBox();
            this.cbbSection = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbCarteFace = new System.Windows.Forms.PictureBox();
            this.pbCarteArriere = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCrop = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tkbTaillePhoto = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAnnulerPhoto = new System.Windows.Forms.Button();
            this.btnAjouterPhoto = new System.Windows.Forms.Button();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.pnlEdtPhoto = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarteFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarteArriere)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbTaillePhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.pnlEdtPhoto.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEdtPerso);
            this.groupBox1.Controls.Add(this.rdbClRelais);
            this.groupBox1.Controls.Add(this.rdbRas);
            this.groupBox1.Controls.Add(this.rdbUPE2A);
            this.groupBox1.Controls.Add(this.rdbUlis);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.cbbClasse);
            this.groupBox1.Controls.Add(this.cbbSection);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPrenom);
            this.groupBox1.Controls.Add(this.txtNom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 204);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Renseignements Élève";
            // 
            // btnEdtPerso
            // 
            this.btnEdtPerso.Enabled = false;
            this.btnEdtPerso.Location = new System.Drawing.Point(275, 153);
            this.btnEdtPerso.Name = "btnEdtPerso";
            this.btnEdtPerso.Size = new System.Drawing.Size(121, 36);
            this.btnEdtPerso.TabIndex = 18;
            this.btnEdtPerso.Text = "Ajouter un emploi du temps personnalisé";
            this.btnEdtPerso.UseVisualStyleBackColor = true;
            this.btnEdtPerso.Click += new System.EventHandler(this.btnEdtPerso_Click);
            // 
            // rdbClRelais
            // 
            this.rdbClRelais.AutoSize = true;
            this.rdbClRelais.Enabled = false;
            this.rdbClRelais.Location = new System.Drawing.Point(275, 121);
            this.rdbClRelais.Name = "rdbClRelais";
            this.rdbClRelais.Size = new System.Drawing.Size(70, 17);
            this.rdbClRelais.TabIndex = 17;
            this.rdbClRelais.TabStop = true;
            this.rdbClRelais.Text = "CL-Relais";
            this.rdbClRelais.UseVisualStyleBackColor = true;
            // 
            // rdbRas
            // 
            this.rdbRas.AutoSize = true;
            this.rdbRas.Checked = true;
            this.rdbRas.Enabled = false;
            this.rdbRas.Location = new System.Drawing.Point(343, 62);
            this.rdbRas.Name = "rdbRas";
            this.rdbRas.Size = new System.Drawing.Size(53, 17);
            this.rdbRas.TabIndex = 16;
            this.rdbRas.TabStop = true;
            this.rdbRas.Text = "R.A.S";
            this.rdbRas.UseVisualStyleBackColor = true;
            this.rdbRas.CheckedChanged += new System.EventHandler(this.rdbRas_CheckedChanged);
            // 
            // rdbUPE2A
            // 
            this.rdbUPE2A.AutoSize = true;
            this.rdbUPE2A.Enabled = false;
            this.rdbUPE2A.Location = new System.Drawing.Point(275, 92);
            this.rdbUPE2A.Name = "rdbUPE2A";
            this.rdbUPE2A.Size = new System.Drawing.Size(60, 17);
            this.rdbUPE2A.TabIndex = 15;
            this.rdbUPE2A.TabStop = true;
            this.rdbUPE2A.Text = "UPE2A";
            this.rdbUPE2A.UseVisualStyleBackColor = true;
            this.rdbUPE2A.CheckedChanged += new System.EventHandler(this.rdbUPE2A_CheckedChanged);
            // 
            // rdbUlis
            // 
            this.rdbUlis.AutoSize = true;
            this.rdbUlis.Enabled = false;
            this.rdbUlis.Location = new System.Drawing.Point(275, 63);
            this.rdbUlis.Name = "rdbUlis";
            this.rdbUlis.Size = new System.Drawing.Size(49, 17);
            this.rdbUlis.TabIndex = 14;
            this.rdbUlis.TabStop = true;
            this.rdbUlis.Text = "ULIS";
            this.rdbUlis.UseVisualStyleBackColor = true;
            this.rdbUlis.CheckedChanged += new System.EventHandler(this.rdbUlis_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(275, 28);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Réinitialiser la carte";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbbClasse
            // 
            this.cbbClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbClasse.FormattingEnabled = true;
            this.cbbClasse.Location = new System.Drawing.Point(120, 61);
            this.cbbClasse.Name = "cbbClasse";
            this.cbbClasse.Size = new System.Drawing.Size(121, 21);
            this.cbbClasse.TabIndex = 7;
            this.cbbClasse.SelectedIndexChanged += new System.EventHandler(this.cbbClasse_SelectedIndexChanged);
            // 
            // cbbSection
            // 
            this.cbbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSection.FormattingEnabled = true;
            this.cbbSection.Items.AddRange(new object[] { "6eme", "5eme", "4eme", "3eme" });
            this.cbbSection.Location = new System.Drawing.Point(120, 30);
            this.cbbSection.Name = "cbbSection";
            this.cbbSection.Size = new System.Drawing.Size(121, 21);
            this.cbbSection.TabIndex = 6;
            this.cbbSection.SelectedIndexChanged += new System.EventHandler(this.cbbSection_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Classe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Niveau";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Enabled = false;
            this.txtPrenom.Location = new System.Drawing.Point(120, 121);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(121, 20);
            this.txtPrenom.TabIndex = 3;
            this.txtPrenom.TextChanged += new System.EventHandler(this.txtPrenom_TextChanged);
            // 
            // txtNom
            // 
            this.txtNom.Enabled = false;
            this.txtNom.Location = new System.Drawing.Point(120, 91);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(121, 20);
            this.txtNom.TabIndex = 2;
            this.txtNom.TextChanged += new System.EventHandler(this.txtNom_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prenom";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // pbCarteFace
            // 
            this.pbCarteFace.Enabled = false;
            this.pbCarteFace.Location = new System.Drawing.Point(11, 11);
            this.pbCarteFace.Margin = new System.Windows.Forms.Padding(2);
            this.pbCarteFace.Name = "pbCarteFace";
            this.pbCarteFace.Size = new System.Drawing.Size(540, 354);
            this.pbCarteFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCarteFace.TabIndex = 4;
            this.pbCarteFace.TabStop = false;
            // 
            // pbCarteArriere
            // 
            this.pbCarteArriere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCarteArriere.Location = new System.Drawing.Point(0, 0);
            this.pbCarteArriere.Margin = new System.Windows.Forms.Padding(2);
            this.pbCarteArriere.Name = "pbCarteArriere";
            this.pbCarteArriere.Size = new System.Drawing.Size(540, 354);
            this.pbCarteArriere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCarteArriere.TabIndex = 7;
            this.pbCarteArriere.TabStop = false;
            this.pbCarteArriere.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCarteArriere_MouseDown);
            this.pbCarteArriere.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCarteArriere_MouseMove);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnCrop);
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Location = new System.Drawing.Point(556, 389);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 80);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edition Emploi du Temps";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(391, 33);
            this.btnCancel.MaximumSize = new System.Drawing.Size(127, 23);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Annuler le rognage";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrop.Enabled = false;
            this.btnCrop.Location = new System.Drawing.Point(207, 33);
            this.btnCrop.MaximumSize = new System.Drawing.Size(127, 23);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(127, 23);
            this.btnCrop.TabIndex = 1;
            this.btnCrop.Text = "&Rogner";
            this.btnCrop.UseVisualStyleBackColor = true;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(21, 22);
            this.btnSelect.MaximumSize = new System.Drawing.Size(140, 50);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(140, 44);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "&Sélectionner la zone à rogner";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.tkbTaillePhoto);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnAnnulerPhoto);
            this.groupBox3.Controls.Add(this.btnAjouterPhoto);
            this.groupBox3.Location = new System.Drawing.Point(556, 475);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(540, 198);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ajout et Edition Photo";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(443, 151);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tkbTaillePhoto
            // 
            this.tkbTaillePhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tkbTaillePhoto.Location = new System.Drawing.Point(267, 37);
            this.tkbTaillePhoto.Maximum = 300;
            this.tkbTaillePhoto.Minimum = 30;
            this.tkbTaillePhoto.Name = "tkbTaillePhoto";
            this.tkbTaillePhoto.Size = new System.Drawing.Size(260, 45);
            this.tkbTaillePhoto.TabIndex = 7;
            this.tkbTaillePhoto.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkbTaillePhoto.Value = 130;
            this.tkbTaillePhoto.Scroll += new System.EventHandler(this.tkbTaillePhoto_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Taille";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Redefinir la taille";
            // 
            // btnAnnulerPhoto
            // 
            this.btnAnnulerPhoto.Location = new System.Drawing.Point(21, 96);
            this.btnAnnulerPhoto.Name = "btnAnnulerPhoto";
            this.btnAnnulerPhoto.Size = new System.Drawing.Size(127, 36);
            this.btnAnnulerPhoto.TabIndex = 3;
            this.btnAnnulerPhoto.Text = "&Effacer les modifications";
            this.btnAnnulerPhoto.UseVisualStyleBackColor = true;
            this.btnAnnulerPhoto.Click += new System.EventHandler(this.btnAnnulerPhoto_Click);
            // 
            // btnAjouterPhoto
            // 
            this.btnAjouterPhoto.Location = new System.Drawing.Point(21, 34);
            this.btnAjouterPhoto.Name = "btnAjouterPhoto";
            this.btnAjouterPhoto.Size = new System.Drawing.Size(127, 30);
            this.btnAjouterPhoto.TabIndex = 0;
            this.btnAjouterPhoto.Text = "&Choisir une photo";
            this.btnAjouterPhoto.UseVisualStyleBackColor = true;
            this.btnAjouterPhoto.Click += new System.EventHandler(this.btnAjouterPhoto_Click);
            // 
            // pbPhoto
            // 
            this.pbPhoto.Location = new System.Drawing.Point(5, 5);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(100, 50);
            this.pbPhoto.TabIndex = 10;
            this.pbPhoto.TabStop = false;
            this.pbPhoto.Visible = false;
            this.pbPhoto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPhoto_MouseDown);
            this.pbPhoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPhoto_MouseMove);
            this.pbPhoto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPhoto_MouseUp);
            // 
            // pnlEdtPhoto
            // 
            this.pnlEdtPhoto.Controls.Add(this.pbPhoto);
            this.pnlEdtPhoto.Controls.Add(this.pbCarteArriere);
            this.pnlEdtPhoto.Location = new System.Drawing.Point(556, 11);
            this.pnlEdtPhoto.Name = "pnlEdtPhoto";
            this.pnlEdtPhoto.Size = new System.Drawing.Size(540, 356);
            this.pnlEdtPhoto.TabIndex = 11;
            // 
            // frmCarteIndividuelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1119, 704);
            this.Controls.Add(this.pnlEdtPhoto);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbCarteFace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(1125, 726);
            this.Name = "frmCarteIndividuelle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarteFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarteArriere)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbTaillePhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.pnlEdtPhoto.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pbCarteFace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbClasse;
        private System.Windows.Forms.ComboBox cbbSection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbCarteArriere;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCrop;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAnnulerPhoto;
        private System.Windows.Forms.Button btnAjouterPhoto;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Panel pnlEdtPhoto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tkbTaillePhoto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton rdbRas;
        private System.Windows.Forms.RadioButton rdbUPE2A;
        private System.Windows.Forms.RadioButton rdbUlis;
        private System.Windows.Forms.RadioButton rdbClRelais;
        private System.Windows.Forms.Button btnEdtPerso;
    }
}