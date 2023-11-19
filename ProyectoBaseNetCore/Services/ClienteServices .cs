using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math;
using ProyectoBaseNetCore.DTOs;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Models;

namespace ProyectoBaseNetCore.Services
{
    public class ClienteService
    {
        private static string _usuario;
        private static string _ip;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        public ClienteService(ApplicationDbContext context, IConfiguration configuration, string ip, string usuario)
        {
            _context = context;
            this.configuration = configuration;
            _ip = ip;
            _usuario = usuario;
        }
        public async Task<List<ClienteDTO>> GetCliente() => await _context.Cliente
            .Where(x => x.Activo).Select(x => new ClienteDTO
            {
                identificacion = x.Identificacion,
                nombres = x.Nombres,
                idCliente = x.IdCliente,
                direccion = x.Direccion,
                telefono = x.Telefono,
                correo= x.Correo,
                codigo = x.Codigo,
            }).ToListAsync();
        public async Task<List<MascotaDTO>> GetMascotasCliente(string CI) => await _context.Mascota
            .Where(x => x.Activo && x.Cliente.Identificacion.Equals(CI)).Select(x => new MascotaDTO
            {
                IdMascota = x.IdMascota,
                CODMascota = x.Codigo,
                NombreMascota = x.NombreMascota,
                IdCliente = x.IdCliente,
                Cliente = x.Cliente.Nombres,
                Raza = x.Raza,
                Peso = x.Peso,
                Sexo = x.Sexo,
                FechaNacimiento = x.FechaNacimiento,
            }).ToListAsync();
        public async Task<ClienteDTO> GetClientByCI(string CI) => await _context.Cliente
            .Where(x => x.Activo && x.Identificacion == CI).Select(x => new ClienteDTO
            {
                idCliente = x.IdCliente,
                identificacion = x.Identificacion,
                nombres = x.Nombres,
                codigo= x.Codigo,
                direccion = x.Direccion,
                telefono = x.Telefono,
                correo= x.Correo,
            }).FirstOrDefaultAsync();
        static bool ValidarCedulaEcuatoriana(string cedula)
        {
            if (cedula.Length != 10)
            {
                throw new Exception("La cédula debe tener 10 dígitos");
            }

            string digitoRegion = cedula.Substring(0, 2);

            if (!int.TryParse(digitoRegion, out int region) || region < 1 || region > 24)
            {
                throw new Exception("Número de cédula invalido!");
            }

            int ultimoDigito = int.Parse(cedula.Substring(9, 1));
            int sumaTotal = 0;

            for (int i = 0; i < 9; i += 2)
            {
                int valor = int.Parse(cedula[i].ToString()) * 2;
                sumaTotal += (valor > 9) ? valor - 9 : valor;
            }

            sumaTotal += int.Parse(cedula[1].ToString()) + int.Parse(cedula[3].ToString()) +
                         int.Parse(cedula[5].ToString()) + int.Parse(cedula[7].ToString());

            int digitoValidador = ((sumaTotal / 10) + 1) * 10 - sumaTotal % 10;
            if (digitoValidador == 10) digitoValidador = 0;

            return digitoValidador == ultimoDigito;
        }
        public async Task<bool> SaveCliente(GuardarClienteViewModel Cliente)
        {
            ValidarCedulaEcuatoriana(Cliente.identificacion);
            var ClienteEncontrada = await _context.Cliente.FirstOrDefaultAsync(x => x.Activo && (x.IdCliente == Cliente.idCliente || x.Nombres == Cliente.nombres));
            if (ClienteEncontrada == null)
            {
                Cliente NewCliente = new Cliente();
                NewCliente.Nombres = Cliente.nombres;
                NewCliente.Identificacion = Cliente.identificacion;
                NewCliente.Direccion = Cliente.direccion;
                NewCliente.Correo = Cliente.correo;
                NewCliente.Telefono = Cliente.telefono;
                NewCliente.Activo = true;
                NewCliente.FechaRegistro = DateTime.Now;
                NewCliente.UsuarioRegistro = _usuario;
                NewCliente.IpRegistro = _ip;
                await _context.Cliente.AddAsync(NewCliente);
                await _context.SaveChangesAsync();
            }
            else
            {
                ClienteEncontrada.Nombres = Cliente.nombres;
                ClienteEncontrada.Identificacion = Cliente.identificacion;
                ClienteEncontrada.Direccion = Cliente.direccion;
                ClienteEncontrada.Correo = Cliente.correo;
                ClienteEncontrada.Telefono = Cliente.telefono;
                ClienteEncontrada.FechaModificacion = DateTime.Now;
                ClienteEncontrada.UsuarioModificacion = _usuario;
                ClienteEncontrada.IpModificacion = _ip;
                await _context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> EditCliente(ClienteDTO Cliente)
        {
            // Buscar el cliente por ID
            var ClienteEncontrado = await _context.Cliente.FindAsync(Cliente.idCliente);

            // Verificar si se encontró el cliente
            if (ClienteEncontrado != null)
            {
                // Actualizar las propiedades del cliente encontrado
                ClienteEncontrado.Nombres = Cliente.nombres;
                ClienteEncontrado.Identificacion = Cliente.identificacion;
                ClienteEncontrado.Direccion = Cliente.direccion;
                ClienteEncontrado.Correo = Cliente.correo;
                ClienteEncontrado.Telefono = Cliente.telefono;
                ClienteEncontrado.FechaModificacion = DateTime.Now;
                ClienteEncontrado.UsuarioModificacion = _usuario;
                ClienteEncontrado.IpModificacion = _ip;

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();

                // Indicar que la edición fue exitosa
                return true;
            }
            else
            {
                // El cliente no fue encontrado, puedes manejar esto según tus necesidades
                // En este caso, devuelvo false para indicar que la edición no fue exitosa
                return false;
            }
        }

        public async Task<int> GetNumeroClientes()
        {
            try
            {
                return await _context.Cliente.CountAsync(x => x.Activo);
            }
            catch (Exception ex)
            {
                // Manejar errores según tus necesidades
                throw;
            }
        }


        public async Task<bool> DeleteCliente(long IdCliente)
        {
            try
            {
                var ClienteEncontrada = await _context.Cliente.FindAsync(IdCliente);
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