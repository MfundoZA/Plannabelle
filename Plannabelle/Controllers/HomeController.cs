﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plannabelle.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Plannabelle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;

            byte[]? output;

            if (httpContextAccessor.HttpContext?.Session.TryGetValue("studentId", out output) == false)
            {
                httpContextAccessor.HttpContext?.Session.SetInt32("studentId", 0);
                httpContextAccessor.HttpContext?.Session.SetString("email", "");
            }
            
        }

        public IActionResult Index()
        {
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