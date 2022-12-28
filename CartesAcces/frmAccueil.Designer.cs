
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
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccueil));
            this.btnCreerCarte = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnParametres = new System.Windows.Forms.Button();
            this.btnCarteParClasse = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreerCarte
            // 
            this.btnCreerCarte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreerCarte.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCreerCarte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreerCarte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreerCarte.Location = new System.Drawing.Point(0, 339);
            this.btnCreerCarte.Name = "btnCreerCarte";
            this.btnCreerCarte.Size = new System.Drawing.Size(170, 42);
            this.btnCreerCarte.TabIndex = 0;
            this.btnCreerCarte.Text = "Carte Provisoire";
            this.btnCreerCarte.UseVisualStyleBackColor = false;
            this.btnCreerCarte.Click += new System.EventHandler(this.btnCreerCarte_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlMenu.Controls.Add(this.btnParametres);
            this.pnlMenu.Controls.Add(this.btnCarteParClasse);
            this.pnlMenu.Controls.Add(this.btnCreerCarte);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(170, 701);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnParametres
            // 
            this.btnParametres.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnParametres.BackColor = System.Drawing.Color.AliceBlue;
            this.btnParametres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnParametres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParametres.Location = new System.Drawing.Point(0, 216);
            this.btnParametres.Name = "btnParametres";
            this.btnParametres.Size = new System.Drawing.Size(170, 42);
            this.btnParametres.TabIndex = 3;
            this.btnParametres.Text = "Gestion des données";
            this.btnParametres.UseVisualStyleBackColor = false;
            this.btnParametres.Click += new System.EventHandler(this.btnParametres_Click);
            // 
            // btnCarteParClasse
            // 
            this.btnCarteParClasse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCarteParClasse.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCarteParClasse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCarteParClasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarteParClasse.Location = new System.Drawing.Point(0, 277);
            this.btnCarteParClasse.Name = "btnCarteParClasse";
            this.btnCarteParClasse.Size = new System.Drawing.Size(170, 42);
            this.btnCarteParClasse.TabIndex = 2;
            this.btnCarteParClasse.Text = "Multiples Cartes\r\n";
            this.btnCarteParClasse.UseVisualStyleBackColor = false;
            this.btnCarteParClasse.Click += new System.EventHandler(this.btnCarteParClasse_Click);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreerCarte;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnCarteParClasse;
        private System.Windows.Forms.Button btnParametres;
    }
}

