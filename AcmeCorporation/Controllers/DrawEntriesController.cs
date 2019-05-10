using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcmeCorporation.Models;
using Microsoft.AspNetCore.Authorization;

namespace AcmeCorporation.Controllers
{
    public class DrawEntriesController : Controller
    {
        private readonly AcmeCorporationContext _context;

        public DrawEntriesController(AcmeCorporationContext context)
        {
            _context = context;
        }

        // GET: DrawEntries
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Submissions()
        {
            return View(await _context.DrawEntry.ToListAsync());
        }

        // GET: DrawEntries/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawEntry = await _context.DrawEntry
                .FirstOrDefaultAsync(m => m.ID == id);
            if (drawEntry == null)
            {
                return NotFound();
            }

            return View(drawEntry);
        }

        //Returns true is the entered serial is valid and hasn't been used twice.
        private async Task<bool> IsSerialAsync(string serial)
        {
            var returnBool = false;
            var serials = from s in _context.Serial
                         select s;
            foreach (var item in serials)
            {
                if (item.ID.Equals(serial))
                {
                    returnBool = true;
                }
            }
            if (returnBool)
            {
                returnBool = false;
                IQueryable<string> serialQuery = from d in _context.DrawEntry
                                                 select d.Serial;
                IList<string> submittedSerials = await serialQuery.ToListAsync();
                var counter = 0;
                foreach (var item in submittedSerials)
                {
                    if (item.Equals(serial))
                    {
                        counter++;
                    }
                }
                if (counter < 2)
                {
                    returnBool = true;
                }
            }
            return returnBool;
        }

        // GET: DrawEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DrawEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Email,Serial,Age")] DrawEntry drawEntry)
        {
            if (ModelState.IsValid & IsSerialAsync(drawEntry.Serial).Result & drawEntry.Age >= 18)
            {
                _context.Add(drawEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Error"] = "Your submission have not been accepted";
            return View(drawEntry);
        }

        // GET: DrawEntries/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawEntry = await _context.DrawEntry.FindAsync(id);
            if (drawEntry == null)
            {
                return NotFound();
            }
            return View(drawEntry);
        }

        // POST: DrawEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,Serial")] DrawEntry drawEntry)
        {
            if (id != drawEntry.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drawEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrawEntryExists(drawEntry.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Submissions));
            }
            return View(drawEntry);
        }

        // GET: DrawEntries/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawEntry = await _context.DrawEntry
                .FirstOrDefaultAsync(m => m.ID == id);
            if (drawEntry == null)
            {
                return NotFound();
            }

            return View(drawEntry);
        }

        // POST: DrawEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drawEntry = await _context.DrawEntry.FindAsync(id);
            _context.DrawEntry.Remove(drawEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Submissions));
        }

        private bool DrawEntryExists(int id)
        {
            return _context.DrawEntry.Any(e => e.ID == id);
        }
    }
}
