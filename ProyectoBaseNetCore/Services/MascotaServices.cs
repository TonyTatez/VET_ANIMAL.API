using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.DTOs;
using ProyectoBaseNetCore.Entities;

namespace ProyectoBaseNetCore.Services
{
    public class MascotaServices
    {
        private static string _usuario;
        private static string _ip;
        private readonly ApplicationDbContext _context;
        private readonly ConsultaServices _consultaService;
        private readonly IConfiguration configuration;
        public MascotaServices(ApplicationDbContext context, IConfiguration configuration, string ip, string usuario)
        {
            _context = context;
            this.configuration = configuration;
            _ip = ip;
            _usuario = usuario;
            _consultaService = new ConsultaServices(context,configuration,ip,usuario);
        }



        public async Task<List<ViewMascota>> GetAllMascotasAsync() => await _context.HistoriaClinica
            .Where(x => x.Activo).Select(x => new ViewMascota
            {
                IdHistoriaClinica = x.IdHistoriaClinica,
                CodigoHistorial = x.CodigoHistorial,
                NombreMascota = x.Mascota.NombreMascota,
                Cedula = x.Mascota.Cliente.Identificacion,
                Raza = x.Mascota.Raza,
                FechaNacimiento = x.Mascota.FechaNacimiento,
                Sexo = x.Mascota.Sexo,
                Cliente = x.Mascota.Cliente.Nombres,
                CODMascota = x.Mascota.Codigo,
                Peso = x.Mascota.Peso,
                IdMascota = x.Mascota.IdMascota,
                IdCliente = x.Mascota.Cliente.IdCliente,
            }).ToListAsync();


        public async Task<MascotaDTO> GetMascotaById(long IdMascota) => await _context.Mascota.Where(x => x.Activo && x.IdMascota == IdMascota).Select(x => new MascotaDTO
        {
            IdMascota = x.IdMascota,
            NombreMascota = x.NombreMascota,
            IdCliente = x.IdCliente,
            Cliente = x.Cliente.Nombres,
            Raza = x.Raza,
            Peso = x.Peso,
            Sexo = x.Sexo,
            FechaNacimiento = x.FechaNacimiento,
        }).FirstOrDefaultAsync();



        public async Task<bool> SaveMascota(MascotaDTO Data)
        {
            try
            {
                // Validación del idCliente
                if (Data.IdCliente <= 0) throw new ArgumentException("Cedula de Cliente no encontrada o invalida");
                

                // Búsqueda de Mascota Existente
                var CurrentPet = await _context.Mascota
                    .Where(x => x.Activo && x.NombreMascota == Data.NombreMascota && x.IdCliente == Data.IdCliente)
                    .FirstOrDefaultAsync();

                // Verificación y excepción si la mascota ya existe
                if (CurrentPet is not null) throw new Exception("Ya existe una mascota registrada con ese nombre para este cliente!");
                

                // Creación de una Nueva Mascota
                Mascota NewPet = new Mascota();
                NewPet.NombreMascota = Data.NombreMascota;
                NewPet.Codigo = Data.CODMascota;
                NewPet.IdCliente = Data.IdCliente;
                NewPet.Raza = Data.Raza;
                NewPet.Peso = Data.Peso;
                NewPet.FechaNacimiento = Data.FechaNacimiento;
                NewPet.Sexo = Data.Sexo;
                NewPet.Activo = true;
                NewPet.FechaRegistro = DateTime.UtcNow;
                NewPet.UsuarioRegistro = _usuario;
                NewPet.IpRegistro = _ip;

                // Guardado en la Base de Datos
                await _context.Mascota.AddAsync(NewPet);
                await _context.SaveChangesAsync();
                await _consultaService.SaveHistorial(NewPet.IdMascota);

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones y retorno de false
                throw;
            }
        }

        public async Task<bool> EdirtMascotaAsync(MascotaDTO Data)
        {
            try
            {

                var CurrentPet = await _context.Mascota.FindAsync(Data.IdMascota);
                if (CurrentPet == null) throw new Exception("Mascota no encontrada!");

                CurrentPet.NombreMascota = Data.NombreMascota;
                CurrentPet.Codigo = Data.CODMascota;
                CurrentPet.IdCliente = Data.IdCliente;
                CurrentPet.Raza = Data.Raza;
                CurrentPet.Peso = Data.Peso;
                CurrentPet.FechaNacimiento = Data.FechaNacimiento;
                CurrentPet.Sexo = Data.Sexo;
                CurrentPet.Activo = true;
                CurrentPet.FechaModificacion = DateTime.UtcNow;
                CurrentPet.UsuarioModificacion = _usuario;
                CurrentPet.IpModificacion = _ip;
                _context.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<int> GetNumeroMascotas()
        {
            try
            {
                return await _context.Mascota.CountAsync(x => x.Activo);
            }
            catch (Exception ex)
            {
                // Manejar errores según tus necesidades
                throw;
            }
        }

        public async Task<bool> DeleteMascota(long IdMascota)
        {
            try
            {
                var CurrentPet = await _context.Mascota.FindAsync(IdMascota);
                if (CurrentPet != null)
                {
                    CurrentPet.Activo = false;
                    CurrentPet.FechaEliminacion = DateTime.UtcNow;
                    CurrentPet.UsuarioEliminacion = _usuario;
                    CurrentPet.IpEliminacion = _ip;
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
                return false;
            }
        }
    }
}