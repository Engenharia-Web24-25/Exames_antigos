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
    public class VeiculosController : Controller
    {
        private readonly EW_NOR_2023Context _context;

        public VeiculosController(EW_NOR_2023Context context)
        {
            _context = context;
        }

        public IActionResult Adicionar(int Id)
        {
            ViewData["ProprietarioNome"] = _context.Proprietarios.Find(Id).Nome;
            ViewData["ProprietarioId"] = Id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar([Bind("Matricula,Marca,Modelo,ProprietarioId")] Veiculo veiculo)
        {
            if(_context.Veiculos.Find(veiculo.Matricula) != null)
            {
                ModelState.AddModelError("Matricula", "Matrícula já existente");
            }
            if (ModelState.IsValid)
            {
                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Detalhes", "Proprietarios", new { Id = veiculo.ProprietarioId });
            }

            ViewData["ProprietarioNome"] = _context.Proprietarios.Find(veiculo.ProprietarioId).Nome;
            ViewData["ProprietarioId"] = veiculo.ProprietarioId;
            return View(veiculo);
        }
    }
}
