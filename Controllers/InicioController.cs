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

        public InicioController(AppDBContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
                        Dictionary<string, string> zonas = new Dictionary<string, string>
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

                        Dictionary<string, string> departamentos = new Dictionary<string, string>
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
            List<SelectListItem> zonas = new List<SelectListItem>
        {
            new SelectListItem { Value = "TUL", Text = "Tulcán" },
            new SelectListItem { Value = "MUL", Text = "Multiplaza" },
            new SelectListItem { Value = "AMA", Text = "Amazonas" },
            new SelectListItem { Value = "MAY", Text = "Mayorista" },
            new SelectListItem { Value = "ATU", Text = "Atuntaqui" },
            new SelectListItem { Value = "SAG", Text = "San Gabriel" },
            new SelectListItem { Value = "BOL", Text = "Bolívar" },
            new SelectListItem { Value = "QUI", Text = "Quito" },
            new SelectListItem { Value = "IBA", Text = "Ibarra" },
            new SelectListItem { Value = "LAG", Text = "Nuevo Lago" },
            new SelectListItem { Value = "MIR", Text = "Mira" }
        };

            List<SelectListItem> departamentos = new List<SelectListItem>
        {
            new SelectListItem { Value = "ATEN", Text = "Atención al Cliente" },
            new SelectListItem { Value = "AUDI", Text = "Auditoria" },
            new SelectListItem { Value = "CAJA", Text = "Cajas" },
            new SelectListItem { Value = "CALL", Text = "CallCenter" },
            new SelectListItem { Value = "COBR", Text = "Cobranzas" },
            new SelectListItem { Value = "CONT", Text = "Contabilidad" },
            new SelectListItem { Value = "CRED", Text = "Crédito" },
            new SelectListItem { Value = "CUMP", Text = "Cumplimiento" },
            new SelectListItem { Value = "GERE", Text = "Gerencia General" },
            new SelectListItem { Value = "INVE", Text = "Inversiones" },
            new SelectListItem { Value = "JURI", Text = "Jurídico" },
            new SelectListItem { Value = "MARK", Text = "Mercadeo" },
            new SelectListItem { Value = "MERC", Text = "Marketing" },
            new SelectListItem { Value = "OPER", Text = "Jefe de Operaciones y Procesos" },
            new SelectListItem { Value = "PROS", Text = "Oficial de Operaciones y Procesos" },
            new SelectListItem { Value = "RIES", Text = "Riesgos" },
            new SelectListItem { Value = "SECR", Text = "Secretaria" },
            new SelectListItem { Value = "SEGU", Text = "Seguridad" },
            new SelectListItem { Value = "SMED", Text = "Servicio Médico" },
            new SelectListItem { Value = "SUBG", Text = "SubGerencia" },
            new SelectListItem { Value = "TECN", Text = "T.I" },
            new SelectListItem { Value = "TTHH", Text = "Talento Humano" }
        };

            ViewBag.Zonas = zonas;
            ViewBag.Departamentos = departamentos;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Computadora computadora, bool sinNombreAnterior, bool sinDireccionIP)
        {
            List<SelectListItem> zonas = new List<SelectListItem>
        {
            new SelectListItem { Value = "TUL", Text = "Tulcán" },
            new SelectListItem { Value = "MUL", Text = "Multiplaza" },
            new SelectListItem { Value = "AMA", Text = "Amazonas" },
            new SelectListItem { Value = "MAY", Text = "Mayorista" },
            new SelectListItem { Value = "ATU", Text = "Atuntaqui" },
            new SelectListItem { Value = "SAG", Text = "San Gabriel" },
            new SelectListItem { Value = "BOL", Text = "Bolívar" },
            new SelectListItem { Value = "QUI", Text = "Quito" },
            new SelectListItem { Value = "IBA", Text = "Ibarra" },
            new SelectListItem { Value = "LAG", Text = "Nuevo Lago" },
            new SelectListItem { Value = "MIR", Text = "Mira" }
        };

            List<SelectListItem> departamentos = new List<SelectListItem>
        {
            new SelectListItem { Value = "ATEN", Text = "Atención al Cliente" },
            new SelectListItem { Value = "AUDI", Text = "Auditoria" },
            new SelectListItem { Value = "CAJA", Text = "Cajas" },
            new SelectListItem { Value = "CALL", Text = "CallCenter" },
            new SelectListItem { Value = "COBR", Text = "Cobranzas" },
            new SelectListItem { Value = "CONT", Text = "Contabilidad" },
            new SelectListItem { Value = "CRED", Text = "Crédito" },
            new SelectListItem { Value = "CUMP", Text = "Cumplimiento" },
            new SelectListItem { Value = "GERE", Text = "Gerencia General" },
            new SelectListItem { Value = "INVE", Text = "Inversiones" },
            new SelectListItem { Value = "JURI", Text = "Jurídico" },
            new SelectListItem { Value = "MARK", Text = "Mercadeo" },
            new SelectListItem { Value = "MERC", Text = "Marketing" },
            new SelectListItem { Value = "OPER", Text = "Jefe de Operaciones y Procesos" },
            new SelectListItem { Value = "PROS", Text = "Oficial de Operaciones y Procesos" },
            new SelectListItem { Value = "RIES", Text = "Riesgos" },
            new SelectListItem { Value = "SECR", Text = "Secretaria" },
            new SelectListItem { Value = "SEGU", Text = "Seguridad" },
            new SelectListItem { Value = "SMED", Text = "Servicio Médico" },
            new SelectListItem { Value = "SUBG", Text = "SubGerencia" },
            new SelectListItem { Value = "TECN", Text = "T.I" },
            new SelectListItem { Value = "TTHH", Text = "Talento Humano" }
        };

            ViewBag.Zonas = zonas;
            ViewBag.Departamentos = departamentos;

            if (sinNombreAnterior)
            {
                computadora.NombreAnterior = "Sin nombre anterior";
            }

            if (sinDireccionIP)
            {
                computadora.DireccionIp = "Sin Direccion IP";
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
            List<SelectListItem> zonas = new List<SelectListItem>
            {
                new SelectListItem { Value = "TUL", Text = "Tulcán" },
                new SelectListItem { Value = "MUL", Text = "Multiplaza" },
                new SelectListItem { Value = "AMA", Text = "Amazonas" },
                new SelectListItem { Value = "MAY", Text = "Mayorista" },
                new SelectListItem { Value = "ATU", Text = "Atuntaqui" },
                new SelectListItem { Value = "SAG", Text = "San Gabriel" },
                new SelectListItem { Value = "BOL", Text = "Bolívar" },
                new SelectListItem { Value = "QUI", Text = "Quito" },
                new SelectListItem { Value = "IBA", Text = "Ibarra" },
                new SelectListItem { Value = "LAG", Text = "Nuevo Lago" },
                new SelectListItem { Value = "MIR", Text = "Mira" }
            };

            List<SelectListItem> departamentos = new List<SelectListItem>
        {
            new SelectListItem { Value = "ATEN", Text = "Atención al Cliente" },
            new SelectListItem { Value = "AUDI", Text = "Auditoria" },
            new SelectListItem { Value = "CAJA", Text = "Cajas" },
            new SelectListItem { Value = "CALL", Text = "CallCenter" },
            new SelectListItem { Value = "COBR", Text = "Cobranzas" },
            new SelectListItem { Value = "CONT", Text = "Contabilidad" },
            new SelectListItem { Value = "CRED", Text = "Crédito" },
            new SelectListItem { Value = "CUMP", Text = "Cumplimiento" },
            new SelectListItem { Value = "GERE", Text = "Gerencia General" },
            new SelectListItem { Value = "INVE", Text = "Inversiones" },
            new SelectListItem { Value = "JURI", Text = "Jurídico" },
            new SelectListItem { Value = "MARK", Text = "Mercadeo" },
            new SelectListItem { Value = "MERC", Text = "Marketing" },
            new SelectListItem { Value = "OPER", Text = "Jefe de Operaciones y Procesos" },
            new SelectListItem { Value = "PROS", Text = "Oficial de Operaciones y Procesos" },
            new SelectListItem { Value = "RIES", Text = "Riesgos" },
            new SelectListItem { Value = "SECR", Text = "Secretaria" },
            new SelectListItem { Value = "SEGU", Text = "Seguridad" },
            new SelectListItem { Value = "SMED", Text = "Servicio Médico" },
            new SelectListItem { Value = "SUBG", Text = "SubGerencia" },
            new SelectListItem { Value = "TECN", Text = "T.I" },
            new SelectListItem { Value = "TTHH", Text = "Talento Humano" }
        };

            ViewBag.Zonas = zonas;
            ViewBag.Departamentos = departamentos;

            return View(computador);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Computadora computadora, bool sinNombreAnterior, bool sinDireccionIP)
        {
            List<SelectListItem> zonas = new List<SelectListItem>
            {
                new SelectListItem { Value = "TUL", Text = "Tulcán" },
                new SelectListItem { Value = "MUL", Text = "Multiplaza" },
                new SelectListItem { Value = "AMA", Text = "Amazonas" },
                new SelectListItem { Value = "MAY", Text = "Mayorista" },
                new SelectListItem { Value = "ATU", Text = "Atuntaqui" },
                new SelectListItem { Value = "SAG", Text = "San Gabriel" },
                new SelectListItem { Value = "BOL", Text = "Bolívar" },
                new SelectListItem { Value = "QUI", Text = "Quito" },
                new SelectListItem { Value = "IBA", Text = "Ibarra" },
                new SelectListItem { Value = "LAG", Text = "Nuevo Lago" },
                new SelectListItem { Value = "MIR", Text = "Mira" }
            };

            List<SelectListItem> departamentos = new List<SelectListItem>
            {
                new SelectListItem { Value = "ATEN", Text = "Atención al Cliente" },
                new SelectListItem { Value = "AUDI", Text = "Auditoria" },
                new SelectListItem { Value = "CAJA", Text = "Cajas" },
                new SelectListItem { Value = "CALL", Text = "CallCenter" },
                new SelectListItem { Value = "COBR", Text = "Cobranzas" },
                new SelectListItem { Value = "CONT", Text = "Contabilidad" },
                new SelectListItem { Value = "CRED", Text = "Crédito" },
                new SelectListItem { Value = "CUMP", Text = "Cumplimiento" },
                new SelectListItem { Value = "GERE", Text = "Gerencia General" },
                new SelectListItem { Value = "INVE", Text = "Inversiones" },
                new SelectListItem { Value = "JURI", Text = "Jurídico" },
                new SelectListItem { Value = "MARK", Text = "Mercadeo" },
                new SelectListItem { Value = "MERC", Text = "Marketing" },
                new SelectListItem { Value = "OPER", Text = "Jefe de Operaciones y Procesos" },
                new SelectListItem { Value = "PROS", Text = "Oficial de Operaciones y Procesos" },
                new SelectListItem { Value = "RIES", Text = "Riesgos" },
                new SelectListItem { Value = "SECR", Text = "Secretaria" },
                new SelectListItem { Value = "SEGU", Text = "Seguridad" },
                new SelectListItem { Value = "SMED", Text = "Servicio Médico" },
                new SelectListItem { Value = "SUBG", Text = "SubGerencia" },
                new SelectListItem { Value = "TECN", Text = "T.I" },
                new SelectListItem { Value = "TTHH", Text = "Talento Humano" }
            };

            ViewBag.Zonas = zonas;
            ViewBag.Departamentos = departamentos;

            if (ModelState.IsValid)
            {
                try
                {
                    var computadoraExistente = await _contexto.Computadoras.FindAsync(computadora.Id);

                    if (computadoraExistente == null)
                    {
                        return NotFound();
                    }

                    if (sinNombreAnterior)
                    {
                        computadoraExistente.NombreAnterior = "Sin nombre anterior";
                    }
                    else if (computadoraExistente.NombreNuevo != computadoraExistente.NombreAnterior)
                    {
                        computadoraExistente.NombreAnterior = computadoraExistente.NombreNuevo;
                    }

                    if (sinDireccionIP)
                    {
                        computadoraExistente.DireccionIp = "Sin Direccion IP";
                    }

                    if (!sinDireccionIP)
                    {
                        var ipExistente = await _contexto.Computadoras
                            .AnyAsync(c => c.Id != computadora.Id && c.DireccionIp == computadora.DireccionIp);

                        if (ipExistente)
                        {
                            ModelState.AddModelError("DireccionIp", "Esta dirección IP ya está en uso.");
                            return View(computadora);
                        }
                    }

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

                    string nombreNuevo = nombreBase + " " + (ultimoNumero + 1);

                    computadoraExistente.NombreNuevo = nombreNuevo;

                    _contexto.Update(computadoraExistente);
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
        public async Task<IActionResult> Detalle(int? id)
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

            Dictionary<string, string> zonas = new Dictionary<string, string>
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

            Dictionary<string, string> departamentos = new Dictionary<string, string>
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
    }
}