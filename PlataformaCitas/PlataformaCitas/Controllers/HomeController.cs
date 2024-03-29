﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using PlataformaCitas.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaCitas.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*[AllowAnonymous]*/
        public IActionResult Index()
        {
            lDoctores Doctores = new lDoctores();
            var repo = new APIRequest();
            Doctores = repo.GetDoctores();
            return View(Doctores);
        }

        public IActionResult Citas(int Id = 0)
        {
            return View();
        }

        public IActionResult TestApi()
        {
            APIRequest request = new APIRequest();
            request.TestRequest();
            return View("Privacy");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
