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
        // [HttpPost("/results")]
        // public ActionResult Results()
        // {
        //     Word newWord = new Word(Request.Form["word"], Request.Form["sentence"]);
        //     newWord.SetMatchCounter(newWord.RepeatCounter(newWord));
        //     return View(newWord);
        // }
    }
}
