using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.DTOs;
using ProyectoBaseNetCore.DTOs.SecurityDTOs;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Services;
using System.Net.Sockets;
using System.Security.Claims;

namespace ProyectoBaseNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SocketController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly LinqHelper linqHelper;

        private SocketController(IHubContext<ChatHub> hubContext, UserManager<ApplicationUser> userManager, IMapper mapper, LinqHelper linqHelper)
        {
            _hubContext = hubContext;
            this.userManager = userManager;
            this.mapper = mapper;
            this.linqHelper = linqHelper;
        }

        [AllowAnonymous]
        [HttpPost("EnviarMensajeATodos")]
        private IActionResult EnviarMensajeATodos([FromBody] MensajeSocketDTO mensaje)
        {
            _hubContext.Clients.All.SendAsync("RecibirMensaje", mensaje.Usuario, mensaje.Contenido);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("UsuarioConectado")]
        private IActionResult UsuarioConectado()
        {
            //string username = User.Identity.Name;
            string username = "geo@smoke.com";
            bool isConnected = ChatHub.IsUserConnected(username);
            return Ok(new { Usuario = username, Conectado = isConnected });
        }

        [AllowAnonymous]
        [HttpGet("ListaDeUsuarios")]
        private async Task<IActionResult> ListaDeUsuariosAsync() => Ok(await linqHelper.GetMappedListAsync<ApplicationUser, UserInfoDTO>(await userManager.Users.ToListAsync(), x => true));

        [AllowAnonymous]
        [HttpPost("EnviarMensajeAGrupo")]
        private async Task<IActionResult> EnviarMensajeAGrupo([FromBody] MensajeSocketDTO mensaje)
        {
            string contenido = mensaje.Contenido;
            await _hubContext.Clients.Group(mensaje.Grupo).SendAsync("RecibirMensaje", mensaje.Usuario, mensaje.Contenido);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("EnviarMensajeAUsuario")]
        private async Task<IActionResult> EnviarMensajeAUsuario([FromBody] MensajeSocketDTO mensaje)
        {
            var user = await userManager.FindByNameAsync(mensaje.UsuarioDestino);
            if (user is not null)
            {
                await _hubContext.Clients.User(user.Id).SendAsync("RecibirMensaje", mensaje.Usuario, mensaje.Contenido);
                return Ok();
            }
            else
            {
                return NotFound("Usuario no encontrado");
            }
        }

        [HttpPost("EnviarMensaje")]
        private async Task<IActionResult> EnviarMensaje([FromBody] MensajeSocketDTO mensaje)
        {
            var user = await userManager.FindByNameAsync(ClaimTypes.NameIdentifier);
            var client = await userManager.FindByNameAsync(mensaje.UsuarioDestino);
            if (client is not null)
            {
                await _hubContext.Clients.User(client.Id).SendAsync("RecibirMensaje", user.UserName, mensaje.Contenido);
                return Ok();
            }
            else
            {
                return NotFound("Usuario no encontrado");
            }
        }
    }
}