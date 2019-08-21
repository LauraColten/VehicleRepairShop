using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VehicleRepairShop.Models;

namespace VehicleRepairShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly VehicleRepairShopContext _context;
        private readonly UserManager<User> _userManager;

        public UsersController(VehicleRepairShopContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        public ActionResult Details(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new Exception();
            var newUser = ConvertFromDatabase(new[] { user }).First();
            return View(newUser);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel user)
        {
            try
            {
                var newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.EmailAddress,
                    UserName = user.EmailAddress, 
                    TypeId = (int)user.Type

                };

                var result = await _userManager.CreateAsync(newUser);
                if (!result.Succeeded)
                {
                    throw new Exception();
                }

                var newRole = string.Empty;
                switch(user.Type)
                {
                    case UserType.Administrator:
                        newRole = Constants.Roles.Admin;
                        break;
                    case UserType.Technician:
                        newRole = Constants.Roles.Tech;
                        break;
                    case UserType.User:
                        newRole = Constants.Roles.User;
                        break;
                    default:
                        break;
                }
                await _userManager.AddToRoleAsync(newUser, newRole);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            //if (ModelState.IsValid)
            {
                //_context.Add(user);
                //await _context.SaveChangesAsync();

                //foreach (var type in userTypes)
                //{
                    //_context.Add(new User()
                    //{
                    //    FirstName = user.FirstName,
                    //    LastName = user.LastName,
                    //    Email = user.Email,
                    //    TypeId = user.TypeId
                    //});
                //}
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            //return View();
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