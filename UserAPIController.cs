using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Data;
using PortfolioProject.Models;
using PortfolioProject.Repositories;

namespace PortfolioProject.Controllers
{
    [ApiController]
    [Route("API/[Controller]/[Action]")]
    public class UserAPIController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IUserRepositories userRepositories;
        private readonly IUserUniversityRepositories universityRepositories;
        private readonly IInterpersonalSkillRepositoroes interpersonalSkillRepositoroes;
        private readonly ITechnicalSkillRepositories technicalSkillRepositories;
        private readonly IDegreeRepositories degreeRepositories;
        private readonly IProjectRepositories projectRepositories;



        public UserAPIController(ApplicationDbContext applicationDbContext,IUserRepositories userRepositories, IInterpersonalSkillRepositoroes interpersonalSkillRepositoroes, IUserUniversityRepositories universityRepositories, ITechnicalSkillRepositories technicalSkillRepositories, IProjectRepositories projectRepositories, IDegreeRepositories degreeRepositories , IProjectRepositories projectRepositories1)
        {
            this.applicationDbContext = applicationDbContext;
            this.userRepositories = userRepositories;
            this.degreeRepositories = degreeRepositories;
            this.interpersonalSkillRepositoroes = interpersonalSkillRepositoroes;
            this.technicalSkillRepositories = technicalSkillRepositories;
            this.degreeRepositories = degreeRepositories;
            this.universityRepositories = universityRepositories;
            this.projectRepositories = projectRepositories;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ICollection<User>>> CreatePortfolio()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
  
           var InterpersonalSkills =  await interpersonalSkillRepositoroes.GettAllInterpersonalSkill();
            ViewBag.interpersonalSkills = InterpersonalSkills;

            var TechnicalSkills = await technicalSkillRepositories.GetAllTechnicalSkill();
            ViewBag.TechnicalSkills = TechnicalSkills;

            var Universities =await universityRepositories.GettAllUniversities();
            ViewBag.Universities = Universities;

            var Degree = await degreeRepositories.getAllDegree();
            ViewBag.Degree = Degree;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ICollection<User>>> CreatePortfolio([FromForm] UserDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dto.UserId = userId;
            userId = dto.UserId;
            if (dto.CV.Length > 0)
            {
                Stream st = dto.CV.OpenReadStream();

                using (BinaryReader br = new BinaryReader(st))
                {
                    dto.PesronalCV = br.ReadBytes((int)dto.CV.Length);
                }
            }

            if (dto.PersonalImage.Length > 0)
            {
                Stream st = dto.PersonalImage.OpenReadStream();

                using (BinaryReader br = new BinaryReader(st))
                {
                    dto.PersonalImg = br.ReadBytes((int)dto.PersonalImage.Length);
                }
            }

           if (dto.ProjectDto[0].ProjectImage.Length > 0)
            {
                Stream st = dto.ProjectDto[0].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    dto.ProjectDto[0].ProjectImg = br.ReadBytes((int)dto.ProjectDto[0].ProjectImage.Length);
                }
            }

            if (dto.ProjectDto[1].ProjectImage.Length > 0)
            {
                Stream st = dto.ProjectDto[1].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    dto.ProjectDto[1].ProjectImg = br.ReadBytes((int)dto.ProjectDto[1].ProjectImage.Length);
                }
            }
            if (dto.ProjectDto[2].ProjectImage.Length > 0)
            {
                Stream st = dto.ProjectDto[2].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    dto.ProjectDto[2].ProjectImg = br.ReadBytes((int)dto.ProjectDto[2].ProjectImage.Length);
                }
            }

            if (dto.ProjectDto[0].ProjectPDF.Length > 0)
            {
                Stream st = dto.ProjectDto[0].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    dto.ProjectDto[0].Projectpdf = br.ReadBytes((int)dto.ProjectDto[0].ProjectPDF.Length);
                }
            }
            if (dto.ProjectDto[1].ProjectPDF.Length > 0)
            {
                Stream st = dto.ProjectDto[1].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    dto.ProjectDto[1].Projectpdf = br.ReadBytes((int)dto.ProjectDto[1].ProjectPDF.Length);
                }
            }
            if (dto.ProjectDto[2].ProjectPDF.Length > 0)
            {
                Stream st = dto.ProjectDto[2].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    dto.ProjectDto[2].Projectpdf = br.ReadBytes((int)dto.ProjectDto[2].ProjectPDF.Length);
                }
            }
            await userRepositories.GetAllUsers(dto);

            return RedirectToAction("ShowPortfolio", "Show");
        }

       
       
        [HttpPost]
        public async Task<ActionResult> EditPortfolio([FromForm] UserDto user)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user.UserId = userId;
            if (user.CV.Length > 0)
            {
                Stream st = user.CV.OpenReadStream();

                using (BinaryReader br = new BinaryReader(st))
                {
                    user.PesronalCV = br.ReadBytes((int)user.CV.Length);
                }
            }

            if (user.PersonalImage.Length > 0)
            {
                Stream st = user.PersonalImage.OpenReadStream();

                using (BinaryReader br = new BinaryReader(st))
                {
                    user.PersonalImg = br.ReadBytes((int)user.PersonalImage.Length);
                }
            }

            if (user.ProjectDto[0].ProjectImage.Length > 0)
            {
                Stream st = user.ProjectDto[0].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDto[0].ProjectImg = br.ReadBytes((int)user.ProjectDto[0].ProjectImage.Length);
                }
            }

            if (user.ProjectDto[1].ProjectImage.Length > 0)
            {
                Stream st = user.ProjectDto[1].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDto[1].ProjectImg = br.ReadBytes((int)user.ProjectDto[1].ProjectImage.Length);
                }
            }
            if (user.ProjectDto[2].ProjectImage.Length > 0)
            {
                Stream st = user.ProjectDto[2].ProjectImage.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDto[2].ProjectImg = br.ReadBytes((int)user.ProjectDto[2].ProjectImage.Length);
                }
            }

            if (user.ProjectDto[0].ProjectPDF.Length > 0)
            {
                Stream st = user.ProjectDto[0].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDto[0].Projectpdf = br.ReadBytes((int)user.ProjectDto[0].ProjectPDF.Length);
                }
            }
            if (user.ProjectDto[1].ProjectPDF.Length > 0)
            {
                Stream st = user.ProjectDto[1].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDto[1].Projectpdf = br.ReadBytes((int)user.ProjectDto[1].ProjectPDF.Length);
                }
            }
            if (user.ProjectDto[2].ProjectPDF.Length > 0)
            {
                Stream st = user.ProjectDto[2].ProjectPDF.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    user.ProjectDto[2].Projectpdf = br.ReadBytes((int)user.ProjectDto[2].ProjectPDF.Length);
                }
            }
            userRepositories.UpdateUser(user);
            return RedirectToAction("ShowPortfolio", "Show");
        }
        
        public FileStreamResult GetCV(string Id)
        {
         
            var user = userRepositories.getShowUser(Id);
            var file = user.CV;
            Stream stream = new MemoryStream(file);
            return new FileStreamResult(stream, "application/pdf");
        }

        public FileStreamResult GetProjectFile(int Id)
        {
            var project = projectRepositories.getProjectById(Id);
            var file = project.ProjectPDF;
            Stream stream = new MemoryStream(file);
            return new FileStreamResult(stream, "application/pdf");
        }
        [HttpGet]
        public async Task<JsonResult> ShowPortfolio()
        {

           
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user =  userRepositories.getShowUser(userId);
            var universitiesList = universityRepositories.getAllUniversityById(userId).Result;
            var interPersonalSkills = interpersonalSkillRepositoroes.getAllInterPersonalSkillsById(userId).Result;
            var technicalSkills = technicalSkillRepositories.getAllTechnicalSkillById(userId).Result;
            var projects = projectRepositories.getAllProjectById(userId).Result;
            
            var user1 = new
            {
                firstName = user.FirstName,
                secondName = user.SecondName,
                lastName=user.LastName,
                DateOfBirth = user.DateofBirth,
                address =user.Address,
                about = user.About,
                vision = user.Vision,
                linkedInURL = user.LinkedInURL,
                facebookURL = user.FacebookURL,
                twitterURL = user.TwitterURL,
                portfolioEmail = user.PortfolioEmail,
                jobTitle = user.JobTitle,
                universityList = universitiesList,
                interpersonalSkill = interPersonalSkills,
                technicalSkill = technicalSkills,
                project = projects,
                personalImage = user.PersonalImage,
                cv=user.CV,
                mobileNumber=user.MobileNumber,
            };
            return Json(user1);
        }

        [HttpGet]
        public async Task<JsonResult> ShowPortfolioForAdmin(string userId)
        {
           
            User user =  userRepositories.getShowUser(userId);
            var universitiesList = universityRepositories.getAllUniversityById(userId).Result;
            var interPersonalSkills = interpersonalSkillRepositoroes.getAllInterPersonalSkillsById(userId).Result;
            var technicalSkills = technicalSkillRepositories.getAllTechnicalSkillById(userId).Result;
            var projects = projectRepositories.getAllProjectById(userId).Result;
            var user1 = new
            {
                firstName = user.FirstName,
                secondName = user.SecondName,
                lastName = user.LastName,
                DateOfBirth = user.DateofBirth,
                address = user.Address,
                about = user.About,
                vision = user.Vision,
                linkedInURL = user.LinkedInURL,
                facebookURL = user.FacebookURL,
                twitterURL = user.TwitterURL,
                portfolioEmail = user.PortfolioEmail,
                jobTitle = user.JobTitle,
                universityList = universitiesList,
                interpersonalSkill = interPersonalSkills,
                technicalSkill = technicalSkills,
                project = projects,
                personalImage = user.PersonalImage,
                cv = user.CV,
                mobileNumber = user.MobileNumber,
            };
           
            return Json(user1);
        }
    }
}
