using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EW_NOR_2023.Data;
using EW_NOR_2023.Models;

namespace EW_NOR_2023.Controllers
{
    public class ProprietariosController : Controller
    {
        private readonly EW_NOR_2023Context _context;

        public ProprietariosController(EW_NOR_2023Context context)
        {
            _context = context;
        }

        // GET: Proprietarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proprietarios.Include(v => v.Veiculos).ToListAsync());
        }

        public async Task<IActionResult> Ordena()
        {
            if (HttpContext.Session.Keys.Contains("ordem") == false || HttpContext.Session.GetString("ordem") == "decrescente")
            {
                HttpContext.Session.SetString("ordem", "crescente");
                return PartialView("Listagem", await _context.Proprietarios.Include(v => v.Veiculos).OrderBy(x => x.Nome).ToListAsync());
            } 
            else {
                HttpContext.Session.SetString("ordem", "decrescente");
                return PartialView("Listagem", await _context.Proprietarios.Include(v => v.Veiculos).OrderByDescending(x => x.Nome).ToListAsync());
            } 
        }

        // GET: Proprietarios/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietario = await _context.Proprietarios.Include(v=>v.Veiculos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proprietario == null)
            {
                return NotFound();
            }

            return View(proprietario);
        }
    }
}
