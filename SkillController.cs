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
    public class SkillController : Controller
    {
        private readonly IInterpersonalSkillRepositoroes interpersonalSkillRepositoroes ;
        private readonly ITechnicalSkillRepositories technicalSkillRepositories;
        private readonly ApplicationDbContext applicationDbContext;
        public SkillController(ITechnicalSkillRepositories technicalSkillRepositories, ApplicationDbContext applicationDbContext , IInterpersonalSkillRepositoroes interpersonalSkillRepositoroe)
        {
            this.technicalSkillRepositories = technicalSkillRepositories;
            interpersonalSkillRepositoroes = interpersonalSkillRepositoroe;
            this.applicationDbContext = applicationDbContext;
        }
        [Authorize]
        public IActionResult InterpersonalSkills()
        {
            var interpersonalSkills = interpersonalSkillRepositoroes.getAllInterpersonalSkillsShow();
            ViewBag.InterpersonalSkills = interpersonalSkills;
            return View();
        }
        [Authorize]
        public IActionResult InterpersonalSkillCreate()
        {
            return View();
        }
        [Authorize]
        public IActionResult CreateInterpersonalSkill(InterpersonalSkill interpersonalSkills)
        {

            interpersonalSkillRepositoroes.addInterpersonalSkill(interpersonalSkills);
            return RedirectToAction("InterpersonalSkills", "Skill");
        }
        [Authorize]
        public IActionResult RemoveInterpersonalSkill(int Id)
        {
            interpersonalSkillRepositoroes.RemoveInterpersonalSkill(Id);
            return RedirectToAction("InterpersonalSkills", "Skill");
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditInterpersonalSkill(int interpersonalSkillId)
        {

            InterpersonalSkill InterpersonalSkill = interpersonalSkillRepositoroes.UpdateInterpersonalSkill(interpersonalSkillId);
            return View(InterpersonalSkill);
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditInterpersonalSkill(InterpersonalSkill interpersonalSkill)
        {
            interpersonalSkillRepositoroes.showupdate(interpersonalSkill);
            return RedirectToAction("InterpersonalSkills", "Skill");
        }
        [Authorize]
        public IActionResult TechnicalSkills()
        {
            var technicalSkills = technicalSkillRepositories.getAllTechnicalSkillsShow();
            ViewBag.TechnicalSkills = technicalSkills;
            return View();
        }
        [Authorize]
        public IActionResult TechnicalSkillCreate()
        {
            return View();
        }
        [Authorize]
        public IActionResult CreateTechnicalSkill(TechnicalSkill technicalSkills)
        {

            technicalSkillRepositories.addTechnicalSkill(technicalSkills);
            return RedirectToAction("TechnicalSkills", "Skill");
        }
        [Authorize]
        public IActionResult RemoveTechnicalSkill(int Id)
        {
            technicalSkillRepositories.RemoveTechnicalSkill(Id);
            return RedirectToAction("TechnicalSkills", "Skill");
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditTechnicalSkill(int TechnicalSkillId)
        {

            TechnicalSkill TechnicalSkill = technicalSkillRepositories.UpdateTechnicalSkill(TechnicalSkillId);
            return View(TechnicalSkill);
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditTechnicalSkill(TechnicalSkill TechnicalSkill)
        {
            technicalSkillRepositories.showupdate(TechnicalSkill);
            return RedirectToAction("TechnicalSkills", "Skill");
        }
    }
}