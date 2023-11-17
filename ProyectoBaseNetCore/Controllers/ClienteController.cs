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
    [Route("api/cat")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClienteController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IAuthorizationService authorizationService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected ClienteService _service;
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context, 
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
            this._service = new ClienteService(_context,configuration, userName, ip);
        }

        [HttpGet("Clientes")]
        public async Task<IActionResult> GetClientes() =>Ok(await _service.GetCliente());

        [HttpGet("NumeroClientes")]
        public async Task<IActionResult> GetNumeroClientes() => Ok(await _service.GetNumeroClientes());

        [HttpGet("Cliente")]
        public async Task<IActionResult> GetCliente([FromQuery] string CI) => Ok(await _service.GetClientByCI(CI));
        [HttpPut("Cliente")]
        public async Task<IActionResult> GetCliente(ClienteDTO Cliente) => Ok(await _service.EditCliente(Cliente));

        [HttpPost("Cliente")]
        public async Task<IActionResult> NuevoCliente(GuardarClienteViewModel Cliente) =>Ok(await _service.SaveCliente(Cliente));
          

        [HttpDelete("Cliente")]
        public async Task<IActionResult> EliminaCliente(long IdCliente) => Ok(await _service.DeleteCliente(IdCliente));
        [HttpGet("Cliente/mascotas")]
        public async Task<IActionResult> GetMascotasClientes([FromQuery] string CI) => Ok(await _service.GetMascotasCliente(CI));



    }
}