using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace CartesAcces
{
    /// <summary>
    /// Dialogue de téléchargement des mises à jour de l'application
    /// </summary>
    public class DownloadDialog : Form
    {
        private readonly Button _cancelButton;

        private readonly WebClient _client;
        private readonly string _downloadUrl;
        private readonly Label _percentageLabel;
        private readonly ProgressBar _progressBar;
        private readonly Label _speedLabel;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="downloadUrl"></param>
        public DownloadDialog(string downloadUrl)
        {
            _downloadUrl = downloadUrl;

            _client = new WebClient();
            _client.DownloadProgressChanged += OnDownloadProgressChanged;
            _client.DownloadFileCompleted += OnDownloadFileCompleted;

            _progressBar = new ProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Value = 0,
                Dock = DockStyle.Top
            };

            _percentageLabel = new Label
            {
                Text = "0 %",
                Dock = DockStyle.Top
            };

            _speedLabel = new Label
            {
                Text = "0 KB/s",
                Dock = DockStyle.Top
            };

            _cancelButton = new Button
            {
                Text = "Annuler",
                DialogResult = DialogResult.Cancel,
                Enabled = false,
                Dock = DockStyle.Bottom
            };

            Controls.Add(_cancelButton);
            Controls.Add(_speedLabel);
            Controls.Add(_percentageLabel);
            Controls.Add(_progressBar);

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Téléchargement de la mise à jour en cours...";
            Size = new Size(300, 150);
        }

        /// <summary>
        /// Lorsque le dialogue est chargé, on lance le téléchargement
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _client.DownloadFileAsync(new Uri(_downloadUrl), Globale.FileName);
        }

        /// <summary>
        /// Lorsque le dialogue est fermé, on annule le téléchargement
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                _client.CancelAsync();
            }
        }

        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _progressBar.Value = e.ProgressPercentage;
            _percentageLabel.Text = $"{e.ProgressPercentage} %";

                double speed = e.BytesReceived / (e.ProgressPercentage / 100.0) / 1024.0;
                _speedLabel.Text = $"{e.BytesReceived} / {e.TotalBytesToReceive} octets ({speed:N2} Ko/s)";
        }

        private void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)    
            {
                MessageBox.Show("Le téléchargement a été annulé.", "Téléchargement annulé", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
            }
            else if (e.Error != null)
            {
                MessageBox.Show(
                    "Une erreur s'est produite lors du téléchargement de la mise à jour. Veuillez réessayer plus tard.",
                    "Erreur de téléchargement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                MessageBox.Show(
                    "Le téléchargement de la mise à jour est terminé. Le programme va se fermer pour effectuer la mise à jour.",
                    "Téléchargement terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }
    }
}