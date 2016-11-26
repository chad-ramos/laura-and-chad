using System.Threading.Tasks;
using System.Web.Mvc;
using LauraAndChad.Models;

namespace LauraAndChad.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(Rsvp model)
        {
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
                return View("Index");
            }

            using (var ctx = new LauraAndChadContext())
            {
                ctx.Rsvps.Add(model);
                await ctx.SaveChangesAsync();
            }

            ViewBag.Anchor = "#rsvp";
            return View("Index");
        }
    }
}