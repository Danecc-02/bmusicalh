using bmusicalh.Data;
using bmusicalh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bmusicalh.Controllers
{
    public class BandasMusicController : Controller
    {
        private readonly ApplicationDbContext db;

        public BandasMusicController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.BandasMusics.ToListAsync());

        }


        //crear por medio de vista

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BandaMusic bandaMusic)
        {
            if (ModelState.IsValid)
            {
                db.Add(bandaMusic);
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(bandaMusic);
        }

        /////////////////////////////////////////////////////////////////////////////


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depart = await db.BandasMusics.FirstOrDefaultAsync(d => d.BandaMusicId == id);
            if (depart == null)
            {
                return NotFound();
            }

            return View(depart);

        }

        //////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depart = await db.BandasMusics.FindAsync(id);
            if (depart == null)
            {
                return NotFound();
            }

            return View(depart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BandaMusic banda)
        {
            if (id != banda.BandaMusicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(banda);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }

                return RedirectToAction(nameof(Index));
            }

            return View(banda);
        }


        //////////////////////////////////////////////////////////////////////////
        ///

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depart = await db.BandasMusics.FirstOrDefaultAsync(m => m.BandaMusicId == id);

            if (depart == null)
            {
                return NotFound();
            }

            return View(depart);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var depart = await db.BandasMusics.FindAsync(id);
            db.BandasMusics.Remove(depart);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
