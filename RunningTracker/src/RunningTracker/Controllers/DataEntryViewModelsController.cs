using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RunningTracker.Data;
using WebApplication2.Models.DataEntryModels;

namespace WebApplication2.Controllers
{
    public class DataEntryViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataEntryViewModelsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: DataEntryViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataEntryViewModel.ToListAsync());
        }

        // GET: DataEntryViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataEntryViewModel = await _context.DataEntryViewModel.SingleOrDefaultAsync(m => m.ID == id);
            if (dataEntryViewModel == null)
            {
                return NotFound();
            }

            return View(dataEntryViewModel);
        }

        // GET: DataEntryViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataEntryViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Heartrate,Steps,Username")] DataEntryViewModel dataEntryViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataEntryViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dataEntryViewModel);
        }

        // GET: DataEntryViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataEntryViewModel = await _context.DataEntryViewModel.SingleOrDefaultAsync(m => m.ID == id);
            if (dataEntryViewModel == null)
            {
                return NotFound();
            }
            return View(dataEntryViewModel);
        }

        // POST: DataEntryViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Heartrate,Steps,Username")] DataEntryViewModel dataEntryViewModel)
        {
            if (id != dataEntryViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataEntryViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataEntryViewModelExists(dataEntryViewModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(dataEntryViewModel);
        }

        // GET: DataEntryViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataEntryViewModel = await _context.DataEntryViewModel.SingleOrDefaultAsync(m => m.ID == id);
            if (dataEntryViewModel == null)
            {
                return NotFound();
            }

            return View(dataEntryViewModel);
        }

        // POST: DataEntryViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataEntryViewModel = await _context.DataEntryViewModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.DataEntryViewModel.Remove(dataEntryViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DataEntryViewModelExists(int id)
        {
            return _context.DataEntryViewModel.Any(e => e.ID == id);
        }
    }
}
