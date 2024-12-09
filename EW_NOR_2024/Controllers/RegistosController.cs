using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EW_NOR_2024.Data;
using EW_NOR_2024.Models;

namespace EW_NOR_2024.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 100)]
    public class RegistosController : Controller
    {
        private readonly EW_NOR_2024Context _context;

        public RegistosController(EW_NOR_2024Context context)
        {
            _context = context;   
        }

        // GET: Registos
        public async Task<IActionResult> Lista()
        {
            //HttpContext.Session.SetString("estado", "editar"); // só para experimentar a última pergunta
            return View(await _context.RegistoUtilizador.ToListAsync());
        }

        public async Task<IActionResult> Valida(int? id)
        {
            RegistoUtilizador utilizador = _context.RegistoUtilizador.Find(id);

            utilizador.Valido = true;

            _context.RegistoUtilizador.Update(utilizador);

            await _context.SaveChangesAsync();

            return PartialView("Listagem", await _context.RegistoUtilizador.ToListAsync());
        }

        public async Task<IActionResult> Invalida(int? id)
        {
            RegistoUtilizador utilizador = _context.RegistoUtilizador.Find(id);

            utilizador.Valido = false;

            _context.RegistoUtilizador.Update(utilizador);

            await _context.SaveChangesAsync();

            return PartialView("Listagem", await _context.RegistoUtilizador.ToListAsync());
        }



        // GET: Registos/Adiciona
        public IActionResult Adiciona()
        {
            return View();
        }

        // POST: Registos/Adiciona
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adiciona([Bind("RegistoId,Nome,Regime,Valido")] RegistoUtilizador registoUtilizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registoUtilizador);
                await _context.SaveChangesAsync();

                TempData["msgOK"] = "Utilizador registado com sucesso!";

                return RedirectToAction(nameof(Lista));
            }
            return View(registoUtilizador);
        }

       
    }
}
