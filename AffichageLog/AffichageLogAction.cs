using System;
using System.Linq;
using System.Windows.Forms;
using CartesAcces;
using LinqToDB;

namespace AffichageLog
{
    public partial class AffichageLogAction : Form
    {
        public AffichageLogAction()
        {
            InitializeComponent();
        }

        private void AffichageLogAction_Load(object sender, EventArgs e)
        {
            foreach (var log in ClassSql.Db.GetTable<LogActions>().ToList())
                listBox1.Items.Add(log.DateAction + " " + log.Action + " " + log.AdMac + " " + log.NomUtilisateur);
        }
    }
}