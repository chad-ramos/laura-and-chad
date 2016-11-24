using System.Threading.Tasks;
using System.Web.Mvc;
using LauraAndChad.Models;

namespace LauraAndChad.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Rsvp(Rsvp model, string returnUrl)
        {
            return View("Index");
        }
    }
}