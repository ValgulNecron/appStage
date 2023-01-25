using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CarteAcces;

namespace CartesAcces
{
    public partial class frmRognageEdtClassique : Form
    {
        public frmRognageEdtClassique()
        {
            InitializeComponent();
        }

        private void frmRognageEdtClassique_Load(object sender, EventArgs e)
        {
            List<string> listeFichiers = new List<string>();
            listeFichiers.AddRange(Directory.GetFiles(Globale._cheminEdtClassique));
            pbEdtClassique.Image = Image.FromFile(listeFichiers[0]);
            Edt.rognageEdt(pbEdtClassique, Globale._cheminEdtClassique);
        }
    }
}