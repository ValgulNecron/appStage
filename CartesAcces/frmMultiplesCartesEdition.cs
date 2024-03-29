﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using CarteAccesLib;
using LinqToDB;

namespace CartesAcces
{
    /*
     * Classe qui permet d'éditer les cartes d'accès
     * elle prend une liste d'élèves et permet de leur editer une carte
     */
    /// <summary>
    ///     Classe qui permet d'éditer les cartes d'accès
    ///     elle prend une liste d'élèves et permet de leur editer une carte
    /// </summary>
    public partial class FrmMultiplesCartesEdition : Form
    {
        /// <summary>
        ///     Constructeur de la classe
        /// </summary>
        public FrmMultiplesCartesEdition()
        {
            InitializeComponent();
            Couleur.setCouleurFenetre(this);
            labelEnCoursValidation.Visible = false;
            labelEnCoursValidation.ForeColor = Color.Red;
        }

        private void pbPhoto_MouseMove(object sender, MouseEventArgs e)
        {
            // -- Lorsque l'utilisateur clique sur la photo de l'élève --
            if (Edition.Drag)
            {
                // -- La position de la photo change --
                pbPhoto.Left = e.X + pbPhoto.Left - Edition.PosX;
                pbPhoto.Top = e.Y + pbPhoto.Top - Edition.PosY;
            }
        }

        private void pbPhoto_MouseDown(object sender, MouseEventArgs e)
        {
            // -- Lorsque l'utilisateur clic, la position initiale est sauvegardée, drag passe a true
            if (e.Button == MouseButtons.Left)
            {
                Edition.PosX = e.X;
                Edition.PosY = e.Y;
                Edition.Drag = true;
            }

            // -- Actualisation pour voir le déplacement en temps réel --
            Refresh();
        }

        private void pbPhoto_MouseUp(object sender, MouseEventArgs e)
        {
            // -- Le drag est fini lorsque le clic est relevé  --
            Edition.Drag = false;
        }

        private void tkbTaillePhoto_Scroll(object sender, EventArgs e)
        {
            if (pbPhoto != null)
            {
                // -- La largeur en pixel de la photo change et prend la valeur de la trackbar
                pbPhoto.Width = tkbTaillePhoto.Value;
                pbPhoto.Height = Convert.ToInt32(tkbTaillePhoto.Value * 1.5);
            }
        }


        // #### Rognage de l'emploi du temps ####
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                // -- Curseur en croix pour symboliser le mode selection
                Cursor = Cursors.Cross;

                // -- On est dans le mode selection
                Edition.SelectionClique = true;

                btnCancel.Enabled = true;
                btnSelect.Enabled = false;
            }
            catch
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // -- Le curseur revient à la normal --
            Cursor = Cursors.Default;

            // -- On est plus dans la selection --
            Edition.SelectionClique = false;

            // -- On remet les paramètres et l'image de base --
            Edt.ChercheEdtPerso(Globale.ListeEleveImpr, pbCarteArriere);
            Photo.AffichePhotoProvisoire("./data/edition.jpg", pbPhoto);

