using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SimpleBlog.Web.Models.Account;
using SimpleBlog.Web.Services;

namespace SimpleBlog.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private AccountService _service;

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public AccountController()
        {
            _service = new AccountService();
        }

        public ActionResult Index()
        {
            var user = _service.GetUser(User);
            return View(user);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            ClaimsIdentity claim = await _service.Login(model);
            if (claim == null)
            {
                return View();
            }
            else
            {
                AuthenticationManager.SignOut();
                AuthenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true
                }, claim);
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Register(model);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Account");
                foreach (var error in result.Errors) ModelState.AddModelError("", error);
            }

            return View(model);
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

    }
}