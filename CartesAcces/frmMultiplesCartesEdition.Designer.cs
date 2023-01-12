
namespace CartesAcces
{
    partial class frmMultiplesCartesEdition
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
            this.pnlEdtPhoto = new System.Windows.Forms.Panel();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.pbCarteArriere = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnValiderImpr = new System.Windows.Forms.Button();
            this.tkbLargeurPhoto = new System.Windows.Forms.TrackBar();
            this.tkbHauteurPhoto = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCrop = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlEdtPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarteArriere)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbLargeurPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbHauteurPhoto)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEdtPhoto
            // 
            this.pnlEdtPhoto.Controls.Add(this.pbPhoto);
            this.pnlEdtPhoto.Controls.Add(this.pbCarteArriere);
            this.pnlEdtPhoto.Location = new System.Drawing.Point(12, 12);
            this.pnlEdtPhoto.Name = "pnlEdtPhoto";
            this.pnlEdtPhoto.Size = new System.Drawing.Size(540, 354);
            this.pnlEdtPhoto.TabIndex = 14;
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
            // pbCarteArriere
            // 
            this.pbCarteArriere.Location = new System.Drawing.Point(-1, -2);
            this.pbCarteArriere.Margin = new System.Windows.Forms.Padding(2);
            this.pbCarteArriere.Name = "pbCarteArriere";
            this.pbCarteArriere.Size = new System.Drawing.Size(540, 354);
            this.pbCarteArriere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCarteArriere.TabIndex = 7;
            this.pbCarteArriere.TabStop = false;
            this.pbCarteArriere.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCarteArriere_MouseDown);
            this.pbCarteArriere.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCarteArriere_MouseMove);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnValiderImpr);
            this.groupBox3.Controls.Add(this.tkbLargeurPhoto);
            this.groupBox3.Controls.Add(this.tkbHauteurPhoto);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 465);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(540, 175);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ajout et Edition Photo";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 149);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(248, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "En cours, veuillez attendre le message de validation";
            // 
            // btnValiderImpr
            // 
            this.btnValiderImpr.Location = new System.Drawing.Point(426, 132);
            this.btnValiderImpr.Name = "btnValiderImpr";
            this.btnValiderImpr.Size = new System.Drawing.Size(92, 36);
            this.btnValiderImpr.TabIndex = 16;
            this.btnValiderImpr.Text = "&Créer les fichiers à imprimer";
            this.btnValiderImpr.UseVisualStyleBackColor = true;
            this.btnValiderImpr.Click += new System.EventHandler(this.btnValiderImpr_Click);
            // 
            // tkbLargeurPhoto
            // 
            this.tkbLargeurPhoto.Location = new System.Drawing.Point(105, 100);
            this.tkbLargeurPhoto.Maximum = 300;
            this.tkbLargeurPhoto.Minimum = 30;
            this.tkbLargeurPhoto.Name = "tkbLargeurPhoto";
            this.tkbLargeurPhoto.Size = new System.Drawing.Size(422, 45);
            this.tkbLargeurPhoto.TabIndex = 8;
            this.tkbLargeurPhoto.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkbLargeurPhoto.Value = 100;
            this.tkbLargeurPhoto.Scroll += new System.EventHandler(this.tkbLargeurPhoto_Scroll);
            // 
            // tkbHauteurPhoto
            // 
            this.tkbHauteurPhoto.Location = new System.Drawing.Point(105, 37);
            this.tkbHauteurPhoto.Maximum = 300;
            this.tkbHauteurPhoto.Minimum = 30;
            this.tkbHauteurPhoto.Name = "tkbHauteurPhoto";
            this.tkbHauteurPhoto.Size = new System.Drawing.Size(422, 45);
            this.tkbHauteurPhoto.TabIndex = 7;
            this.tkbHauteurPhoto.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkbHauteurPhoto.Value = 130;
            this.tkbHauteurPhoto.Scroll += new System.EventHandler(this.tkbHauteurPhoto_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Largeur";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hauteur";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnCrop);
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Location = new System.Drawing.Point(12, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 80);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edition Emploi du Temps";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(391, 33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Annuler le rognagne";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Enabled = false;
            this.btnCrop.Location = new System.Drawing.Point(207, 33);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(127, 23);
            this.btnCrop.TabIndex = 1;
            this.btnCrop.Text = "&Valider le rognage";
            this.btnCrop.UseVisualStyleBackColor = true;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(21, 33);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(148, 41);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "&Sélectionnez la zone à rogner";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmMultiplesCartesEdition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(564, 650);
            this.Controls.Add(this.pnlEdtPhoto);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmMultiplesCartesEdition";
            this.Text = "frmMultiplesCartesEdition";
            this.Load += new System.EventHandler(this.frmMultiplesCartesEdition_Load);
            this.pnlEdtPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarteArriere)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbLargeurPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbHauteurPhoto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEdtPhoto;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.PictureBox pbCarteArriere;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar tkbLargeurPhoto;
        private System.Windows.Forms.TrackBar tkbHauteurPhoto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCrop;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnValiderImpr;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}