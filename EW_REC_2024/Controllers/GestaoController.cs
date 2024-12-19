using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EW_REC_2024.Data;
using EW_REC_2024.Models;
using Microsoft.AspNetCore.Routing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EW_REC_2024.Controllers
{
    public class GestaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GestaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gestao
        public async Task<IActionResult> Notas()
        {
            return View(await _context.RegistoNota.ToListAsync());
        }

        public async Task<string> Validar(int? id)
        {
            if (id == null)
            {
                return "";
            }

            var registoNota = await _context.RegistoNota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registoNota == null)
            {
                return "";
            }

            registoNota.ALxxxxx = User.Identity.Name;
            _context.RegistoNota.Update(registoNota);
            await _context.SaveChangesAsync();

            return "<td>" + registoNota.NumAluno + "</td><td>" + registoNota.ALxxxxx + "</td><td>" + registoNota.Nota + "</td><td></td>";
        }

        public async Task<string> Remover(int? id)
        {
            if (id == null)
            {
                return "";
            }

            var registoNota = await _context.RegistoNota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registoNota == null)
            {
                return "";
            }

            _context.RegistoNota.Remove(registoNota);
            await _context.SaveChangesAsync();

            return "";
        }

        public IActionResult Inserir()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inserir([Bind("Id,NumAluno,Nota")] RegistoNota registoNota)
        {
            if (_context.RegistoNota.Any(x => x.NumAluno == registoNota.NumAluno))
                ModelState.AddModelError("NumAluno", "Esse aluno já possui nota!");

            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                    registoNota.ALxxxxx = User.Identity.Name;
                else
                    registoNota.ALxxxxx = "Anónimo";
                        
                _context.Add(registoNota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Notas));
            }
            return View(registoNota);
        }

        // GET: Gestao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoNota = await _context.RegistoNota.FindAsync(id);
            if (registoNota == null)
            {
                return NotFound();
            }
            return View(registoNota);
        }

        // POST: Gestao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumAluno,Nota,ALxxxxx")] RegistoNota registoNota)
        {
            if (id != registoNota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registoNota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistoNotaExists(registoNota.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registoNota);
        }

        // GET: Gestao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoNota = await _context.RegistoNota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registoNota == null)
            {
                return NotFound();
            }

            return View(registoNota);
        }

        // POST: Gestao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registoNota = await _context.RegistoNota.FindAsync(id);
            if (registoNota != null)
            {
                _context.RegistoNota.Remove(registoNota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistoNotaExists(int id)
        {
            return _context.RegistoNota.Any(e => e.Id == id);
        }
    }
}
