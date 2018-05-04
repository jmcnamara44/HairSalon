using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet("/add-client")]
        public ActionResult AddClient()
        {
            List<Stylist> allStylists = Stylist.GetAllStylists();
            return View(allStylists);
        }
        [HttpPost("/create-client")]
        public ActionResult CreateClient()
        {
            Client newClient = new Client(Request.Form["client-name"], Request.Form["phone-number"], Request.Form["stylist-name"]);
            newClient.Save();
            List<Stylist> allStylists = Stylist.GetAllStylists();
            return View("AllStylists", allStylists);
        }
    }
}
