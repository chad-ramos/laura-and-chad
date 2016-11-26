using System.Threading.Tasks;
using System.Web.Mvc;
using LauraAndChad.Models;

namespace LauraAndChad.Controllers
{
    public class HomeController : Controller
    {
        private static string _anchor = "";

        public ActionResult Index(Rsvp model)
        {
            if (!string.IsNullOrEmpty(_anchor))
            {
                ViewBag.Anchor = _anchor;
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Rsvp(Rsvp model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Anchor = "#rsvp";
                return View("Index", model);
            }

            using (var ctx = new LauraAndChadContext())
            {
                ctx.Rsvps.Add(model);
                await ctx.SaveChangesAsync();
            }

            ViewBag.Anchor = "#rsvp";
            return View("Index", model);
        }
    }
}