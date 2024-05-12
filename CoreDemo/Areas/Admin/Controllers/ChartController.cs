using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname = "Texnologiya",
                categorycount = 10
            });
            list.Add(new CategoryClass
            {
                categoryname = "Proqramlaşdırma",
                categorycount = 14
            }); 
            list.Add(new CategoryClass
            {
                categoryname = "İdman",
                categorycount = 5
            });

            list.Add(new CategoryClass
            {
                categoryname = "Film və serial",
                categorycount = 8
            });

            return Json(new { jsonlist = list });
        }
    }
}
