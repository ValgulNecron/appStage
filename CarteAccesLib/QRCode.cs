using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;


namespace CarteAccesLib
{
    public static class QRCode
    {
        static public Bitmap creationQRCode(string url)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCoder.QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}