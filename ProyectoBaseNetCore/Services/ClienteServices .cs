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
                //Apellidos = x.Codigo,
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

        //public async Task<bool> SaveCliente(GuardarClienteViewModel Cliente)
        //{
        //    var ClienteEncontrada = await _context.Cliente.FirstOrDefaultAsync(x => x.Activo && (x.IdCliente == Cliente.idCliente || x.Nombres == Cliente.nombres));
        //    if (ClienteEncontrada == null)
        //    {
        //        Cliente NewCiudad = new Cliente();
        //        Cliente.idCliente = Cliente.idCliente;
        //        Cliente.identificacion = Cliente.identificacion;
        //        Cliente. = true;
        //        Cliente.FechaRegistro = DateTime.Now;
        //        Cliente.UsuarioRegistro = _usuario;
        //        Cliente.IpRegistro = _ip;
        //        Cliente.SistemaRegistro = "Mantenimiento WEB";
        //        await _context.Cliente.AddAsync(NewCiudad);
        //        await _context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        CiudadEncontrada.Nombre = Ciudad.descripcionCiudad;
        //        CiudadEncontrada.FechaModificacion = DateTime.Now;
        //        CiudadEncontrada.UsuarioModificacion = _usuario;
        //        CiudadEncontrada.IpModificacion = _ip;
        //        CiudadEncontrada.SistemaModificacion = "Mantenimiento WEB";
        //        await context.SaveChangesAsync();
        //    }
        //    return true;
        //}
        public async Task<bool> SaveCliente(GuardarClienteViewModel Cliente)
        {
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

        //public Task<List<GuardarClienteViewModel>> GuardarCliente(GuardarClienteViewModel guardar)
        //{

        //    try
        //    {
        //        Cliente ClienteEncontrada = await _context.Cliente.Where(x => x.Identificacion == Cliente.Identificacion.Trim()).FirstOrDefaultAsync();
        //        if (ClienteEncontrada == null)
        //        {
        //            Cliente NewCliente = new Cliente();
        //            NewCliente.Identificacion = Cliente.Identificacion;
        //            NewCliente.Nombres = Cliente.Nombres;
        //            NewCliente.IdCliente = Cliente.IdCliente;
        //            NewCliente.Codigo = Cliente.Apellidos;
        //            NewCliente.Direccion = Cliente.Direccion;
        //            NewCliente.Telefono = Cliente.Telefono;
        //            NewCliente.FechaRegistro = DateTime.Now;
        //            NewCliente.UsuarioRegistro = _usuario;
        //            NewCliente.IpRegistro = _ip;
        //            await _context.Cliente.AddAsync(NewCliente);
        //            await _context.SaveChangesAsync();
        //            return true;
        //        }
        //        else
        //        {
        //            ClienteEncontrada.Nombres = Cliente.Nombres;
        //            ClienteEncontrada.Codigo = Cliente.Apellidos;
        //            ClienteEncontrada.Direccion = Cliente.Direccion;
        //            ClienteEncontrada.Telefono = Cliente.Telefono;
        //            ClienteEncontrada.FechaModificacion = DateTime.Now;
        //            ClienteEncontrada.UsuarioModificacion = _usuario;
        //            ClienteEncontrada.IpModificacion = _ip;
        //            await _context.SaveChangesAsync();
        //            return true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}



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