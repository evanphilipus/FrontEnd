using MicroservicesConcept.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroservicesConcept.Controllers
{
    public class InputController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7186/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var task = Task.Run(async () =>
            {
                return await client.GetAsync("api/Input");
            });

            var result = task.Result.Content.ReadAsStringAsync().Result;

            MainModel mainModel = new MainModel();
            mainModel.ms_storage_location = JsonConvert.DeserializeObject<List<ms_storage_location>>(result);

            return View(mainModel);
        }

        ////POST
        //[HttpPost]
        //public IActionResult Create (tr_bpkb)
    }
}
