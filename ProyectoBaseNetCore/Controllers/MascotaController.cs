using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoBaseNetCore.DTOs;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Services;

namespace ProyectoBaseNetCore.Controllers
{
    [ApiController]
    [Route("api/Mascota/")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MascotaController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IAuthorizationService authorizationService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected MascotaServices _service;
        private readonly ApplicationDbContext _context;

        public MascotaController(ApplicationDbContext context, 
            IConfiguration configuration, 
            IAuthorizationService Authorization, 
            UserManager<ApplicationUser> userManager, 
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.authorizationService = Authorization;
            this.configuration = configuration;
            this.userManager = userManager;
            this._httpContextAccessor = httpContextAccessor;
            string userName = Task.Run(async () => await userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "email").Value)).Result.UserName;
            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            this._service = new MascotaServices(_context,configuration, userName, ip);
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> GetMascota() =>Ok(await _service.GetAllMascotasAsync());

        [HttpPost("Crear")]
        public async Task<IActionResult> NuevaMascota(MascotaDTO Data) =>Ok(await _service.SaveMascota(Data));
          
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> EliminaMascota(long IdCliente) => Ok(await _service.DeleteMascota(IdCliente));
    }
}