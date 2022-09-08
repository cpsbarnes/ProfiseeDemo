using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfiseeDemo.Data;
using ProfiseeDemo.Models;

namespace ProfiseeDemo.Controllers
{
    public class SalesPersonsController : Controller
    {
        private readonly ProfiseeDemoContext _context;

        public SalesPersonsController(ProfiseeDemoContext context)
        {
            _context = context;
        }

        // GET: SalesPersons
        public async Task<IActionResult> Index()
        {
              return _context.SalesPerson != null ? 
                          View(await _context.SalesPerson.ToListAsync()) :
                          Problem("Entity set 'ProfiseeDemoContext.SalesPerson'  is null.");
        }

        // GET: SalesPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesPerson == null)
            {
                return NotFound();
            }

            var salesPerson = await _context.SalesPerson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesPerson == null)
            {
                return NotFound();
            }

            return View(salesPerson);
        }

        // GET: SalesPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Phone,StartDate,TermDate,Manager")] SalesPerson salesPerson)
        {
            ViewBag.Message = "";
            TempData["Message"] = "";
            bool blUserExist = false;
            int iLast = 0;
            int iFirst = 0;
            var resultLastName = _context.SalesPerson.Where(c => c.LastName == salesPerson.LastName);
            var resultFirstName = _context.SalesPerson.Where(c => c.FirstName == salesPerson.FirstName);
            iLast = resultLastName.Count();
            iFirst = resultFirstName.Count();   


            
            //If the lastname and firstname exist, assuming this is the same employee. 
            if(iLast != 0)
            {
                if(iFirst != 0)
                {
                    blUserExist = true;
                }
            }

            if (blUserExist)
            {
                ViewBag.Message = "Sales Person Already Exists";

            }
            else
            { 
                if (ModelState.IsValid)
                {
                    _context.Add(salesPerson);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(salesPerson);
        }

        // GET: SalesPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalesPerson == null)
            {
                return NotFound();
            }

            var salesPerson = await _context.SalesPerson.FindAsync(id);
            if (salesPerson == null)
            {
                return NotFound();
            }
            return View(salesPerson);
        }

        // POST: SalesPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Phone,StartDate,TermDate,Manager")] SalesPerson salesPerson)
        {
            if (id != salesPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesPersonExists(salesPerson.Id))
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
            return View(salesPerson);
        }

        // GET: SalesPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalesPerson == null)
            {
                return NotFound();
            }

            var salesPerson = await _context.SalesPerson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesPerson == null)
            {
                return NotFound();
            }

            return View(salesPerson);
        }

        // POST: SalesPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalesPerson == null)
            {
                return Problem("Entity set 'ProfiseeDemoContext.SalesPerson'  is null.");
            }
            var salesPerson = await _context.SalesPerson.FindAsync(id);
            if (salesPerson != null)
            {
                _context.SalesPerson.Remove(salesPerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesPersonExists(int id)
        {
          return (_context.SalesPerson?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
