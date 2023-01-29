using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Security.Claims;
using TestCrud.Areas.Identity.Data;
using TestCrud.Data;
using TestCrud.Models;

namespace TestCrud.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DbContext _dbContext;
        private readonly UserManager<User> _user;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DbContext dbContext, UserManager<User> user)
        {
            _logger = logger;
            _dbContext = dbContext;
            _user = user;
        }

        public async Task<IActionResult> Index()
        {
            var loggedUser = await _user.FindByNameAsync(User.Identity.Name);
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == loggedUser.Id);

            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}