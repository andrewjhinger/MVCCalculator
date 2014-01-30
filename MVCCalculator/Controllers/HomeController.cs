using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCalculator.Models;
using MVCCalculator.FormModels;

namespace MVCCalculator.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View("Index", new Calculator());
        }

        [HttpPost]
        public ActionResult Index(Calculator calculator, CalculatorForm calculatorForm)
        {
            calculator.Process(calculatorForm.key);
            ModelState.Clear();
            return View(calculator);
        }
    }
}