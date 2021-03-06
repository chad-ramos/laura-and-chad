﻿using System.Threading.Tasks;
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

            ViewBag.Success = "RSVP Sent!  See you soon.";

            ViewBag.Anchor = "#rsvp";
            return View("Index", model);
        }
    }
}