using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ServisController : Controller
    {
        // GET: Servis
        public async Task<ActionResult> Index(string request)
        {
            switch (request)
            {
                case "xsd":
                    ViewBag.Result = await RequestXSD();
                    break;
                case "relax":
                    ViewBag.Result = await RequestRelax();
                    break;
                case "soap":
                    ViewBag.Soap = 2;
                    break;
                default:
                    break;
            }
            return View();
        }
        public async Task<string> RequestXSD()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiEndpoint = "http://localhost:5148/api/xml/xsd";
                HttpResponseMessage response = await httpClient.GetAsync(apiEndpoint);
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
        }
        public async Task<string> RequestRelax()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiEndpoint = "http://localhost:5148/api/xml/relax";
                HttpResponseMessage response = await httpClient.GetAsync(apiEndpoint);
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
        }



        public async Task<ActionResult> RequestSoap(string title)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiEndpoint = $"http://localhost:53414/api/xml/soap?title={title}";
                HttpResponseMessage response = await httpClient.GetAsync(apiEndpoint);
                string responseContent = await response.Content.ReadAsStringAsync();
                ViewBag.Result = responseContent;
            }
            return View("Index");
        }



    }
}