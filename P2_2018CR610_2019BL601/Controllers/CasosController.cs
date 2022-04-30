using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2018CR610_2019BL601.Models;
using System.Collections.Generic;
using System.Linq;

namespace P2_2018CR610_2019BL601.Controllers
{
    public class CasosController : Controller
    {
        private readonly dbContext _context;

        public CasosController(dbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Departamentos> datosDepartamentos = from d in _context.departamentos select d;

            IEnumerable<Generos> generos = from g in _context.generos select g;

            List<SelectListItem> comboDepartamentos = new List<SelectListItem>();

            List<SelectListItem> comboGeneros = new List<SelectListItem>();

            foreach (Departamentos departamentos in datosDepartamentos)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = departamentos.departamento,
                    Value = departamentos.departamento_id.ToString()
                };

                comboDepartamentos.Add(miOpcion);
            }
            
            foreach (Generos genero in generos)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = genero.genero,
                    Value = genero.genero_id.ToString()
                };

                comboGeneros.Add(miOpcion);
            }

            ViewBag.comboDepartamentos = comboDepartamentos;
            ViewBag.comboGeneros = comboGeneros;

            IEnumerable<Casos> casos = (from c in _context.casos
                         join d in _context.departamentos on c.departamento_id equals d.departamento_id
                         join g in _context.generos on c.genero_id equals g.genero_id
                         select new Casos
                         {
                             departamento = d.departamento,
                             genero = g.genero,
                             confirmados = c.confirmados,
                             recuperados = c.recuperados,
                             fallecidos = c.fallecidos,
                         });

            return View(casos);
        }

        [HttpPost]
        public IActionResult Guardar(Casos datosForm)
        {
            var nuevo = new Casos()
            {
                departamento_id = datosForm.departamento_id,
                genero_id = datosForm.genero_id,
                confirmados = datosForm.confirmados,
                recuperados = datosForm.recuperados,
                fallecidos = datosForm.fallecidos
            };

            _context.casos.Add(nuevo);
            _context.SaveChanges();

            return RedirectToAction("Index", "Casos");
        }
    }
}
