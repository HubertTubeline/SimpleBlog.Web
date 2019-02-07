using System.Web.Mvc;
using SimpleBlog.Web.Models.Account;

namespace SimpleBlog.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}