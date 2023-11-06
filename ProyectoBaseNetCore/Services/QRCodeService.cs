using QRCoder;

namespace ProyectoBaseNetCore.Services
{
    public class QRCodeService
    {
        public byte[] GenerateQrCode(string content)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

            byte[] qrCodeBytes = qrCode.GetGraphic(20); // Ajusta el tamaño según tus necesidades

            return qrCodeBytes;
        }
    }
}
