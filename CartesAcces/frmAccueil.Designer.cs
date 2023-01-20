
namespace CartesAcces
{
    partial class frmAccueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccueil));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnCreerCarte = new System.Windows.Forms.Button();
            this.btnCarteParClasse = new System.Windows.Forms.Button();
            this.btnParametres = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnChangeMdp = new System.Windows.Forms.Button();
            this.btnAfficheListeEleve = new System.Windows.Forms.Button();
            this.btnTheme = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(170, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1174, 701);
            this.pnlContent.TabIndex = 3;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // btnCreerCarte
            // 
            this.btnCreerCarte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreerCarte.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCreerCarte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreerCarte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreerCarte.Location = new System.Drawing.Point(0, 176);
            this.btnCreerCarte.Name = "btnCreerCarte";
            this.btnCreerCarte.Size = new System.Drawing.Size(170, 42);
            this.btnCreerCarte.TabIndex = 0;
            this.btnCreerCarte.Text = "Carte Provisoire";
            this.btnCreerCarte.UseVisualStyleBackColor = false;
            this.btnCreerCarte.Click += new System.EventHandler(this.btnCreerCarte_Click);
            // 
            // btnCarteParClasse
            // 
            this.btnCarteParClasse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCarteParClasse.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCarteParClasse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCarteParClasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarteParClasse.Location = new System.Drawing.Point(0, 133);
            this.btnCarteParClasse.Name = "btnCarteParClasse";
            this.btnCarteParClasse.Size = new System.Drawing.Size(170, 42);
            this.btnCarteParClasse.TabIndex = 2;
            this.btnCarteParClasse.Text = "Multiples Cartes\r\n";
            this.btnCarteParClasse.UseVisualStyleBackColor = false;
            this.btnCarteParClasse.Click += new System.EventHandler(this.btnCarteParClasse_Click);
            // 
            // btnParametres
            // 
            this.btnParametres.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnParametres.BackColor = System.Drawing.Color.AliceBlue;
            this.btnParametres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnParametres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParametres.Location = new System.Drawing.Point(0, 324);
            this.btnParametres.Name = "btnParametres";
            this.btnParametres.Size = new System.Drawing.Size(170, 42);
            this.btnParametres.TabIndex = 3;
            this.btnParametres.Text = "Paramètres";
            this.btnParametres.UseVisualStyleBackColor = false;
            this.btnParametres.Click += new System.EventHandler(this.btnParametres_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlMenu.Controls.Add(this.btnChangeMdp);
            this.pnlMenu.Controls.Add(this.btnAfficheListeEleve);
            this.pnlMenu.Controls.Add(this.btnTheme);
            this.pnlMenu.Controls.Add(this.lblVersion);
            this.pnlMenu.Controls.Add(this.btnParametres);
            this.pnlMenu.Controls.Add(this.btnCarteParClasse);
            this.pnlMenu.Controls.Add(this.btnCreerCarte);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(170, 701);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnChangeMdp
            // 
            this.btnChangeMdp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChangeMdp.BackColor = System.Drawing.Color.AliceBlue;
            this.btnChangeMdp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangeMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeMdp.Location = new System.Drawing.Point(0, 367);
            this.btnChangeMdp.Name = "btnChangeMdp";
            this.btnChangeMdp.Size = new System.Drawing.Size(170, 42);
            this.btnChangeMdp.TabIndex = 7;
            this.btnChangeMdp.Text = "Changer le mot de passe";
            this.btnChangeMdp.UseVisualStyleBackColor = false;
            this.btnChangeMdp.Click += new System.EventHandler(this.btnChangeMdp_Click);
            // 
            // btnAfficheListeEleve
            // 
            this.btnAfficheListeEleve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAfficheListeEleve.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAfficheListeEleve.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAfficheListeEleve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfficheListeEleve.Location = new System.Drawing.Point(0, 219);
            this.btnAfficheListeEleve.Name = "btnAfficheListeEleve";
            this.btnAfficheListeEleve.Size = new System.Drawing.Size(170, 42);
            this.btnAfficheListeEleve.TabIndex = 6;
            this.btnAfficheListeEleve.Text = "Liste d\'élève";
            this.btnAfficheListeEleve.UseVisualStyleBackColor = false;
            this.btnAfficheListeEleve.Click += new System.EventHandler(this.btnAfficheListeEleve_Click);
            // 
            // btnTheme
            // 
            this.btnTheme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTheme.BackColor = System.Drawing.Color.AliceBlue;
            this.btnTheme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheme.Location = new System.Drawing.Point(0, 410);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(170, 42);
            this.btnTheme.TabIndex = 5;
            this.btnTheme.Text = "Changer le thème";
            this.btnTheme.UseVisualStyleBackColor = false;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(3, 679);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 13);
            this.lblVersion.TabIndex = 0;
            // 
            // frmAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1344, 701);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccueil";
            this.Text = "Application Cartes Acces";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAccueil_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnChangeMdp;

        private System.Windows.Forms.Button btnAfficheListeEleve;

        private System.Windows.Forms.Button btnTheme;

        #endregion
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnCreerCarte;
        private System.Windows.Forms.Button btnCarteParClasse;
        private System.Windows.Forms.Button btnParametres;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblVersion;
    }
}

