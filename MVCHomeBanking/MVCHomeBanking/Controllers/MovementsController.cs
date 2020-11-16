using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCHomeBanking.Context;
using MVCHomeBanking.Models;
using MVCHomeBanking.Models.MovementsEnums;

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

            var accountOrigin = _context.accounts.Where(acc => acc.movements.Contains(movement)).FirstOrDefault();


            if (movement == null || accountOrigin == null)
            {
                return NotFound();
            }

            ViewBag.accountOrigin = accountOrigin.accountId;


            return View(movement);
        }

        // GET: Movements/Create
        public IActionResult Create(string id)
        {

            List<TYPE_MOVEMENT> myTypes = Enum.GetValues(typeof(TYPE_MOVEMENT)).Cast<TYPE_MOVEMENT>().ToList();
            ViewBag.RequiredType = new SelectList(myTypes);

            ViewBag.originAccount = id;

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

                var originAccount = await _context.accounts.Include(a => a.movements)
                                .FirstOrDefaultAsync(m => m.accountId == movement.originAccountId);
                if (originAccount == null)
                {
                    return NotFound();
                }


                if (movement.type == TYPE_MOVEMENT.DEPOSIT)
                {
                    originAccount.balance = originAccount.balance + movement.value;
                    movement.status = STATUS_MOVEMENT.DEPOSIT_OK;
                }
                else if (movement.type == TYPE_MOVEMENT.EXTRACT)
                {
                    if (originAccount.balance > movement.value)
                    {
                        originAccount.balance = originAccount.balance - movement.value;
                        movement.status = STATUS_MOVEMENT.EXTRACT_OK;
                    } else
                    {
                        movement.status = STATUS_MOVEMENT.EXTRACT_FAILED;
                    }
                }
                else if (movement.type == TYPE_MOVEMENT.TRANSFER)
                {
                    var destinationAccount = await _context.accounts.Include(a => a.movements)
                                .FirstOrDefaultAsync(m => m.accountId == movement.destinationAccountId);

                    if (destinationAccount == null)
                    {
                        return NotFound();
                    }

                    if (destinationAccount.balance > movement.value)
                    {
                        originAccount.balance -= movement.value;
                        destinationAccount.balance += movement.value;
                        movement.status = STATUS_MOVEMENT.TRANSFER_OK;

                        Movement mov2 = new Movement();
                        mov2.value = movement.value;
                        mov2.type = movement.type;
                        mov2.status = movement.status;
                        mov2.originAccountId = movement.originAccountId;
                        mov2.destinationAccountId = movement.destinationAccountId;

                        destinationAccount.movements.Add(mov2);
                        _context.Add(mov2);
                    } else
                    {
                        movement.status = STATUS_MOVEMENT.TRANSFER_FAILED;
                    }
                }

                originAccount.movements.Add(movement);
                _context.Add(movement);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = movement.movementId });
            }
            return View(movement);
        }

    }
}
