using System.ComponentModel;

namespace AffichageLog
{
    partial class frmAccueil
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeMdp = new System.Windows.Forms.Button();
            this.btnAfficheListeEleve = new System.Windows.Forms.Button();
            this.btnTheme = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnParametres = new System.Windows.Forms.Button();
            this.btnCarteParClasse = new System.Windows.Forms.Button();
            this.btnCreerCarte = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Controls.Add(this.pnlMenu);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(2016, 1078);
            this.pnlContent.TabIndex = 4;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlMenu.Controls.Add(this.pictureBox2);
            this.pnlMenu.Controls.Add(this.pictureBox1);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.label1);
            this.pnlMenu.Controls.Add(this.btnChangeMdp);
            this.pnlMenu.Controls.Add(this.btnAfficheListeEleve);
            this.pnlMenu.Controls.Add(this.btnTheme);
            this.pnlMenu.Controls.Add(this.lblVersion);
            this.pnlMenu.Controls.Add(this.btnParametres);
            this.pnlMenu.Controls.Add(this.btnCarteParClasse);
            this.pnlMenu.Controls.Add(this.btnCreerCarte);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(255, 1078);
            this.pnlMenu.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(58, 931);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(147, 129);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 238);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(4, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 35);
            this.label2.TabIndex = 9;
            this.label2.Text = "Création carte accès";
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(58, 583);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 35);
            this.label1.TabIndex = 8;
            this.label1.Text = "Paramètres";
            // 
            // btnChangeMdp
            // 
            this.btnChangeMdp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChangeMdp.BackColor = System.Drawing.Color.AliceBlue;
            this.btnChangeMdp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangeMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnChangeMdp.Location = new System.Drawing.Point(-2, 697);
            this.btnChangeMdp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnChangeMdp.Name = "btnChangeMdp";
            this.btnChangeMdp.Size = new System.Drawing.Size(255, 65);
            this.btnChangeMdp.TabIndex = 7;
            this.btnChangeMdp.Text = "Changer le mot de passe";
            this.btnChangeMdp.UseVisualStyleBackColor = false;
            // 
            // btnAfficheListeEleve
            // 
            this.btnAfficheListeEleve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAfficheListeEleve.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAfficheListeEleve.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAfficheListeEleve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnAfficheListeEleve.Location = new System.Drawing.Point(0, 372);
            this.btnAfficheListeEleve.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAfficheListeEleve.Name = "btnAfficheListeEleve";
            this.btnAfficheListeEleve.Size = new System.Drawing.Size(255, 65);
            this.btnAfficheListeEleve.TabIndex = 6;
            this.btnAfficheListeEleve.Text = "Cartes par liste personnalisée";
            this.btnAfficheListeEleve.UseVisualStyleBackColor = false;
            // 
            // btnTheme
            // 
            this.btnTheme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTheme.BackColor = System.Drawing.Color.AliceBlue;
            this.btnTheme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnTheme.Location = new System.Drawing.Point(-2, 771);
            this.btnTheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(255, 65);
            this.btnTheme.TabIndex = 5;
            this.btnTheme.Text = "Thème sombre / clair";
            this.btnTheme.UseVisualStyleBackColor = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblVersion.Location = new System.Drawing.Point(4, 854);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(101, 22);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version 1.0";
            // 
            // btnParametres
            // 
            this.btnParametres.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnParametres.BackColor = System.Drawing.Color.AliceBlue;
            this.btnParametres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnParametres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnParametres.Location = new System.Drawing.Point(-2, 623);
            this.btnParametres.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnParametres.Name = "btnParametres";
            this.btnParametres.Size = new System.Drawing.Size(255, 65);
            this.btnParametres.TabIndex = 3;
            this.btnParametres.Text = "Importation";
            this.btnParametres.UseVisualStyleBackColor = false;
            // 
            // btnCarteParClasse
            // 
            this.btnCarteParClasse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCarteParClasse.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCarteParClasse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCarteParClasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnCarteParClasse.Location = new System.Drawing.Point(0, 298);
            this.btnCarteParClasse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCarteParClasse.Name = "btnCarteParClasse";
            this.btnCarteParClasse.Size = new System.Drawing.Size(255, 65);
            this.btnCarteParClasse.TabIndex = 2;
            this.btnCarteParClasse.Text = "Cartes par classe / niveau";
            this.btnCarteParClasse.UseVisualStyleBackColor = false;
            // 
            // btnCreerCarte
            // 
            this.btnCreerCarte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreerCarte.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCreerCarte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreerCarte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnCreerCarte.Location = new System.Drawing.Point(0, 446);
            this.btnCreerCarte.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreerCarte.Name = "btnCreerCarte";
            this.btnCreerCarte.Size = new System.Drawing.Size(255, 65);
            this.btnCreerCarte.TabIndex = 0;
            this.btnCreerCarte.Text = "Carte Provisoire";
            this.btnCreerCarte.UseVisualStyleBackColor = false;
            // 
            // frmAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2016, 1078);
            this.Controls.Add(this.pnlContent);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "frmAccueil";
            this.Load += new System.EventHandler(this.frmAccueil_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeMdp;
        private System.Windows.Forms.Button btnAfficheListeEleve;
        private System.Windows.Forms.Button btnTheme;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnParametres;
        private System.Windows.Forms.Button btnCarteParClasse;
        private System.Windows.Forms.Button btnCreerCarte;

        private System.Windows.Forms.Panel pnlContent;

        #endregion
    }
}