using FT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index ()
        {
            if (bool.Parse(Request.Browser["IsMobile"]))
            {
                return View("Index_m");
            }

            return View();
        }
    }
}