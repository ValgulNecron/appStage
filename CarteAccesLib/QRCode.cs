using System.Drawing;
using QRCoder;

namespace CarteAccesLib
{
    /// <summary>
    /// Cette classe permet de créer un QRCode
    /// </summary>
    public static class QrCode
    {
        /// <summary>
        /// Cette fonction permet de créer un QRCode à partir d'une url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Bitmap CreationQrCode(string url)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}