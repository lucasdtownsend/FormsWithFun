using FunWithForms.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithForms.Controllers
{
    public class CarsController : Controller
    {
        private ICarRepository carsRepo;

        public CarsController(ICarRepository carsRepo)
        {
            this.carsRepo = carsRepo;
        }

        public IActionResult Index()
        {
            var cars = carsRepo.GetAll();
            return View(cars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            carsRepo.Create(car);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var car = carsRepo.GetById(id);
            return View(car);
        }

        public IActionResult Delete(int id)
        {
            var car = carsRepo.GetById(id);
            return View(car);
        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            carsRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
