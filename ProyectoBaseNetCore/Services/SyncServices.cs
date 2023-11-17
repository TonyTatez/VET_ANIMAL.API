using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.DTOs;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using ProyectoBaseNetCore.Entities;
using Microsoft.AspNetCore.Http;
using static NPOI.HSSF.Util.HSSFColor;
using System;
using ProyectoBaseNetCore.Utilities;

namespace ProyectoBaseNetCore.Services
{
    public class SyncServices
    {
        private static string _usuario;
        private static ExcelHelperService _ExelHelper = new ExcelHelperService();
        private static string _ip;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        private readonly ConsultaServices _consultaService;
        private readonly GeneratorCodeHelper COD;
        public SyncServices(ApplicationDbContext context, IConfiguration configuration, string usuario, string ip)
        {
            _context = context;
            this.configuration = configuration;
            _ip = ip;
            _usuario = usuario;
            _consultaService = new ConsultaServices(context, configuration, ip, usuario);
            COD = new GeneratorCodeHelper(context, configuration, ip, usuario);
        }
        public async Task<ImportResponseDTO> SyncClientsAndPets(IFormFile file)
        {
            try
            {
                using var stream = file.OpenReadStream();
                IWorkbook workbook = new XSSFWorkbook(stream);
                ISheet sheet = workbook.GetSheetAt(0); // Selecciona la hoja de trabajo

                string[] expectedHeaders = new string[] {
            "NOMBRES","CEDULA","DIRECCION","TELEFONO","CORREO","NOMBRE","RAZA","PESO","SEXO","FECH.NAC"
        };

                Dictionary<string, object> result = await _ExelHelper.ValidarFormatoArchivo(sheet, expectedHeaders);

                if ((bool)result["hasError"] == true)
                {
                    throw new Exception(result["messageError"] as string);
                }

                bool hasError = false;
                StringBuilder messageError = new StringBuilder();
                long IdCurrent = 0;
                // List<CheckListAlistamientoDTO> CheckList = new List<CheckListAlistamientoDTO>();

                for (int row = sheet.FirstRowNum + 1; row <= sheet.LastRowNum; row++)
                {
                    IRow excelRow = sheet.GetRow(row);

                    if (excelRow != null)
                    {

                       
                        string Nombres = excelRow.GetCell(0)?.ToString();
                        string Cedula = excelRow.GetCell(1)?.ToString();
                        string Direccion = excelRow.GetCell(2)?.ToString();
                        string Celular = excelRow.GetCell(3)?.ToString();
                        string Correo = excelRow.GetCell(4)?.ToString();
                        string NombreM = excelRow.GetCell(5)?.ToString();
                        string Raza = excelRow.GetCell(6)?.ToString();
                        float Peso = float.Parse(excelRow.GetCell(7)?.ToString()??"0");
                        string Sexo = excelRow.GetCell(8)?.ToString();
                        DateTime? FNac = excelRow.GetCell(9)?.ToString() != null ? DateTime.Parse(excelRow.GetCell(9)?.ToString()) :null;

                        // Realizar validaciones y procesamiento de datos de acuerdo a tus requisitos
                        if (string.IsNullOrEmpty(Cedula) || Cedula.Length < 10)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row + 1}: No se ha proporcionado un Número de cedula o la cedula {Cedula} es inválida.");
                        }

                        if (string.IsNullOrEmpty(Nombres) || Nombres.Length < 3)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row + 1}: No se ha proporcionado un Nombre o {Nombres} no es válido.");
                        }
                        if (string.IsNullOrEmpty(Direccion) || Direccion.Length < 3)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row + 1}: No se ha proporcionado una Direccion o  {Direccion} no es válido.");
                        }
                        if (string.IsNullOrEmpty(Celular) || Celular.Length < 10)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row + 1}: No se ha proporcionado un número Celular o  {Celular} no es válido.");
                        }
                        if (string.IsNullOrEmpty(NombreM) || NombreM.Length < 3)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row + 1}: No se ha proporcionado un Nombre Para la mascota o  {NombreM} no es válido.");
                        }
                        if (string.IsNullOrEmpty(Raza) || Raza.Length < 3)
                        {
                            hasError = true;
                            messageError.AppendLine($"Error fila {row + 1}: No se ha proporcionado la raza o  {Raza} no es válido.");
                        }
                        if (!hasError)
                        {
                            var Cliente = await _context.Cliente.Where(c => c.Identificacion.Equals(Cedula)).FirstOrDefaultAsync();
                            if (Cliente == null)
                            {
                                var codigocLIENTE = await COD.GetOrCreateCodeAsync("CL",true);
                                var codigocMascota = await COD.GetOrCreateCodeAsync("MC",true);
                                var nuevo = new Cliente
                                {
                                    Identificacion = Cedula,
                                    Codigo = codigocLIENTE,
                                    Nombres = Nombres,
                                    Correo = Correo,
                                    Direccion = Direccion,
                                    Telefono = Celular,
                                    Activo = true,
                                    UsuarioRegistro = _usuario,
                                    IpRegistro = _ip,
                                    FechaRegistro = DateTime.Now,
                                    Mascotas = new List<Mascota> {
                                        new Mascota
                                        {
                                            Codigo = codigocMascota,
                                            NombreMascota = NombreM,
                                            Raza= Raza,
                                            Sexo = Sexo,
                                            FechaNacimiento = FNac,
                                            Peso = Peso,
                                            Activo = true,
                                            UsuarioRegistro = _usuario,
                                            IpRegistro = _ip,
                                            FechaRegistro = DateTime.Now,
                                        }
                                    }
                                };
                                await _context.Cliente.AddAsync(nuevo);
                            }
                            else
                            {
                                Cliente.Identificacion = Cedula;
                                Cliente.Nombres = Nombres;
                                Cliente.Correo = Correo;
                                Cliente.Direccion = Direccion;
                                Cliente.Telefono = Celular;
                                Cliente.Activo = true;
                                Cliente.UsuarioModificacion = _usuario;
                                Cliente.IpModificacion = _ip;
                                Cliente.FechaModificacion = DateTime.Now;
                                var FMascota = await _context.Mascota.Where(m => m.IdCliente == Cliente.IdCliente).FirstOrDefaultAsync();
                                if (FMascota == null)
                                {
                                    var codigocMascota = await COD.GetOrCreateCodeAsync("MC", true);
                                    var NMascota = new Mascota
                                    {
                                        IdCliente = Cliente.IdCliente,
                                        Codigo = codigocMascota,
                                        NombreMascota = NombreM,
                                        Raza = Raza,
                                        Sexo = Sexo,
                                        FechaNacimiento = FNac,
                                        Peso = Peso,
                                        Activo = true,
                                        UsuarioRegistro = _usuario,
                                        IpRegistro = _ip,
                                        FechaRegistro = DateTime.Now,
                                    };
                                    await _context.Mascota.AddAsync(NMascota);

                                }else
                                {
                                    FMascota.NombreMascota = NombreM;
                                    FMascota.Raza = Raza;
                                    FMascota.Sexo = Sexo;
                                    FMascota.FechaNacimiento = FNac;
                                    FMascota.Peso = Peso;
                                    FMascota.Activo = true;
                                    FMascota.UsuarioModificacion = _usuario;
                                    FMascota.IpModificacion = _ip;
                                    FMascota.FechaModificacion = DateTime.Now;
                                }

                            }
                            await _context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        hasError = true;
                        messageError.AppendLine($"Error fila {row - 1}: El registro no se creó.");
                    }
                }

                return new ImportResponseDTO
                {
                    HasError = hasError,
                    Message = messageError.ToString()
                };
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
        }


    }
}