using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserInterface.Models;

namespace KampaniaUI.Controllers
{
    public class KampaniaController : Controller
    {
        string api = "https://localhost:44345/kampania/";

        public async Task<IActionResult> GetKoszt()
        {
            string koszt = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(api+"koszt"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    koszt = JsonConvert.DeserializeObject<string>(apiResponse);
                }
            }
            return Content(koszt);
        }

        public async Task<IActionResult> Index()
        {
            List<Kampania> kampaniaList = new List<Kampania>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(api))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    kampaniaList = JsonConvert.DeserializeObject<List<Kampania>>(apiResponse);
                }
            }
            return View(kampaniaList);
        }
        public async Task<IActionResult> Details(int id)
        {
            Kampania kampania = new Kampania();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(api + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    kampania = JsonConvert.DeserializeObject<Kampania>(apiResponse);
                }
            }
            return View(kampania);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kampania kampania)
        {
            Kampania _kampania = new Kampania();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(kampania), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(api, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _kampania = JsonConvert.DeserializeObject<Kampania>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Kampania kampania = new Kampania();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(api + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    kampania = JsonConvert.DeserializeObject<Kampania>(apiResponse);
                }
            }
            return View(kampania);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Kampania kampania)
        {
            Kampania _kampania = new Kampania();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(kampania), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(api + kampania.Id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _kampania = JsonConvert.DeserializeObject<Kampania>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Kampania kampania = new Kampania();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(api + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    kampania = JsonConvert.DeserializeObject<Kampania>(apiResponse);
                }
            }
            return View(kampania);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(api + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
