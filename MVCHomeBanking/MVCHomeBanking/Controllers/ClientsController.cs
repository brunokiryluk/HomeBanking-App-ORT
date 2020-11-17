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
    public class ClientsController : Controller
    {
        private readonly HomeBankingContext _context;

        public ClientsController(HomeBankingContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context.users.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.users.Include(u => u.accounts)
                .FirstOrDefaultAsync(m => m.nroDoc == id);
            if (client == null)
            {
                return NotFound();
            }


            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nroDoc,name,surname,phone,username,password")] Client client)
        {
            if (ModelState.IsValid)
            {
                Account acc = new Account();
                acc.balance = 2000;
                acc.direccion = "EMPTY";
                acc.movements = new List<Movement>();

                _context.Add(acc);
                await _context.SaveChangesAsync();


                Movement mov = new Movement();
                mov.value = 2000;
                mov.originAccountId = acc.accountId;
                mov.destinationAccountId = acc.accountId;
                mov.type = Models.MovementsEnums.TYPE_MOVEMENT.DEPOSIT;
                mov.status = Models.MovementsEnums.STATUS_MOVEMENT.DEPOSIT_OK;

                acc.movements.Add(mov);

                client.accounts = new List<Account>();
                
                client.accounts.Add(acc);

                _context.Add(mov);
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = client.nroDoc });
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.users.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("nroDoc,name,surname,phone,username,password")] Client client)
        {
            if (id != client.nroDoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.nroDoc))
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
            return View(client);
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("username,password")] Client clientForm)
        {

            if (clientForm == null 
                || clientForm.username == null
                || clientForm.password == null)
            {
                ViewBag.showError = "Formulario incompleto. Por favor llené los campos para continuar";
                return Login();
            }

            var client = await _context.users
                .FirstOrDefaultAsync(m => m.username == clientForm.username);

            Console.WriteLine(client);

            if (client == null)
            {
                ViewBag.showError = "No se pudo encontrar al cliente";
                return Login();
            }

            if (!client.password.Equals(clientForm.password))
            {
                ViewBag.showError = "Usuario/password erroneo";
                return Login();
            }


            return RedirectToAction("Details", new { id = client.nroDoc });

        }


        private bool ClientExists(string id)
        {
            return _context.users.Any(e => e.nroDoc == id);
        }
    }
}
