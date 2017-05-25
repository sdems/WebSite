using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class MariageController : Controller
    {
        // GET: Mariage
        [ActionName("Index")]
        public ActionResult Index(Guid guidId)
        {
            return View();
        }
    }
}