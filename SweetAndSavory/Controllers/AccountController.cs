using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SweetAndSavory.Models;
using System.Threading.Tasks; //This will allow us to use asynchronous Tasks so we can use async and await to register new users.
using SweetAndSavory.ViewModels;

namespace SweetAndSavory.Controllers
{
    public class AccountController : Controller
    { //Dependency injection is the act of providing a helpful tool (known as a service) to part of an application that needs it before it actually needs it. This ensures that the application doesn't need to worry about locating, loading, finding, or creating that service on its own.  injecting the Identity's UserManager and SignInManager services into the AccountController constructor so that our controller will have access to these services as needed.
        private readonly SweetAndSavoryContext _db;
        private readonly UserManager<ApplicationUser> _userManager; //the UserManager service helps manage saving and updating user account information.
        private readonly SignInManager<ApplicationUser> _signInManager; //provides functionality for users to log into their accounts.

        public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, SweetAndSavoryContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register (RegisterViewModel model) //the built-in Task class represents asynchronous actions that haven't been completed yet.
        {
            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password); //CreateAsync() -- this method will create a user with the provided password. --The IdentityResult class simply represents the result of an Identity-driven action whether it's successful or not. --CreateAsync() takes two arguments: An ApplicationUser with user information; A password that will be encrypted when the user is added to the database.
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}