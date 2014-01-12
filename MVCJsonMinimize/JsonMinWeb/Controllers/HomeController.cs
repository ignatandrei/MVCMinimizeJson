using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JsonMinDatas;

namespace JsonMinWeb.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            

            return View();

        }

        public JsonResult RequestEmployees()
        {
            //usually this will be loading from database
            //but to compare same data when minimizing, 
            //I have to put somewhere            
            List<Department> d = this.HttpContext.Application["data"] as List<Department>;
            return Json(new { ok = true, departments = d });
        }

        public JsonResult RequestEmployeesMinimizing()
        {
            //usually this will be loading from database
            //but to compare same data when minimizing, 
            //I have to put somewhere                        
            List<Department> d = this.HttpContext.Application["data"] as List<Department>;
            var min = LoadData.Minimize(d);
            return Json(new { ok = true, departmentsMin = min, LoadData.dDep, LoadData.dEmp }); 

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