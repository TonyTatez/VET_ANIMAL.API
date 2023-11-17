using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoBaseNetCore.DTOs;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Services;
using ProyectoBaseNetCore.Utilities;

namespace ProyectoBaseNetCore.Controllers
{
    [ApiController]
    [Route("api/sync/")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SyncController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IAuthorizationService authorizationService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected SyncServices _service;
        private readonly ApplicationDbContext _context;

        public SyncController(ApplicationDbContext context, 
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
            this._service = new SyncServices(_context,configuration, userName, ip);
            
        }
        /// <summary>
        /// Sincronizacion de catalogos
        /// </summary>
        /// <remarks>
        /// Aqui se cargan los catalogos de clienes y mascotas
        /// </remarks>
        [HttpPost("Catalogos")]
        public async Task<IActionResult> SyncCatalogos([FromForm] IFormCollection formCollection) =>
            formCollection.Files.Count > 0 && formCollection.Files[0].Length > 0 ?
            Ok(await _service.SyncClientsAndPets(formCollection.Files[0])) :
            Ok(new ImportResponseDTO());

        
    }
}