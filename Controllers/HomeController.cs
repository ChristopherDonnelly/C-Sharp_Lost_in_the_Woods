using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lost_in_the_Woods.Models;
using Lost_in_the_Woods.Factory;

namespace Lost_in_the_Woods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController()
        {
            trailFactory = new TrailFactory();
        }

        [HttpGet]
        [Route("")]
        [Route("Index")]
        [Route("Home")]
        public IActionResult Index()
        {
            IEnumerable<TrailInfo> trailInfo = trailFactory.FindAll();

            return View(trailInfo);
        }

        [HttpGet]
        [Route("Trails/{id}")]
        public IActionResult Trails(int id)
        {
            
            TrailInfo trailInfo = trailFactory.FindByID(id);

            return View(trailInfo);
        }

        [HttpGet]
        [Route("NewTrail")]
        public IActionResult NewTrail()
        {

            return View();
        }

        [HttpPost]
        [Route("CreateTrail")]
        public IActionResult CreateTrail(TrailInfo trailInfo)
        {

            if(ModelState.IsValid)
            {
                trailFactory.Add(trailInfo);

                return RedirectToAction("Index");
            }else{
                return View("NewTrail");
            }
        }

    }
}
