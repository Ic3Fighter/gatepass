using QRCoder;

namespace GatePass.Business.BusinessProviders
{
    public static class QrCodeBusinessProvider
    {
        public static byte[] Encode(string text)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new BitmapByteQRCode(qrCodeData);

            return qrCode.GetGraphic(20);
        }
    }
}