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
        [HttpGet("/onboard-stylist")]
        public ActionResult AddStylist()
        {
            return View();
        }
        [HttpGet("/all-stylists")]
        public ActionResult AllStylists()
        {
            List<Stylist> allStylists = Stylist.GetAllStylists();
            return View(allStylists);
        }
        [HttpGet("/remove-all-clients")]
        public ActionResult RemoveAllClients()
        {
            return View();
        }
        [HttpGet("/fire-all-stylists")]
        public ActionResult FireAllStylists()
        {
            return View();
        }
        [HttpGet("/confirm-remove-clients")]
        public ActionResult ConfirmedRemoveAllClients()
        {
            Client.DeleteAll();
            return View("Index");
        }
        [HttpGet("/confirm-fire-stylists")]
        public ActionResult ConfirmedFireAllStylists()
        {
            Stylist.DeleteAll();
            return View("Index");
        }
        [HttpGet("/client-list/{id}")]
        public ActionResult ClientList(int id)
        {
            List<Client> allClients = Client.GetClientList(id);
            return View(allClients);
        }
        [HttpPost("/create-client")]
        public ActionResult CreateClient()
        {
            Client newClient = new Client(Request.Form["client-name"], Request.Form["phone-number"], Int32.Parse(Request.Form["stylist-name"]));
            newClient.Save();
            List<Stylist> allStylists = Stylist.GetAllStylists();
            return View("AllStylists", allStylists);
        }
        [HttpPost("/create-stylist")]
        public ActionResult CreateStylist()
        {
            Stylist newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["days-available"], Int32.Parse(Request.Form["years-active"]), Request.Form["phone-number"]);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAllStylists();
            return View("AllStylists", allStylists);
        }
    }
}
