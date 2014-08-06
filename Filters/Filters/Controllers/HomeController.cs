using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ames.Infrastructue;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        [CustAuth(true)]
        public string Index()
        {
            return "This is the index action method calling from Home Controller";
        }

        //Remark below will call generic CustomErrors set at web.config, system.web.
        //[HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View="RangeError")]
        public string RangeTest(int id) {
            if (id > 100)
                return String.Format("The id value is: {0}", id);
            else
                throw new ArgumentOutOfRangeException("id", id, "This is the customised error message");
        }

        [ProfileAction]
        public string FilterTest() {
            return "This is ActionFilterTest action";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}