            btnSelect.Enabled = true;
            btnCancel.Enabled = false;
        }

        private void pbCarteArriere_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // -- Si le bouton selectionné est cliqué --
                if (Edition.SelectionClique)
                {
                    // -- Si il y a clic gauche --
                    if (e.Button == MouseButtons.Left)
                    {
                        // -- On prend les coordonnées de départ --
                        Edition.RognageX = e.X;
                        Edition.RognageY = e.Y;
                        Edition.RognagePen = new Pen(Color.Black, 1);
                        Edition.RognagePen.DashStyle = DashStyle.DashDotDot;
                    }

                    // -- Refresh constant pour avoir un apperçu pendant la selection --
                    pbCarteArriere.Refresh();
                }
            }
            catch
            {
            }
        }

        private void pbCarteArriere_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                // -- Si le bouton selection est cliqué --
                if (Edition.SelectionClique)
                {
                    // -- Si pas d'image, on sort --
                    if (pbCarteArriere.Image == null)
                        return;

                    // -- Glissement à la fin du premier clic gauche --
                    if (e.Button == MouseButtons.Left)
                    {
                        // -- On prend les dimensions a la fin du déplacement de la souris
                        pbCarteArriere.Refresh();
                        Edition.RognageLargeur = e.X - Edition.RognageX;
                        Edition.RognageHauteur = e.Y - Edition.RognageY;

                        Edition.RognageLargeur = Math.Abs(Edition.RognageLargeur);
                        Edition.RognageHauteur = Math.Abs(Edition.RognageHauteur);

                        pbCarteArriere.CreateGraphics().DrawRectangle(Edition.RognagePen,
                            Math.Min(Edition.RognageX, e.X),
                            Math.Min(Edition.RognageY, e.Y),
                            Math.Abs(Edition.RognageLargeur),
                            Math.Abs(Edition.RognageHauteur));
                    }
                }
            }
            catch
            {
            }
        }

        private void btnValiderImpr_Click(object sender, EventArgs e)
        {
            if (Globale.PositionPhotoClassique == false)
            {
                Edition.PosXDef = pbPhoto.Location.X;
                Edition.PosYDef = pbPhoto.Location.Y;
                Edition.PosHeightDef = pbPhoto.Height;
                Edition.PosWidthDef = pbPhoto.Width;
                MessageBox.Show("Veuillez placer la photo une seconde fois pour les emplois du temps classiques");
                pbCarteArriere.Image =
                    Image.FromFile("./data/FichierEdtClasse/" + Globale.ListeEleveImpr[0].ClasseEleve + ".jpg");
                Globale.PositionPhotoClassique = true;
                return;
            }

            Edition.ReplacementPhotoClassique(pbPhoto.Location.X, pbPhoto.Location.Y);


            try
            {
                // -- Si la liste est impaire, on double le dernier élève
                if (Globale.ListeEleveImpr.Count % 2 == 1)
                {
                    Globale.EleveImpr = true;
                    var eleve = Globale.ListeEleveImpr[Globale.ListeEleveImpr.Count - 1];
                    Globale.ListeEleveImpr.Add(eleve);
                }

                var cheminImpressionFinal = Chemin.setCheminImportationDossier();
                if (cheminImpressionFinal != "failed") labelEnCoursValidation.Visible = true;

                Globale.LblCount = lblCompteur;

                pbPhoto.Visible = false;
                // MessageBox.Show(cheminImpressionFinal); // la valeur renvoyé est "failed" en cas d'annulation
                FichierWord.SauvegardeCarteEnWord(cheminImpressionFinal, Globale.ListeEleveImpr, pbPhoto,
                    pbCarteArriere);
                pbPhoto.Visible = true;
                Globale.PositionPhotoClassique = false;

                var macAddress = string.Empty;
                foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                    if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                         nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
                        nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddress += nic.GetPhysicalAddress().ToString();
                        break;
                    }

                var log = new LogActions();
                log.DateAction = DateTime.Now;
                log.NomUtilisateur = Globale.NomUtilisateur;
                log.Action = "Création de cartes d'accès multiples ou personnalisées";
                log.AdMac = macAddress;
                ClassSql.Db.Insert(log);
                labelEnCoursValidation.Visible = false;
            }
            catch (Exception ex)
            {
                pbPhoto.Visible = true;
                MessageBox.Show(ex.Message);
            }
        }


        private void frmMultiplesCartesEdition_Load(object sender, EventArgs e)
        {
            lblCompteur.Visible = false;
            Edt.ChercheEdtPerso(Globale.ListeEleveImpr, pbCarteArriere);
            Photo.AffichePhotoProvisoire("./data/edition.jpg", pbPhoto);
        }

        private void pbCarteArriere_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (Edition.SelectionClique)
                {
                    if (pbCarteArriere.ClientRectangle.Contains(pbCarteArriere.PointToClient(MousePosition)))
                    {
                        Edition.RognageX = Math.Min(Edition.RognageX, e.X);
                        Edition.RognageY = Math.Min(Edition.RognageY, e.Y);
                        Cursor = Cursors.Default;
                        var pathEdt = Chemin.CheminEdt;
                        Edition.SelectionClique = false;
                        Edt.RognageEdt(pbCarteArriere, pathEdt);
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        Edition.SelectionClique = false;
                        pbCarteArriere.Image = Image.FromFile(Chemin.CheminEdt);
                        btnCancel.Enabled = false;
                        btnSelect.Enabled = true;

                        Edition.RognageX = 0;
                        Edition.RognageY = 0;
                        Edition.RognageHauteur = 0;
                        Edition.RognageLargeur = 0;
                    }
                }
            }
            catch
            {
            }
        }
    }
}