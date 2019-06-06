using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTypeScript.Models;
using CrudApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CrudApp.Controllers
{
    [Authorize]
    public class ApplesController : Controller
    {
        private readonly CrudAppContext _context;

        public ApplesController(CrudAppContext context)
        {
            _context = context;
        }

        // GET: Apples
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apple.ToListAsync());
        }

        // GET: Apples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apple = await _context.Apple
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apple == null)
            {
                return NotFound();
            }

            return View(apple);
        }

        // GET: Apples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Variety")] Apple apple)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apple);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apple);
        }

        // GET: Apples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apple = await _context.Apple.FindAsync(id);
            if (apple == null)
            {
                return NotFound();
            }
            return View(apple);
        }

        // POST: Apples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Variety")] Apple apple)
        {
            if (id != apple.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apple);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppleExists(apple.Id))
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
            return View(apple);
        }

        // GET: Apples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apple = await _context.Apple
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apple == null)
            {
                return NotFound();
            }

            return View(apple);
        }

        // POST: Apples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apple = await _context.Apple.FindAsync(id);
            _context.Apple.Remove(apple);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppleExists(int id)
        {
            return _context.Apple.Any(e => e.Id == id);
        }
    }
}
