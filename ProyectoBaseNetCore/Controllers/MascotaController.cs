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
    [Route("api/cat/")]
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

        [HttpGet("Mascotas")]
        public async Task<IActionResult> GetMascotas() =>Ok(await _service.GetAllMascotasAsync());

        [HttpGet("Mascota")]
        public async Task<IActionResult> GetMascota(long IdMascota) => Ok(await _service.GetMascotaById(IdMascota));

        [HttpPost("Mascota")]
        public async Task<IActionResult> NuevaMascota(MascotaDTO Data) =>Ok(await _service.SaveMascota(Data));

        [HttpPut("Mascota")]
        public async Task<IActionResult> EditMascota(MascotaDTO Data) => Ok(await _service.EdirtMascotaAsync(Data));


        [HttpDelete("Mascota")]
        public async Task<IActionResult> EliminaMascota(long IdMascota) => Ok(await _service.DeleteMascota(IdMascota));
    }
}