using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Data;
using PortfolioProject.Repositories;

namespace PortfolioProject.Controllers
{
    public class DegreeController : Controller
    {
        private readonly IDegreeRepositories degreeRepositories ;
        public DegreeController(IDegreeRepositories degreeRepositories)
        {
            this.degreeRepositories = degreeRepositories;
        }
        [Authorize]
        public IActionResult Degrees()
        {
            var degrees = degreeRepositories.getAllDegrees();
            ViewBag.Degrees = degrees;
            return View();
        }
        [Authorize]
        public IActionResult DegreeCreate()
        {
            return View();
        }
        [Authorize]
        public IActionResult CreateDegree(Degree degree)
        {
            degreeRepositories.add(degree);
            return RedirectToAction("Degrees", "Degree");
        }
        [Authorize]
        public IActionResult RemoveDegree(int Id)
        {
            degreeRepositories.remove(Id);
            return RedirectToAction("Degrees", "Degree");
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditDegree(int DegreeId)
        {

            Degree degree = degreeRepositories.UpdateDegree(DegreeId);
            return View(degree);
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditDegree(Degree Degree)
        {
            degreeRepositories.showupdate(Degree);
            return RedirectToAction("Degrees", "Degree");
        }
    }
}

