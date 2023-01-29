using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using TestCrud.Areas.Identity.Data;
using TestCrud.Data;

namespace TestCrud.Controllers
{
    public class AdminController : Controller
    {
        private readonly DbContext _dbContext;
        private readonly UserManager<User> _user;

        public AdminController(DbContext dbContext, UserManager<User> user)
        {
            _dbContext = dbContext;
            _user = user;
        }

        public async Task<IActionResult> Index()
        {
            var loggedUser = await _user.FindByNameAsync(User.Identity.Name);
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == loggedUser.Id);
            ViewBag.isAdmin = loggedUser.isAdmin;
            var userList = _dbContext.Users.ToList();

            return View(userList);
        }

        [HttpGet]
        public IActionResult Edit(string userId)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            return View(existingUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);

                if (existingUser == null)
                {
                    return NotFound();
                }
                existingUser.isAdmin = user.isAdmin;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(string userId)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

            if (existingUser == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(existingUser);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
