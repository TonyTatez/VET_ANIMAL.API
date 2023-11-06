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
        private readonly IConfiguration configuration;
        public MascotaServices(ApplicationDbContext context, IConfiguration configuration, string ip, string usuario)
        {
            _context = context;
            this.configuration = configuration;
            _ip = ip;
            _usuario = usuario;
        }

       

        public async Task<List<MascotaDTO>> GetAllMascotasAsync() => await _context.Mascota
            .Where(x => x.Activo).Select(x => new MascotaDTO
                {
                    IdMascota = x.IdMascota,
                    NombreMascota= x.NombreMascota,
                    IdCliente = x.IdCliente,
                    Cliente = x.Cliente.Nombres,
                    Raza  = x.Raza,
                    Sexo = x.Sexo,
                    FechaNacimiento = x.FechaNacimiento,
                }).ToListAsync();


        public async Task<MascotaDTO> GetIdMascota(long IdMascota) => await _context.Mascota.Where(x => x.Activo && x.IdMascota == IdMascota).Select(x => new MascotaDTO
                {
                    IdMascota = x.IdMascota,
                    NombreMascota = x.NombreMascota,
                    IdCliente = x.IdCliente,
                    Cliente = x.Cliente.Nombres,
                    Raza = x.Raza,
                    Sexo = x.Sexo,
                    FechaNacimiento = x.FechaNacimiento,
                }).FirstOrDefaultAsync();

        public async Task<bool> SaveMascota(MascotaDTO Data)
        {
            try
            {
                
                    var CurrentPet = await _context.Mascota
                    .Where(x => x.Activo && x.NombreMascota == Data.NombreMascota).FirstOrDefaultAsync();
                    if (CurrentPet == null)
                    {
                        Mascota NewPet = new Mascota();
                        NewPet.NombreMascota = Data.NombreMascota;
                        NewPet.IdCliente = Data.IdCliente;
                        NewPet.Raza = Data.Raza;
                        NewPet.FechaNacimiento = Data.FechaNacimiento;
                        NewPet.Sexo = Data.Sexo;
                        NewPet.Activo = true;
                        NewPet.FechaRegistro = DateTime.Now;
                        NewPet.UsuarioRegistro = _usuario;
                        NewPet.IpRegistro = _ip;
                        await _context.Mascota.AddAsync(NewPet);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        CurrentPet.NombreMascota = Data.NombreMascota;
                        CurrentPet.IdCliente = Data.IdCliente;
                        CurrentPet.Raza = Data.Raza;
                        CurrentPet.FechaNacimiento = Data.FechaNacimiento;
                        CurrentPet.Sexo = Data.Sexo;
                        CurrentPet.Activo = true;
                        CurrentPet.FechaModificacion = DateTime.Now;
                        CurrentPet.UsuarioModificacion = _usuario;
                        CurrentPet.IpModificacion = _ip;
                        _context.SaveChanges();

                        return true;
                    }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMascota(long IdCliente)
        {
            try
            {
                    var CurrentPet = await _context.Mascota.FindAsync(IdCliente);
                    if (CurrentPet != null)
                    {
                        CurrentPet.Activo = false;
                        CurrentPet.FechaEliminacion = DateTime.Now;
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