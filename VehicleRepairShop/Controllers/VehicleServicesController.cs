﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleRepairShop.Models;

namespace VehicleRepairShop.Controllers

{
    public class VehicleServicesController : Controller
    {
        private readonly VehicleRepairShopContext _context;

        public VehicleServicesController(VehicleRepairShopContext context)
        {
            _context = context;
        }

        // GET: VehicleServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleService.ToListAsync());
        }

        // GET: VehicleServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleService = await _context.VehicleService
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleService == null)
            {
                return NotFound();
            }

            return View(vehicleService);
        }

        // GET: VehicleServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PartList")] VehicleService vehicleService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleService);
        }

        // GET: VehicleServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleService = await _context.VehicleService.FindAsync(id);
            if (vehicleService == null)
            {
                return NotFound();
            }
            return View(vehicleService);
        }

        // POST: VehicleServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PartList")] VehicleService vehicleService)
        {
            if (id != vehicleService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleServiceExists(vehicleService.Id))
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
            return View(vehicleService);
        }

        // GET: VehicleServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleService = await _context.VehicleService
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleService == null)
            {
                return NotFound();
            }

            return View(vehicleService);
        }

        // POST: VehicleServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleService = await _context.VehicleService.FindAsync(id);
            _context.VehicleService.Remove(vehicleService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleServiceExists(int id)
        {
            return _context.VehicleService.Any(e => e.Id == id);
        }
    }
}
