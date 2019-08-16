using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleRepairShop.Models;

namespace VehicleRepairShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly VehicleRepairShopContext _context;

        public UsersController(VehicleRepairShopContext context)
        {
            _context = context;
        }
        // GET: Users
        public ActionResult Index()
        {
            var users = ConvertFromDatabase(_context.Users.ToArray());
            return View(users);
        }

        private IEnumerable<UserViewModel> ConvertFromDatabase(IEnumerable<User> users)
        {
            return users.Select(u => new UserViewModel()
            { 
                EmailAddress = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Id = u.Id,
                Type =(UserType)u.TypeId
            }).ToList();
        }
        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user, IEnumerable<UserType> userTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();

                foreach (var type in userTypes)
                {
                    _context.Add(new UserViewModel()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EmailAddress = user.Email,
                        Type = type
                    });
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTypes);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}