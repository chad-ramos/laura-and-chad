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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Rsvp(Rsvp model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            using (var ctx = new LauraAndChadContext())
            {
                ctx.Rsvps.Add(model);
                await ctx.SaveChangesAsync();
            }

            ViewBag.RsvpMessage = "RSVP sent!";
            return Redirect("#rsvp");
        }
    }
}