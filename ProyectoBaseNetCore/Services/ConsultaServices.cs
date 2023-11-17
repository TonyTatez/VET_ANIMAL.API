using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Spreadsheet;
using ProyectoBaseNetCore.DTOs;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Utilities;
using VET_ANIMAL_API.DTOs;
using VET_ANIMAL_API.Entities;

namespace ProyectoBaseNetCore.Services
{
    public class ConsultaServices
    {
        private static string _usuario;
        private static string _ip;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly GeneratorCodeHelper COD;
        public ConsultaServices(ApplicationDbContext context, IConfiguration configuration, string ip, string usuario)
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
                IdHistoriaClinica = x.IdHistoriaClinica,
                CodigoHistorial = x.CodigoHistorial,
                Mascota = x.Mascota.NombreMascota,
                Raza = x.Mascota.Raza,
                FechaNacimiento = x.Mascota.FechaNacimiento,
                Sexo = x.Mascota.Sexo,
                Cliente = x.Mascota.Cliente.Nombres,
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

        public async Task<bool> SaveHistorial(long IdMascota)
        {
            var CurrentHistory = await _context.HistoriaClinica.FirstOrDefaultAsync(x => x.IdMascotas == IdMascota);
            if (CurrentHistory is not null) throw new Exception("Ya existe un historial para esta mascota!");
            var codigo = await COD.GetOrCreateCodeAsync("HTC");
            HistoriaClinica NewHistory = new HistoriaClinica();
            NewHistory.CodigoHistorial = codigo;
            NewHistory.IdMascotas = IdMascota;

            NewHistory.Activo = true;
            NewHistory.FechaRegistro = DateTime.Now;
            NewHistory.UsuarioRegistro = _usuario;
            NewHistory.IpRegistro = _ip;
            await _context.HistoriaClinica.AddAsync(NewHistory);
            await _context.SaveChangesAsync();
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

        public async Task<List<FichaControlDTO>> GetAllfichasControlAsync() => await _context.FichaControl
           .Where(x => x.Activo).Select(x => new FichaControlDTO
           {
               IdFichaControl = x.IdFichaControl,
               Peso = x.Peso,
               Motivo = x.MotivoConsulta.Nombre,
               Observacion = x.Observacion,
           }).ToListAsync();
        public async Task<bool> SaveFichaControlAsync(FichaControlDTO Ficha)
        {

            if (Ficha.IdMotivo <= 0) throw new Exception("Debe registrar un motivo consulta!");

            var codigo = await COD.GetOrCreateCodeAsync("FC");
            FichaControl NewFControl = new FichaControl();
            NewFControl.CodigoFichaControl = codigo;
            NewFControl.IdMotivo = Ficha.IdMotivo;
            NewFControl.Peso = Ficha.Peso;
            NewFControl.Observacion = Ficha.Observacion;

            NewFControl.Activo = true;
            NewFControl.FechaRegistro = DateTime.Now;
            NewFControl.UsuarioRegistro = _usuario;
            NewFControl.IpRegistro = _ip;
            await _context.FichaControl.AddAsync(NewFControl);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> EditFichaControlAsync(FichaControlDTO Ficha)
        {
            if (Ficha.IdMotivo <= 0) throw new Exception("Debe registrar un motivo consulta!");
            var CurrentFicha = await  _context.FichaControl.FindAsync(Ficha.IdFichaControl);
            CurrentFicha.IdMotivo = Ficha.IdMotivo;
            CurrentFicha.Peso = Ficha.Peso;
            CurrentFicha.Observacion = Ficha.Observacion;
            CurrentFicha.Activo = true;
            CurrentFicha.FechaModificacion = DateTime.Now;
            CurrentFicha.UsuarioModificacion = _usuario;
            CurrentFicha.IpModificacion = _ip;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}