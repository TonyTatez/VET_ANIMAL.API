using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoBaseNetCore.DTOs;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Models;
using ProyectoBaseNetCore.Services;

namespace ProyectoBaseNetCore.Controllers
{
    [ApiController]
    [Route("api/tratamiento/")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TratamientoController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IAuthorizationService authorizationService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected TratamientoServices _service;
        private readonly ApplicationDbContext _context;

        public TratamientoController(ApplicationDbContext context, 
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
            this._service = new TratamientoServices(_context,configuration, userName, ip);
        }

        [HttpGet("historial")]
        public async Task<IActionResult> GetHistoriales() =>Ok(await _service.GetAllHitorialAsync());

        [HttpPost("historial")]
        public async Task<IActionResult> CrarHistorial(TratamientoDTO.HistoriaClinicDTO Historial) =>Ok(await _service.SaveHistorial(Historial));
          

        [HttpDelete("historial")]
        public async Task<IActionResult> EliminaCliente(long IdCliente) => Ok(await _service.DeleteHistorial(IdCliente));
    }
}