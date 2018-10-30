using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitConverterPlus.Models;

namespace UnitConverterPlus.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConvertNumbers(string text, string action)
        {
            var converter = new UnitConverter();

            if (action == "Yards to meters")
            {       
                return Content(converter.Converter(text, "yards").ToString());
            }

            else if (action == "Meters to yards")
            {
                return Content(converter.Converter(text, "meters").ToString());
            }

            else if (action == "Centimeters to inches")
            {
                return Content(converter.Converter(text, "centimeters").ToString());
            }

            else if (action == "Miles to kilometers")
            {
                return Content(converter.Converter(text, "miles").ToString());
            }

            else if (action == "Kilometers to miles")
            {
                return Content(converter.Converter(text, "kilometers").ToString());
            }

            else
            {
                return Content(converter.Converter(text, "inches").ToString());
            }

        }
        
    }
}
