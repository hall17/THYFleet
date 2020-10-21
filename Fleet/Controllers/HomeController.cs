using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fleet.Models;
using AircraftData;
using Fleet.Models.Home;

namespace Fleet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAircraftRepository _ACRepository;
        //private readonly AppDbContext _context;


        public HomeController(IAircraftRepository ACRepository)
        {
            _ACRepository = ACRepository;
        }

        public IActionResult Index()
        {
            // No abstraction is needed for the ACModel for now.
            var ACModel = _ACRepository.GetAllAircrafts();
            return View(ACModel);
        }
        public IActionResult InsertSqlData()
        {
            SQLInserter sql = new SQLInserter();
            _ACRepository.GetAllAircrafts().ToList().ForEach(ac =>
            _ACRepository.DeleteAC(ac));
            foreach (var ac in sql._ACList)
            {
                _ACRepository.AddAC(ac);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {   
            //var ACModel = _ACRepository.GetAircraftbyRegistration(reg);
            var ACModel = _ACRepository.GetAircraftbyID(Id);

            var model = new HomeACModel()
            {
                aircraft = ACModel
            };
            return View(model);
        }
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Create(HomeACModel model)
        {
            _ACRepository.AddAC(model.aircraft);
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var ACModel = _ACRepository.GetAircraftbyID(Id);

            var model = new HomeACModel()
            {
                aircraft = ACModel
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(HomeACModel model)
        {
            if (ModelState.IsValid)
            {
                _ACRepository.UpdateAC(model.aircraft);
            }
            return View(model);
        }
        public IActionResult Delete(int Id)
        {
            Aircraft ac = _ACRepository.GetAircraftbyID(Id);
            _ACRepository.DeleteAC(ac);
            return RedirectToAction(nameof(Index));
        }

    }
}
