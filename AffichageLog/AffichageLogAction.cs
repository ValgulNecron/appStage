using System;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;
using CartesAcces;

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
            foreach(LogActions log in ClassSql.Db.GetTable<LogActions>().ToList())
                listBox1.Items.Add(log.DateAction + " " + log.Action + " " + log.AdMac + " " + log.NomUtilisateur);
        }
    }
}    