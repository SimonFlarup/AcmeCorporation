using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeCorporation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RESTController : ControllerBase
    {

        private readonly AcmeCorporationContext _context;

        public RESTController(AcmeCorporationContext context)
        {
            _context = context;
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
        [HttpGet]
        public IActionResult Create()
        {
            return NoContent();
        }

        // POST: Api/REST/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Email,Serial,Age")] DrawEntry drawEntry)
        {
            if (ModelState.IsValid & IsSerialAsync(drawEntry.Serial).Result & drawEntry.Age >= 18)
            {
                _context.Add(drawEntry);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return NoContent();
            //return "Error";
            //return View(drawEntry);
        }
    }
}