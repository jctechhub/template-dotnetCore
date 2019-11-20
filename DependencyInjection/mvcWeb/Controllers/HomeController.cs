using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcWeb.Models;

namespace mvcWeb.Controllers
{
    public class HomeController : Controller
    {
        private IHttpClientFactory _httFactory;
        private readonly ILogger<HomeController> _logger;
        private IBookRepo _bookRepo;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpfactory, IBookRepo bookRepo)
        {
            _logger = logger;
            _bookRepo = bookRepo;
            _httFactory = httpfactory;
        }

        public async Task<IActionResult> Index()
        {
            var numBook = _bookRepo.GetBookNumber();

            //using (var client = new HttpClient()) //don't do this. can cause http socket http socket exhaustion
            using (var client = _httFactory.CreateClient())
            {
                var output = await client.GetStringAsync("http://regres.in/api/users?page=2");
                ViewBag.Output = output;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
