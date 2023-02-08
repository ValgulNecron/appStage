using System.Drawing;
using QRCoder;

namespace CarteAccesLib
{
    public static class QRCode
    {
        /*
         * Cette fonction permet de créer un QRCode à partir d'une url
         * @param url : l'url à encoder
         * @return un bitmap contenant le QRCode
         */
        public static Bitmap creationQRCode(string url)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCoder.QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}