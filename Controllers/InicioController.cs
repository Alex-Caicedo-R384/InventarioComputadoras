using InventarioComputadoras.Datos;
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
            new SelectListItem { Value = "Office 2019", Text = "Office 2019" },
            new SelectListItem { Value = "Office 2021", Text = "Office 2021" },
            new SelectListItem { Value = "Office 365", Text = "Office 365" }
        };
        }

        private List<SelectListItem> ObtenerAntivirus()
        {
            return new List<SelectListItem>
        {
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
            ViewBag.Zonas = ObtenerZonas();
            ViewBag.Departamentos = ObtenerDepartamentos();
            ViewBag.sistemaoperativo = ObtenerSistemaOperativo();
            ViewBag.office = ObtenerOffice();
            ViewBag.antivirus = ObtenerAntivirus();
            ViewBag.dominio = ObtenerDominio();
            ViewBag.estado = ObtenerEstado();

            return View();
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
            ViewBag.estado = ObtenerEstado();


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
                return RedirectToAction(nameof(Index));
            }

            return View(computadora);
        }



    [HttpGet]
        public IActionResult Editar(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var computador = _contexto.Computadoras.Find(Id);
            if (computador == null)
            {
                return NotFound();
            }

            ViewBag.Zonas = ObtenerZonas();
            ViewBag.Departamentos = ObtenerDepartamentos();
            ViewBag.sistemaoperativo = ObtenerSistemaOperativo();
            ViewBag.office = ObtenerOffice();
            ViewBag.antivirus = ObtenerAntivirus();
            ViewBag.dominio = ObtenerDominio();


            return View(computador);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Computadora computadora, bool sinNombreAnterior, bool sinDireccionIP)
        {
            ViewBag.Zonas = ObtenerZonas();
            ViewBag.Departamentos = ObtenerDepartamentos();
            ViewBag.sistemaoperativo = ObtenerSistemaOperativo();
            ViewBag.office = ObtenerOffice();
            ViewBag.antivirus = ObtenerAntivirus();

            if (ModelState.IsValid)
            {
                try
                {
                    var computadoraExistente = await _contexto.Computadoras.FindAsync(computadora.Id);

                    if (computadoraExistente == null)
                    {
                        return NotFound();
                    }

                    bool nombreCambiado = computadoraExistente.Departamento != computadora.Departamento ||
                                          computadoraExistente.Oficina != computadora.Oficina;

                    if (nombreCambiado)
                    {
                        string nombreBase = computadora.Departamento.Substring(0, 4) + computadora.Oficina.Substring(0, 3);

                        var ultimaComputadora = await _contexto.Computadoras
                            .Where(c => c.NombreNuevo.StartsWith(nombreBase))
                            .OrderByDescending(c => c.NombreNuevo)
                            .FirstOrDefaultAsync();

                        int ultimoNumero = 0;
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

                    computadoraExistente.Departamento = computadora.Departamento;
                    computadoraExistente.Oficina = computadora.Oficina;

                    if (!sinDireccionIP)
                    {
                        computadoraExistente.DireccionIp = computadora.DireccionIp;
                    }
                    else
                    {
                        computadoraExistente.DireccionIp = "Sin Direccion IP";
                    }

                    await _contexto.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Error al guardar los cambios. Inténtalo de nuevo y, si el problema persiste, consulta al administrador del sistema.");
                }
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

        public async Task<IActionResult> BorrarContacto (int? id)
        {
            var computadora = await _contexto.Computadoras.FindAsync(id);
            if (computadora == null)
            {
                return View();
            }

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