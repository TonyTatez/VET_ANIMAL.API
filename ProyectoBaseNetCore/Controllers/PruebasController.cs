using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoBaseNetCore.Controllers
{
    [ApiController]
    [Route("api/pruebas")]
    public class PruebasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IAuthorizationService authorizationService;

        public PruebasController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration, IAuthorizationService authorizationService)
        {
            this.context = context;
            this.mapper = mapper;
            this.configuration = configuration;
            this.authorizationService = authorizationService;
        }

        [HttpPost("EnvioImagenes")]
        public async Task<ActionResult> GetListaAutores(List<string> imagenesbase64)
        {
            return await Task.Run(() => Ok($"se subieron {imagenesbase64.Count} imagenes"));
        }
    }
}