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
    public class UniversityController : Controller
    {
        private readonly IUserUniversityRepositories userUniversityRepositories;
        public UniversityController(IUserUniversityRepositories userUniversityRepositories)
        {
            this.userUniversityRepositories = userUniversityRepositories;
        }
        [Authorize]
        public IActionResult Universities()
        {
            var universities = userUniversityRepositories.getAllUniversitiesEdit();
            ViewBag.Universities = universities;
            return View();
        }
        [Authorize]
        public IActionResult UniversityCreate()
        {
            return View();
        }
        [Authorize]
        public IActionResult CreateUniversity(University university)
        {
            userUniversityRepositories.add(university);
            return RedirectToAction("Universities", "University");
        }
        [Authorize]
        public IActionResult RemoveUniversity(int Id)
        {
            userUniversityRepositories.remove(Id);
            return RedirectToAction("Universities", "University");
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditUniversities(int UniversityId)
        {

            University University = userUniversityRepositories.UpdateUniversity(UniversityId);
            return View(University);
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditUniversities(University University)
        {
            userUniversityRepositories.showupdate(University);
            return RedirectToAction("Universities", "University");
        }
        
    }
}
