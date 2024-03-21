using InventarioComputadoras.Datos;
using InventarioComputadoras.Datos.Migrations;
using DatosAlmacenamiento = InventarioComputadoras.Datos.Migrations.Almacenamiento;
using InventarioComputadoras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InventarioComputadoras.Controllers
{
    public class InicioController : Controller
    {
        private readonly AppDBContext _contexto;
        private readonly Dictionary<string, string> zonas;
        private readonly Dictionary<string, string> departamentos;

        private List<SelectListItem> ObtenerZonas()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "Tulcán", Text = "Tulcán" },
            new SelectListItem { Value = "Multiplaza", Text = "Multiplaza" },
            new SelectListItem { Value = "Amazonas", Text = "Amazonas" },
            new SelectListItem { Value = "Mayorista", Text = "Mayorista" },
            new SelectListItem { Value = "Atuntaqui", Text = "Atuntaqui" },
            new SelectListItem { Value = "San Gabriel", Text = "San Gabriel" },
            new SelectListItem { Value = "Bolívar", Text = "Bolívar" },
            new SelectListItem { Value = "Quito", Text = "Quito" },
            new SelectListItem { Value = "Ibarra", Text = "Ibarra" },
            new SelectListItem { Value = "Nuevo Lago", Text = "Nuevo Lago" },
            new SelectListItem { Value = "Mira", Text = "Mira" }
        };
        }

        private List<SelectListItem> ObtenerDepartamentos()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "Atención al Cliente", Text = "Atención al Cliente" },
            new SelectListItem { Value = "Auditoria", Text = "Auditoria" },
            new SelectListItem { Value = "Cajas", Text = "Cajas" },
            new SelectListItem { Value = "CallCenter", Text = "CallCenter" },
            new SelectListItem { Value = "Cobranzas", Text = "Cobranzas" },
            new SelectListItem { Value = "Contabilidad", Text = "Contabilidad" },
            new SelectListItem { Value = "Crédito", Text = "Crédito" },
            new SelectListItem { Value = "Cumplimiento", Text = "Cumplimiento" },
            new SelectListItem { Value = "Gerencia General", Text = "Gerencia General" },
            new SelectListItem { Value = "Inversiones", Text = "Inversiones" },
            new SelectListItem { Value = "Jurídico", Text = "Jurídico" },
            new SelectListItem { Value = "Mercadeo", Text = "Mercadeo" },
            new SelectListItem { Value = "Marketing", Text = "Marketing" },
            new SelectListItem { Value = "Jefe de Operaciones y Procesos", Text = "Jefe de Operaciones y Procesos" },
            new SelectListItem { Value = "Oficial de Operaciones y Procesos", Text = "Oficial de Operaciones y Procesos" },
            new SelectListItem { Value = "Riesgos", Text = "Riesgos" },
            new SelectListItem { Value = "Secretaria", Text = "Secretaria" },
            new SelectListItem { Value = "Seguridad", Text = "Seguridad" },
            new SelectListItem { Value = "Servicio Médico", Text = "Servicio Médico" },
            new SelectListItem { Value = "SubGerencia", Text = "SubGerencia" },
            new SelectListItem { Value = "T.I", Text = "T.I" },
            new SelectListItem { Value = "Talento Humano", Text = "Talento Humano" }
        };
        }

        private List<SelectListItem> ObtenerSistemaOperativo()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "Seleccionar" },
            new SelectListItem { Value = "Windows 7", Text = "Windows 7" },
            new SelectListItem { Value = "Windows 8", Text = "Windows 8" },
            new SelectListItem { Value = "Windows 10", Text = "Windows 10" },
            new SelectListItem { Value = "Windows 11", Text = "Windows 11" }
        };
        }

        private List<SelectListItem> ObtenerOffice()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "Seleccionar" },
            new SelectListItem { Value = "Office 2019", Text = "Office 2019" },
            new SelectListItem { Value = "Office 2021", Text = "Office 2021" },
            new SelectListItem { Value = "Office 365", Text = "Office 365" }
        };
        }

        private List<SelectListItem> ObtenerAntivirus()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "Seleccionar" },
            new SelectListItem { Value = "Fortinet", Text = "Fortinet" }
        };
        }

        private List<SelectListItem> ObtenerDominio()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "Si", Text = "Si" },
            new SelectListItem { Value = "No", Text = "No" }
        };
        }

        private List<SelectListItem> ObtenerEstado()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "Dado de Baja", Text = "Dado de Baja" },
            new SelectListItem { Value = "En Uso", Text = "En Uso" },
            new SelectListItem { Value = "Almacenado", Text = "Almacenado" }
        };
        }

        private List<SelectListItem> ObtenerTipo()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "Torre", Text = "Torre" },
            new SelectListItem { Value = "Laptop", Text = "Laptop" },
            new SelectListItem { Value = "NUC", Text = "NUC" }
        };
        }

        private List<SelectListItem> ObtenerTipoRAM()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "DDR2", Text = "DDR2" },
            new SelectListItem { Value = "DDR3", Text = "DDR3" },
            new SelectListItem { Value = "DDR4", Text = "DDR4" },
            new SelectListItem { Value = "DDR5", Text = "DDR5" }
        };
        }

        private List<SelectListItem> ObtenerCapacidadRAM()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "2 GB", Text = "2 GB" },
            new SelectListItem { Value = "4 GB", Text = "4 GB" },
            new SelectListItem { Value = "8 GB", Text = "8 GB" },
            new SelectListItem { Value = "16 GB", Text = "16 GB" },
            new SelectListItem { Value = "32 GB", Text = "32 GB" },
            new SelectListItem { Value = "64 GB", Text = "64 GB" }
        };
        }

        private List<SelectListItem> ObtenerModulosRAM()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "1 Módulo", Text = "1 Módulo" },
            new SelectListItem { Value = "2 Módulo", Text = "2 Módulo" },
            new SelectListItem { Value = "4 Módulo", Text = "4 Módulo" }
        };
        }

        private List<SelectListItem> ObtenerTipoAlmacenamiento()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "HDD", Text = "HDD" },
            new SelectListItem { Value = "SSD", Text = "SSD" },
            new SelectListItem { Value = "M.2", Text = "M.2" }
        };
        }

        private List<SelectListItem> ObtenerCapacidadAlmacenamiento()
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "256 GB", Text = "256 GB" },
            new SelectListItem { Value = "512 GB", Text = "512 GB" },
            new SelectListItem { Value = "1 TB", Text = "1 TB" },
            new SelectListItem { Value = "2 TB", Text = "2 TB" },
            new SelectListItem { Value = "4 TB", Text = "4 TB" },
            new SelectListItem { Value = "8 TB", Text = "8 TB" },
            new SelectListItem { Value = "10 TB", Text = "10 TB" },
            new SelectListItem { Value = "12 TB", Text = "12 TB" },
            new SelectListItem { Value = "16 TB", Text = "16 TB" },
            new SelectListItem { Value = "18 TB", Text = "18 TB" },
            new SelectListItem { Value = "20 TB", Text = "20 TB" },
            new SelectListItem { Value = "26 TB", Text = "26 TB" }
        };
        }

        private Dictionary<string, string> ObtenerZonas2()
        {
            return new Dictionary<string, string>
        {
            { "TUL", "Tulcán" },
            { "MUL", "Multiplaza" },
            { "AMA", "Amazonas" },
            { "MAY", "Mayorista" },
            { "ATU", "Atuntaqui" },
            { "SAG", "San Gabriel" },
            { "BOL", "Bolívar" },
            { "QUI", "Quito" },
            { "IBA", "Ibarra" },
            { "LAG", "Nuevo Lago" },
            { "MIR", "Mira" }
        };
        }

        private Dictionary<string, string> ObtenerDepartamentos2()
        {
            return new Dictionary<string, string>
        {
            { "ATEN", "Atención al Cliente" },
            { "AUDI", "Auditoria" },
            { "CAJA", "Cajas" },
            { "CALL", "CallCenter" },
            { "COBR", "Cobranzas" },
            { "CONT", "Contabilidad" },
            { "CRED", "Crédito" },
            { "CUMP", "Cumplimiento" },
            { "GERE", "Gerencia General" },
            { "INVE", "Inversiones" },
            { "JURI", "Jurídico" },
            { "MARK", "Mercadeo" },
            { "MERC", "Marketing" },
            { "OPER", "Jefe de Operaciones y Procesos" },
            { "PROS", "Oficial de Operaciones y Procesos" },
            { "RIES", "Riesgos" },
            { "SECR", "Secretaria" },
            { "SEGU", "Seguridad" },
            { "SMED", "Servicio Médico" },
            { "SUBG", "SubGerencia" },
            { "TECN", "T.I" },
            { "TTHH", "Talento Humano" }
        };
        }

        public InicioController(AppDBContext contexto)
        {
            _contexto = contexto;

            zonas = new Dictionary<string, string>
            {
                    { "TUL", "Tulcán" },
                    { "MUL", "Multiplaza" },
                    { "AMA", "Amazonas" },
                    { "MAY", "Mayorista" },
                    { "ATU", "Atuntaqui" },
                    { "SAG", "San Gabriel" },
                    { "BOL", "Bolívar" },
                    { "QUI", "Quito" },
                    { "IBA", "Ibarra" },
                    { "LAG", "Nuevo Lago" },
                    { "MIR", "Mira" }
            };

            departamentos = new Dictionary<string, string>
            {
                    { "ATEN", "Atención al Cliente" },
                    { "AUDI", "Auditoria" },
                    { "CAJA", "Cajas" },
                    { "CALL", "CallCenter" },
                    { "COBR", "Cobranzas" },
                    { "CONT", "Contabilidad" },
                    { "CRED", "Crédito" },
                    { "CUMP", "Cumplimiento" },
                    { "GERE", "Gerencia General" },
                    { "INVE", "Inversiones" },
                    { "JURI", "Jurídico" },
                    { "MARK", "Mercadeo" },
                    { "MERC", "Marketing" },
                    { "OPER", "Jefe de Operaciones y Procesos" },
                    { "PROS", "Oficial de Operaciones y Procesos" },
                    { "RIES", "Riesgos" },
                    { "SECR", "Secretaria" },
                    { "SEGU", "Seguridad" },
                    { "SMED", "Servicio Médico" },
                    { "SUBG", "SubGerencia" },
                    { "TECN", "T.I" },
                    { "TTHH", "Talento Humano" }
            };

        }

        private void ConvertirAbreviaciones(Computadora computadora)
        {
            if (zonas.ContainsKey(computadora.Oficina))
            {
                computadora.Oficina = zonas[computadora.Oficina];
            }
            if (departamentos.ContainsKey(computadora.Departamento))
            {
                computadora.Departamento = departamentos[computadora.Departamento];
            }
        }

        private void ConvertirAbreviaciones(IEnumerable<Computadora> computadoras)
        {
            foreach (var computadora in computadoras)
            {
                ConvertirAbreviaciones(computadora);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var zonas = ObtenerZonas2();
            var departamentos = ObtenerDepartamentos2();

            var computadoras = await _contexto.Computadoras.ToListAsync();

            foreach (var computadora in computadoras)
            {
                if (zonas.ContainsKey(computadora.Oficina))
                {
                    computadora.Oficina = zonas[computadora.Oficina];
                }
                if (departamentos.ContainsKey(computadora.Departamento))
                {
                    computadora.Departamento = departamentos[computadora.Departamento];
                }
            }

            return View(computadoras);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            var computadora = new Computadora();

            if (computadora.Almacenamientos == null)
            {
                computadora.Almacenamientos = new List<Models.Almacenamiento>();
            }

            if (computadora.Almacenamientos.Count == 0)
            {
                computadora.Almacenamientos.Add(new Models.Almacenamiento());
            }   

            ViewBag.Zonas = ObtenerZonas();
            ViewBag.Departamentos = ObtenerDepartamentos();
            ViewBag.sistemaoperativo = ObtenerSistemaOperativo();
            ViewBag.office = ObtenerOffice();
            ViewBag.antivirus = ObtenerAntivirus();
            ViewBag.dominio = ObtenerDominio();
            ViewBag.estado = ObtenerEstado();
            ViewBag.tipo = ObtenerTipo();
            ViewBag.tiporam = ObtenerTipoRAM();
            ViewBag.modulosram = ObtenerModulosRAM();
            ViewBag.capacidadram = ObtenerCapacidadRAM();
            ViewBag.capacidadalmacenamiento = ObtenerCapacidadAlmacenamiento();
            ViewBag.tipoalmacenamiento = ObtenerTipoAlmacenamiento();

            return View(computadora);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Computadora computadora, bool sinNombreAnterior, bool sinDireccionIP, bool sinLicenciaSO, bool conLicenciaSO, bool sinLicenciaOffice, bool conLicenciaOffice, bool sinAntivirus, bool conAntivirus)
        {
            ViewBag.Zonas = ObtenerZonas();
            ViewBag.Departamentos = ObtenerDepartamentos();
            ViewBag.sistemaoperativo = ObtenerSistemaOperativo();
            ViewBag.office = ObtenerOffice();
            ViewBag.antivirus = ObtenerAntivirus();
            ViewBag.dominio = ObtenerDominio();
            ViewBag.estado = ObtenerEstado();
            ViewBag.tipo = ObtenerTipo();
            ViewBag.modulosram = ObtenerModulosRAM();
            ViewBag.tiporam = ObtenerTipoRAM();
            ViewBag.capacidadram = ObtenerCapacidadRAM();
            ViewBag.capacidadalmacenamiento = ObtenerCapacidadAlmacenamiento();
            ViewBag.tipoalmacenamiento = ObtenerTipoAlmacenamiento();


            if (computadora.SinNombreAnterior)
            {
                computadora.NombreAnterior = "Sin nombre anterior";
            }


            if (computadora.SinDireccionIP)
            {
                computadora.DireccionIp = "Sin Direccion IP";
            }


            if (computadora.SinLicenciaSO && computadora.ConLicenciaSO)
            {
                ModelState.AddModelError("ConLicenciaSO", "Debe seleccionar una opción para la licencia.");
                return View(computadora);
            }
            else if (computadora.SinLicenciaSO)
            {
                computadora.LicenciaSO = "No";
            }
            else if (computadora.ConLicenciaSO)
            {
                computadora.LicenciaSO = "Si";
            }


            if (computadora.SinLicenciaOffice && computadora.ConLicenciaOffice)
            {
                ModelState.AddModelError("ConLicenciaOffice", "Debe seleccionar una opción para la licencia.");
                return View(computadora);
            }
            else if (computadora.SinLicenciaOffice)
            {
                computadora.Office = "No";
            }
            else if (computadora.ConLicenciaOffice)
            {
                computadora.Office = "Si";
            }


            if (computadora.SinAntivirus && computadora.ConAntivirus)
            {
                ModelState.AddModelError("ConAntivitus", "Debe seleccionar una opción para el antivirus.");
                return View(computadora);
            }
            else if (computadora.SinAntivirus)
            {
                computadora.LicenciaAntivirus = "No";
            }
            else if (computadora.ConAntivirus)
            {
                computadora.LicenciaAntivirus = "Si";
            }

            if (ModelState.IsValid)
            {

                if (!computadora.SinDireccionIP)
                {
                    var ipExistente = await _contexto.Computadoras.AnyAsync(c => c.DireccionIp == computadora.DireccionIp);
                    if (ipExistente)
                    {
                        ModelState.AddModelError("DireccionIp", "Esta dirección IP ya está en uso.");
                        return View(computadora);
                    }
                }

                string nombreBase = computadora.Departamento.Substring(0, 4).ToUpper() + computadora.Oficina.Substring(0, 3).ToUpper();

                var ultimaComputadora = await _contexto.Computadoras
                    .Where(c => c.NombreNuevo.StartsWith(nombreBase))
                    .OrderByDescending(c => c.NombreNuevo)
                    .FirstOrDefaultAsync();

                int ultimoNumero = 0;
                if (ultimaComputadora != null)
                {
                    string ultimoNumeroStr = ultimaComputadora.NombreNuevo.Substring(nombreBase.Length).Trim();
                    int.TryParse(ultimoNumeroStr, out ultimoNumero);
                }

                string nombreNuevo = nombreBase + " " + (ultimoNumero + 1);
                computadora.NombreNuevo = nombreNuevo;

                _contexto.Computadoras.Add(computadora);
                await _contexto.SaveChangesAsync();

                if (computadora.Almacenamientos != null)
                {
                    foreach (var almacenamiento in computadora.Almacenamientos)
                    {
                        if (string.IsNullOrEmpty(almacenamiento.MarcaAlmacenamiento) ||
                            string.IsNullOrEmpty(almacenamiento.NumeroSerieAlmacenamiento) ||
                            string.IsNullOrEmpty(almacenamiento.NumeroParteAlmacenamiento))
                        {
                            continue;
                        }
                        else 
                        {
                            _contexto.Almacenamientos.Add(almacenamiento);

                        }
                    }
                }
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(computadora);
        }


        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            ViewBag.Zonas = ObtenerZonas();
            ViewBag.Departamentos = ObtenerDepartamentos();
            ViewBag.sistemaoperativo = ObtenerSistemaOperativo();
            ViewBag.office = ObtenerOffice();
            ViewBag.antivirus = ObtenerAntivirus();
            ViewBag.dominio = ObtenerDominio();
            ViewBag.estado = ObtenerEstado();
            ViewBag.tipo = ObtenerTipo();
            ViewBag.modulosram = ObtenerModulosRAM();
            ViewBag.tiporam = ObtenerTipoRAM();
            ViewBag.capacidadram = ObtenerCapacidadRAM();
            ViewBag.capacidadalmacenamiento = ObtenerCapacidadAlmacenamiento();
            ViewBag.tipoalmacenamiento = ObtenerTipoAlmacenamiento();

            if (Id == null)
            {
                return NotFound();
            }

            var computadora = _contexto.Computadoras
                        .Include(c => c.Almacenamientos)
                        .FirstOrDefault(c => c.Id == Id);


            if (computadora == null)
            {
                return NotFound();
            }

            if (computadora.Almacenamientos == null)
            {
                computadora.Almacenamientos = new List<Models.Almacenamiento>();
            }

            if (computadora.Almacenamientos.Count == 0)
            {
                computadora.Almacenamientos.Add(new Models.Almacenamiento());
            }

            ViewBag.SelectedZona = computadora.Oficina;
            ViewBag.SelectedDepartamento = computadora.Departamento;
            ViewBag.SelectedSistemaOperativo = computadora.SistemaOperativo;
            ViewBag.SelectedOffice = computadora.Office;
            ViewBag.SelectedAntivirus = computadora.VersionAntivirus;
            ViewBag.SelectedDominio = computadora.Dominio;
            ViewBag.SelectedEstado = computadora.Estado;
            ViewBag.SelectedTipo = computadora.MemoriaRamTipo;
            ViewBag.SelectedModulosRam = computadora.MemoriaModulos;
            ViewBag.SelectedTipoRam = computadora.MemoriaRamTipo;
            ViewBag.SelectedCapacidadRam = computadora.MemoriaRamCapacidad;
            ViewBag.SelectedCapacidadAlmacenamiento = computadora.AlmacenamientoCapacidad;
            ViewBag.SelectedTipoAlmacenamiento = computadora.AlmacenamientoTipo;


            return View(computadora);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Computadora computadora, bool sinNombreAnterior, bool sinDireccionIP, bool sinLicenciaSO, bool conLicenciaSO, bool sinLicenciaOffice, bool conLicenciaOffice, bool sinAntivirus, bool conAntivirus)
        {
            ViewBag.Zonas = ObtenerZonas();
            ViewBag.Departamentos = ObtenerDepartamentos();
            ViewBag.sistemaoperativo = ObtenerSistemaOperativo();
            ViewBag.office = ObtenerOffice();
            ViewBag.antivirus = ObtenerAntivirus();
            ViewBag.dominio = ObtenerDominio();
            ViewBag.estado = ObtenerEstado();
            ViewBag.tipo = ObtenerTipo();
            ViewBag.modulosram = ObtenerModulosRAM();
            ViewBag.tiporam = ObtenerTipoRAM();
            ViewBag.capacidadram = ObtenerCapacidadRAM();
            ViewBag.capacidadalmacenamiento = ObtenerCapacidadAlmacenamiento();
            ViewBag.tipoalmacenamiento = ObtenerTipoAlmacenamiento();


            if (ModelState.IsValid)
            {

                var computadoraExistente = await _contexto.Computadoras
                                                    .Include(c => c.Almacenamientos)
                                                    .FirstOrDefaultAsync(c => c.Id == computadora.Id);
                if (computadoraExistente == null)
                {
                    return NotFound();
                }

                bool nombreCambiado = computadoraExistente.Departamento != computadora.Departamento ||
                                                        computadoraExistente.Oficina != computadora.Oficina;

                if (nombreCambiado)
                {
                    string nombreBase = computadora.Departamento.Substring(0, 4).ToUpper() + computadora.Oficina.Substring(0, 3).ToUpper();

                    var ultimaComputadora = await _contexto.Computadoras
                        .Where(c => c.NombreNuevo.StartsWith(nombreBase))
                        .OrderByDescending(c => c.NombreNuevo)
                        .FirstOrDefaultAsync();

                    int ultimoNumero = 1;
                    if (ultimaComputadora != null)
                    {
                        string ultimoNumeroStr = ultimaComputadora.NombreNuevo.Substring(nombreBase.Length).Trim();
                        int.TryParse(ultimoNumeroStr, out ultimoNumero);
                        ultimoNumero++;
                    }

                    string nombreNuevo = nombreBase + " " + (ultimoNumero);

                    computadoraExistente.NombreAnterior = computadoraExistente.NombreNuevo;
                    computadoraExistente.NombreNuevo = nombreNuevo;
                }

                computadoraExistente.LicenciaSO = sinLicenciaSO ? "No" : "Si";
                computadoraExistente.Office = sinLicenciaOffice ? "No" : "Si";
                computadoraExistente.LicenciaAntivirus = sinAntivirus ? "No" : "Si";

                if (!sinDireccionIP)
                {
                    computadoraExistente.DireccionIp = computadora.DireccionIp;
                }
                else
                {
                    computadoraExistente.DireccionIp = "Sin Direccion IP";
                }

                computadoraExistente.SinAntivirus = computadora.SinAntivirus;
                computadoraExistente.ConAntivirus = computadora.ConAntivirus;
                computadoraExistente.SinLicenciaOffice = computadora.SinLicenciaOffice;
                computadoraExistente.ConLicenciaOffice = computadora.ConLicenciaOffice;
                computadoraExistente.ConLicenciaSO = computadora.ConLicenciaSO;
                computadoraExistente.SinLicenciaSO = computadora.SinLicenciaSO;
                computadoraExistente.Oficina = computadora.Oficina;
                computadoraExistente.Departamento = computadora.Departamento;
                computadoraExistente.SistemaOperativo = computadora.SistemaOperativo;
                computadoraExistente.VersionOffice = computadora.VersionOffice;
                computadoraExistente.VersionAntivirus = computadora.VersionAntivirus;
                computadoraExistente.FechaOffice = computadora.FechaOffice;
                computadoraExistente.Usuario = computadora.Usuario;
                computadoraExistente.Dominio = computadora.Dominio;
                computadoraExistente.CodigoConstitucional = computadora.CodigoConstitucional;
                computadoraExistente.FechaAdquisicion = computadora.FechaAdquisicion;
                computadoraExistente.Estado = computadora.Estado;
                computadoraExistente.Tipo = computadora.Tipo;
                computadoraExistente.Marca = computadora.Marca;
                computadoraExistente.NParte = computadora.NParte;
                computadoraExistente.NSerie = computadora.NSerie;
                computadoraExistente.MotherBoard = computadora.MotherBoard;
                computadoraExistente.Procesador = computadora.Procesador;
                computadoraExistente.MemoriaRamTipo = computadora.MemoriaRamTipo;
                computadoraExistente.MemoriaModulos = computadora.MemoriaModulos;
                computadoraExistente.MemoriaRamCapacidad = computadora.MemoriaRamCapacidad;
                computadoraExistente.MemoriaRamMarca = computadora.MemoriaRamMarca;
                computadoraExistente.MemoriaRamNumeroSerie = computadora.MemoriaRamNumeroSerie;
                computadoraExistente.MemoriaRamNumeroParte = computadora.MemoriaRamNumeroParte;
                computadoraExistente.AlmacenamientoTipo = computadora.AlmacenamientoTipo;
                computadoraExistente.AlmacenamientoCapacidad = computadora.AlmacenamientoCapacidad;
                computadoraExistente.AlmacenamientoMarca = computadora.AlmacenamientoMarca;
                computadoraExistente.AlmacenamientoNumeroSerie = computadora.AlmacenamientoNumeroSerie;
                computadoraExistente.AlmacenamientoNumeroParte = computadora.AlmacenamientoNumeroParte;

                _contexto.Update(computadoraExistente);
                await _contexto.SaveChangesAsync();

                if (computadoraExistente.Almacenamientos != null)
                {
                    foreach (var almacenamiento in computadoraExistente.Almacenamientos)
                    {
                        if (string.IsNullOrEmpty(almacenamiento.MarcaAlmacenamiento) ||
                            string.IsNullOrEmpty(almacenamiento.NumeroSerieAlmacenamiento) ||
                            string.IsNullOrEmpty(almacenamiento.NumeroParteAlmacenamiento))
                        {
                            continue;
                        }
                        else
                        {
                            _contexto.Almacenamientos.Update(almacenamiento);

                        }
                    }
                }

                computadoraExistente.Almacenamientos = computadora.Almacenamientos;

                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(computadora);
        }


        [HttpGet]
        public async Task<IActionResult> DetalleComputador(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = await _contexto.Computadoras.FindAsync(id);
            if (computador == null)
            {
                return NotFound();
            }

            var zonas = ObtenerZonas2();
            var departamentos = ObtenerDepartamentos2();

            if (zonas.ContainsKey(computador.Oficina))
            {
                computador.Oficina = zonas[computador.Oficina];
            }
            if (departamentos.ContainsKey(computador.Departamento))
            {
                computador.Departamento = departamentos[computador.Departamento];
            }

            return View(computador);
        }


        [HttpGet]
        public async Task<IActionResult> DetalleSoftware(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = await _contexto.Computadoras.FindAsync(id);
            if (computador == null)
            {
                return NotFound();
            }

            if (computador.FechaOffice.HasValue)
            {
                computador.FechaOffice = computador.FechaOffice.Value.Date;
            }

            return View(computador);
        }


        [HttpGet]
        public async Task<IActionResult> DetalleAdquisicion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = await _contexto.Computadoras.FindAsync(id);
            if (computador == null)
            {
                return NotFound();
            }

            if (computador.FechaAdquisicion.HasValue)
            {
                computador.FechaAdquisicion = computador.FechaAdquisicion.Value.Date;
            }

            return View(computador);
        }


        [HttpGet]
        public async Task<IActionResult> DetalleHardware(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = await _contexto.Computadoras
                .Include(c => c.Almacenamientos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (computador == null)
            {
                return NotFound();
            }

            return View(computador);
        }


        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = _contexto.Computadoras.Find(id);
            if (computador == null)
            {
                return NotFound();
            }

            var zonas = ObtenerZonas2();
            var departamentos = ObtenerDepartamentos2();

            if (zonas.ContainsKey(computador.Oficina))
            {
                computador.Oficina = zonas[computador.Oficina];
            }
            if (departamentos.ContainsKey(computador.Departamento))
            {
                computador.Departamento = departamentos[computador.Departamento];
            }

            return View(computador);
        }


        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarComputador(int? id)
        {
            var computadora = await _contexto.Computadoras
                .Include(c => c.Almacenamientos)
                .FirstOrDefaultAsync(c => c.Id == id); if (computadora == null)
            {
                return View();
            }

            _contexto.Almacenamientos.RemoveRange(computadora.Almacenamientos);
            _contexto.Computadoras.Remove(computadora);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}