using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.Entities;

namespace ProyectoBaseNetCore.Utilities
{
    public class GeneratorCodeHelper
    {

        private static string _usuario;
        private static string _ip;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        public GeneratorCodeHelper(ApplicationDbContext context, IConfiguration configuration, string ip, string usuario)
        {
            _context = context;
            this.configuration = configuration;
            _ip = ip;
            _usuario = usuario;
        }
        public async Task<string> GetOrCreateCodeAsync( string code)
        {
            var existingCode = await _context.CodigosSecuencia.FirstOrDefaultAsync(c => c.Codigo == code);

            if (existingCode != null)
            {
                existingCode.UltimoNumero = existingCode.UltimoNumero + 1;
                await _context.SaveChangesAsync();
                return existingCode.Codigo + "-" + DateTime.Now.Year.ToString() + "-" + (existingCode.UltimoNumero).ToString("D9");
            }
            else
            {
                var newCode = new CodigosSecuencia
                {
                    Codigo = code,
                    UltimoNumero= 1,
                    FechaRegistro= DateTime.Now,
                    UsuarioRegistro= _usuario,
                    IpRegistro= _ip,
                };

                await _context.CodigosSecuencia.AddAsync(newCode);
                await _context.SaveChangesAsync();

                return newCode.Codigo + "-" + DateTime.Now.Year.ToString() + "-" + (newCode.UltimoNumero).ToString("D9");
            }
        }
    }
}
