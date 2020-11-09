using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCHomeBanking.Context;
using MVCHomeBanking.Models;

namespace MVCHomeBanking.Controllers
{
    public class MovementsController : Controller
    {
        private readonly HomeBankingContext _context;

        public MovementsController(HomeBankingContext context)
        {
            _context = context;
        }

        // GET: Movements
        public async Task<IActionResult> Index()
        {
            return View(await _context.movements.ToListAsync());
        }

        // GET: Movements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movement = await _context.movements
                .FirstOrDefaultAsync(m => m.movementId == id);
            if (movement == null)
            {
                return NotFound();
            }

            return View(movement);
        }

        // GET: Movements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("movementId,value,type,status,originAccountId,destinationAccountId")] Movement movement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movement);
        }

    }
}
