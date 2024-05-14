using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44390/api/Default");

            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Test>>(jsonString);

            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Test test)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(test);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            
            var responseMessage = await httpClient.PostAsync("https://localhost:44390/api/Default",content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(test);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44390/api/Default/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Test>(jsonEmployee);
                return View(values);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Test parameters)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(parameters);

            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44390/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(parameters);

        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44390/api/Default/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
