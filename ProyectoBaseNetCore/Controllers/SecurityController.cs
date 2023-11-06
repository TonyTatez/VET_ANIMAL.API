using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectoBaseNetCore.DTOs.SecurityDTOs;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TMS_MANTENIMIENTO.API.DTOs;

namespace ProyectoBaseNetCore.Controllers
{
    [ApiController]
    [Route("api/Security")]
    public class SecurityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly HashService hashService;
        private readonly IDataProtector dataProtector;
        private string JWTKey { get; set; }

        public SecurityController(UserManager<ApplicationUser> userManager,
                                 IConfiguration configuration,
                                 SignInManager<ApplicationUser> signInManager,
                                 IDataProtectionProvider dataProtectionProvider,
                                 HashService hashService)
        {
            JWTKey = configuration["JWTKey"];
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.hashService = hashService;
            dataProtector = dataProtectionProvider.CreateProtector(JWTKey);
        }

        [HttpGet("encriptar")]
        public ActionResult Encriptar()
        {
            var textoPlano = "Geovanny Andrade";
            var textoCifrado = dataProtector.Protect(textoPlano);
            var textoDesencriptado = dataProtector.Unprotect(textoCifrado);
            return Ok(new
            {
                textoPlano,
                textoCifrado,
                textoDesencriptado
            });
        }

        [HttpGet("encriptarPorTiempo")]
        public ActionResult EncriptarPorTiempo()
        {
            var protectoLimitadoPorTiempo = dataProtector.ToTimeLimitedDataProtector();

            var textoPlano = "Geovanny Andrade";
            var textoCifrado = protectoLimitadoPorTiempo.Protect(textoPlano, lifetime: TimeSpan.FromSeconds(5));
            Thread.Sleep(TimeSpan.FromSeconds(6));
            var textoDesencriptado = protectoLimitadoPorTiempo.Unprotect(textoCifrado);
            return Ok(new
            {
                textoPlano,
                textoCifrado,
                textoDesencriptado
            });
        }

        [HttpGet("hash/{textoPlano}")]
        public ActionResult RealizarHash(string textoPlano)
        {
            var result1 = hashService.Hash(textoPlano);
            var result2 = hashService.Hash(textoPlano);
            return Ok(new
            {
                textoPlano,
                hash1 = result1,
                hash2 = result2,
            });
        }

        [HttpPost("registrar", Name = "registrarUsuario")]
        public async Task<ActionResult<RespuestaAutenticacion>> Registrar(CredencialesUsuario credencialesUsuario)
        {
            try
            {
                var usuario = new ApplicationUser { UserName = credencialesUsuario.Email, Email = credencialesUsuario.Email };
                usuario.FirstName = credencialesUsuario.Email;
                var resultado = await userManager.CreateAsync(usuario, credencialesUsuario.Password);

                if (resultado.Succeeded)
                {
                    return await ConstruirToken(credencialesUsuario);
                }
                else
                {
                    return BadRequest(resultado.Errors);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPost("login", Name = "loginUsuario")]
        public async Task<ActionResult<RespuestaAutenticacion>> Login(CredencialesUsuario credencialesUsuario)
        {
            var resultado = await signInManager.PasswordSignInAsync(credencialesUsuario.Email,
                                                                    credencialesUsuario.Password,
                                                                    isPersistent: false,
                                                                    lockoutOnFailure: false);
            if (resultado.Succeeded)
            {
                return await ConstruirToken(credencialesUsuario);
            }
            else
            {
                return BadRequest("Login incorrecto");
            }
        }

        [HttpGet("RenovarToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<RespuestaAutenticacion>> Renovar()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;

            var credencialesUsuario = new CredencialesUsuario()
            {
                Email = email,
            };

            return await ConstruirToken(credencialesUsuario);
        }

        //Generar Hash y Token
        private async Task<RespuestaAutenticacion> ConstruirToken(CredencialesUsuario credencialesUsuario)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", credencialesUsuario.Email),
            };

            var usuario = await userManager.FindByEmailAsync(credencialesUsuario.Email);
            var claimsDB = await userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsDB);

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTKey"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddYears(1);

            var securtityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);

            return new RespuestaAutenticacion()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securtityToken),
                Expiracion = expiracion,
            };
        }

        [HttpPost("HacerAdmin")]
        public async Task<ActionResult> HacerAdmin(EditarAdminDTO editarAdminDTO)
        {
            var usuario = await userManager.FindByEmailAsync(editarAdminDTO.Email);
            await userManager.AddClaimAsync(usuario, new Claim("esAdmin", "1"));
            return NoContent();
        }

        [HttpPost("RemoverAdmin")]
        public async Task<ActionResult> RemoverAdmin(EditarAdminDTO editarAdminDTO)
        {
            var usuario = await userManager.FindByEmailAsync(editarAdminDTO.Email);
            await userManager.RemoveClaimAsync(usuario, new Claim("esAdmin", "1"));
            return NoContent();
        }

        [HttpGet("ValidateToken")]
        public async Task<ActionResult> ValidateTokenUser(string token)
        {
            try
            {
                var validateToken = await ValidateToken(token);
                if (validateToken is null)
                {
                    return BadRequest("Token no valido");
                }
                return Ok(validateToken);
            }
            catch (Exception)
            {
                return BadRequest("Token no valido");
            }
        }

        private Task<string> ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["llavejwt"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "email").Value;

                // return user id from JWT token if validation successful
                return Task.FromResult(userId);
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassword(CredencialesUsuario credencialesUsuario)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(credencialesUsuario.Email);
            if (user == null)
            {
                return NotFound();
            }
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, credencialesUsuario.Password);
            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest("Ocurrio un error al cmabiar su contraseña");
                //throw exception......
            }
            return Ok("Contraseña actualizada con exito!");
        }
    }
}