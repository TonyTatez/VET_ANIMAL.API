using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Spreadsheet;
using ProyectoBaseNetCore.DTOs;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Utilities;
using static ProyectoBaseNetCore.DTOs.TratamientoDTO;

namespace ProyectoBaseNetCore.Services
{
    public class TratamientoServices
    {
        private static string _usuario;
        private static string _ip;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly GeneratorCodeHelper COD ;
        public TratamientoServices(ApplicationDbContext context, IConfiguration configuration, string ip, string usuario)
        {
            _context = context;
            this.configuration = configuration;
            _ip = ip;
            _usuario = usuario;
            COD = new GeneratorCodeHelper(context, configuration, ip, usuario);
        }
        public async Task<List<TratamientoDTO.HistoriaClinicDTO>> GetAllHitorialAsync() => await _context.HistoriaClinica
            .Where(x => x.Activo).Select(x => new TratamientoDTO.HistoriaClinicDTO
            {
                CodigoHistorial = x.CodigoHistorial,
                Mascota = x.Mascota.NombreMascota,
                Raza = x.Mascota.Raza,
                FechaNacimiento = x.Mascota.FechaNacimiento,
                Sexo = x.Mascota.Sexo,
                Cliente= x.Mascota.Cliente.Nombres,
                CODMascota = x.Mascota.Codigo,
            }).ToListAsync();


        public async Task<ClienteDTO> GetIdCliente(string Ruc) => await _context.Cliente
            .Where(x => x.Activo && x.Identificacion == Ruc).Select(x => new ClienteDTO
            {
                idCliente = x.IdCliente,
                identificacion = x.Identificacion,
                nombres = x.Nombres,
                //Apellidos = x.Codigo,
                direccion = x.Direccion,
                telefono = x.Telefono,
            }).FirstOrDefaultAsync();

        public async Task<bool> SaveHistorial(TratamientoDTO.HistoriaClinicDTO Historial)
        {
            var CurrentHistory = await _context.HistoriaClinica.FirstOrDefaultAsync(x => x.IdMascotas == Historial.IdMascota || x.CodigoHistorial == Historial.CodigoHistorial);
            if (CurrentHistory == null)
            {
                var codigo = await COD.GetOrCreateCodeAsync("HTC");
                HistoriaClinica NewHistory = new HistoriaClinica();
                NewHistory.CodigoHistorial = codigo;
                NewHistory.IdMascotas = Historial.IdMascota;
               
                NewHistory.Activo = true;
                NewHistory.FechaRegistro = DateTime.Now;
                NewHistory.UsuarioRegistro = _usuario;
                NewHistory.IpRegistro = _ip;
                await _context.HistoriaClinica.AddAsync(NewHistory);
                await _context.SaveChangesAsync();
            }
            else
            {
                CurrentHistory.IdMascotas = Historial.IdMascota;
                CurrentHistory.Activo = true;
                CurrentHistory.FechaModificacion = DateTime.Now;
                CurrentHistory.UsuarioModificacion = _usuario;
                CurrentHistory.IpModificacion = _ip;
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteHistorial(long IdCliente)
        {
            try
            {
                var ClienteEncontrada = await _context.HistoriaClinica.FindAsync(IdCliente);
                if (ClienteEncontrada != null)
                {
                    ClienteEncontrada.Activo = false;
                    ClienteEncontrada.FechaEliminacion = DateTime.Now;
                    ClienteEncontrada.UsuarioEliminacion = _usuario;
                    ClienteEncontrada.IpEliminacion = _ip;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}