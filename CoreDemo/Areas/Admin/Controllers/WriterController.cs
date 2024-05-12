using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterById(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            
            return Json(jsonWriters);

        }
        #region Writers
        public static List<WriterModel> writers = new List<WriterModel>
        {
            new WriterModel
            {
                Id=1,
                Name="Sürəyya",
            },
            new WriterModel{
                Id=2,
                Name="Gülşən",
            },
            new WriterModel{
                Id=3,
                Name="Leyla",
            },
            new WriterModel{
                Id=4,
                Name="Fəridə",
            }
        };
        #endregion

        [HttpPost]
        public IActionResult AddWriter(WriterModel writer)
        {
            writers.Add(writer);
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }


        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);

            return Json(writer);
        }

        public IActionResult UpdateWriter(WriterModel parameter)
        {
            var writer=writers.FirstOrDefault(x=>x.Id==parameter.Id);
            writer.Name = parameter.Name;
            var jsonWriter = JsonConvert.SerializeObject(parameter);

            return Json(jsonWriter);
        }
    }
}
