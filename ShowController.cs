using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Data;
using PortfolioProject.Models;
using PortfolioProject.Repositories;

namespace PortfolioProject.Controllers
{
    public class ShowController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IUserRepositories userRepositories;
        private readonly IUserUniversityRepositories universityRepositories;
        private readonly IInterpersonalSkillRepositoroes interpersonalSkillRepositoroes;
        private readonly ITechnicalSkillRepositories technicalSkillRepositories;
        private readonly IDegreeRepositories degreeRepositories;
        private readonly IProjectRepositories projectRepositories;




        public ShowController(ApplicationDbContext applicationDbContext,IUserRepositories userRepositories, IInterpersonalSkillRepositoroes interpersonalSkillRepositoroes, IUserUniversityRepositories universityRepositories, ITechnicalSkillRepositories technicalSkillRepositories, IProjectRepositories projectRepositories, IDegreeRepositories degreeRepositories)
        {
            this.projectRepositories =projectRepositories;
            this.applicationDbContext = applicationDbContext;
            this.userRepositories = userRepositories;
            this.degreeRepositories = degreeRepositories;
            this.interpersonalSkillRepositoroes = interpersonalSkillRepositoroes;
            this.technicalSkillRepositories = technicalSkillRepositories;
            this.degreeRepositories = degreeRepositories;
            this.universityRepositories = universityRepositories;
        }
        [Authorize]
        public IActionResult ShowPortfolio()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var unii = applicationDbContext.Universities.ToList();
            ViewBag.unii = unii;
            var degree = applicationDbContext.Degrees.ToList();
            var uni = applicationDbContext.UserUniversities.Where(x => x.UserId == userId).ToList();
            ViewBag.uni = uni;
            ViewBag.UserId = userId;
            return View();
        }
        
        public async Task<ActionResult> EditPortfolio()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var InterpersonalSkills = await interpersonalSkillRepositoroes.GettAllInterpersonalSkill();
            ViewBag.interpersonalSkills = InterpersonalSkills;

            var TechnicalSkills = await technicalSkillRepositories.GetAllTechnicalSkill();
            ViewBag.TechnicalSkills = TechnicalSkills;

            var Universities = await universityRepositories.GettAllUniversities();
            ViewBag.Universities = Universities;

            var Degree = await degreeRepositories.getAllDegree();
            ViewBag.Degree = Degree;

            //var project = await projectRepositories.GetAllProject();
            //ViewBag.project = project;
            
            var editUser = userRepositories.EditUser(userId);
          
            
            return View(editUser);
        }
    }
}
