using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoBaseNetCore.Services;

namespace ProyectoBaseNetCore.Controllers
{
    [ApiController]
    [Route("api/qrcode")]
    public class QRCodeController : ControllerBase
    {
        private readonly QRCodeService _QRCodeService;

        public QRCodeController(QRCodeService qrCodeService)
        {
            _QRCodeService = qrCodeService;
        }
        [Route("generate")]
        [HttpGet]
        public IActionResult GenerateQrCode(string content)
        {
            byte[] qrCodeBytes = _QRCodeService.GenerateQrCode(content);
            return File(qrCodeBytes, "image/png"); // Devuelve la imagen como un archivo binario PNG
        }
    }
}
