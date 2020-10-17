using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;
using PortfolioProject.Models;
using System;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserRepositories(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void SendMail(string email, string name, string Id)
        {
            using (var message = new MailMessage("Ranya.Harahsheh@HTU.EDU.JO", email))
            {
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress("Ranya.Harahsheh@HTU.EDU.JO");
                message.Subject = "New E-Mail from Portfolio";
                message.Body = $"Dear,<br/><br/>" +
                $"Your portfoio is ready and this is the link" +
                $"https://portfolioproject.azurewebsites.net/AdminUsers/ViewPortfolio?UserId=" + Id;
                message.IsBodyHtml = true;
                using (var smtpClient = new SmtpClient("smtp.office365.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("Ranya.Harahsheh@HTU.EDU.JO", "9972038338@R");
                    smtpClient.Send(message);
                }
            }

        }
        public User getShowUser(string Id)
        {
            return applicationDbContext.Users.Where(x => x.Id == Id)
                .SingleOrDefault();
        }

        public  User getShowAdmin(string Id)
        {
            var user= applicationDbContext.Users.Include(x => x.userInterpersonalSkills)
                .ThenInclude(x => x.interpersonalSkill)
                .Include(x => x.userTechnicalSkills)
                .ThenInclude(x => x.technicalSkill)
                .Include(x => x.UserUniversitys)
                .ThenInclude(x => x.University)
                .Include(x => x.Projects).Where(x => x.Id == Id)
                .SingleOrDefault();
            return user;
        }
        public async Task<List<User>> GetAllUsers(UserDto userDto)
        {
            var user =  applicationDbContext.Users.Where(x => x.Id == userDto.UserId).SingleOrDefault();
            user.FirstName = userDto.FirstName;
            user.SecondName = userDto.SecondName;
            user.LastName = userDto.LastName;
            user.Address = userDto.Address;
            user.DateofBirth = userDto.DateofBirth;
            user.CV = userDto.PesronalCV;
            user.PortfolioEmail = userDto.PortfolioEmail;
            user.About = userDto.About;
            user.MobileNumber = userDto.MobileNumber;
            user.PersonalImage = userDto.PersonalImg;
            user.Vision = userDto.Vision;
            user.LinkedInURL = userDto.LinkedInURL;
            user.FacebookURL = userDto.FacebookURL;
            user.TwitterURL = userDto.TwitterURL;
            user.JobTitle = userDto.JobTitle;
            applicationDbContext.SaveChanges();

            foreach (var techSkill in userDto.TechnicalSkill)
            {
                UserTechnicalSkill userTechnicalSkills = new UserTechnicalSkill();
                userTechnicalSkills.UserId = user.Id;
                userTechnicalSkills.TechnicalSkillId = techSkill;
                applicationDbContext.UserTechnicalSkills.Add(userTechnicalSkills);
                applicationDbContext.SaveChanges();
            }
            foreach (var interSkill in userDto.InterpersonalSkill)
            {
                UserInterpersonalSkill userInterpersonalSkills = new UserInterpersonalSkill();
                userInterpersonalSkills.UserId = user.Id;
                userInterpersonalSkills.InterpersonalSkillId = interSkill;
                applicationDbContext.UserInterpersonalSkills.Add(userInterpersonalSkills);
                applicationDbContext.SaveChanges();
            }
            foreach (var u in userDto.UniversityDto)
            {
                UserUniversity userUniversity = new UserUniversity();
                userUniversity.UserId = user.Id;
                userUniversity.DegreeId = u.DegreeId;
                userUniversity.UniversityId = u.UniversityId;
                userUniversity.MajorName = u.MajorName;
                applicationDbContext.UserUniversities.Add(userUniversity);
                applicationDbContext.SaveChanges();
            }
            foreach (var u in userDto.ProjectDto)
            {
                Project project = new Project();
                project.UserId = user.Id;
                project.ProjectId = u.ProjectId;
                project.ProjectImage = u.ProjectImg;
                project.ProjectPDF = u.Projectpdf;
                project.ProjectDescription = u.ProjectDescription;
                project.ProjectName = u.ProjectName;
                applicationDbContext.Projects.Add(project);
                applicationDbContext.SaveChanges();
            }
            
            var userRet = applicationDbContext.Users.Where(x => x.Id == userDto.UserId).ToList();
            SendMail(user.Email, user.FirstName, user.Id);
            return userRet;
        }

        public async void UpdateUser(UserDto user )
        {
            
            var user1 = applicationDbContext.Users.Where(x => x.Id == user.UserId).SingleOrDefault();
            user1.FirstName = user.FirstName;
            user1.SecondName = user.SecondName;
            user1.LastName = user.LastName;
            user1.Address = user.Address;
            user1.DateofBirth = user.DateofBirth;
            user1.CV = user.PesronalCV;
            user1.PortfolioEmail = user.PortfolioEmail;
            user1.About = user.About;
            user1.MobileNumber = user.MobileNumber;
            user1.PersonalImage = user.PersonalImg;
            user1.Vision = user.Vision;
            user1.LinkedInURL = user.LinkedInURL;
            user1.FacebookURL = user.FacebookURL;
            user1.TwitterURL = user.TwitterURL;
            user1.JobTitle = user.JobTitle;


            var InterpersonalSkills = applicationDbContext.UserInterpersonalSkills.Where(x => x.UserId == user1.Id).ToList();
            foreach (var i in InterpersonalSkills)
            {
                applicationDbContext.Remove(i);
                applicationDbContext.SaveChanges();
            }
            var inter = new UserInterpersonalSkill();
            foreach (var i in user.InterpersonalSkill)
            {
                inter.UserId = user.UserId;
                inter.InterpersonalSkillId = i;
                applicationDbContext.UserInterpersonalSkills.Add(inter);
                applicationDbContext.SaveChanges();
            }
            var TechnicalSkills = applicationDbContext.UserTechnicalSkills.Where(x => x.UserId == user1.Id).ToList();
            foreach (var i in TechnicalSkills)
            {
                applicationDbContext.Remove(i);
                applicationDbContext.SaveChanges();
            }
            var tech = new UserTechnicalSkill();
            foreach (var i in user.TechnicalSkill)
            {
                tech.UserId = user.UserId;
                tech.TechnicalSkillId = i;
                applicationDbContext.UserTechnicalSkills.Add(tech);
                applicationDbContext.SaveChanges();
            }

            var uni = applicationDbContext.UserUniversities.Where(x => x.UserId == user.UserId).ToList();
            foreach(var unii in uni)
            {
                applicationDbContext.Remove(unii);
                applicationDbContext.SaveChanges();
            }
            foreach(var i in user.UniversityDto)
            {
                var unii = new UserUniversity();
                unii.UserId = user.UserId;
                unii.UniversityId = i.UniversityId;
                unii.DegreeId = i.DegreeId;
                unii.MajorName = i.MajorName;
                applicationDbContext.UserUniversities.Add(unii);
                applicationDbContext.SaveChanges();
            }

            var project = applicationDbContext.Projects.Where(x => x.UserId == user.UserId).ToList();
            foreach (var projects in project)
            {
                applicationDbContext.Remove(projects);
                applicationDbContext.SaveChanges();
            }
            foreach (var i in user.ProjectDto)
            {
                var pro = new Project();
                pro.UserId = user.UserId;
                pro.ProjectName = i.ProjectName;
                pro.ProjectPDF = i.Projectpdf;
                pro.ProjectImage = i.ProjectImg;
                pro.ProjectDescription = i.ProjectDescription;

                applicationDbContext.Projects.Add(pro);
                applicationDbContext.SaveChanges();
            }
            applicationDbContext.SaveChanges();
        }
       

        public UserDto EditUser(string Id)
        {
            var editUser =  applicationDbContext.Users.Include(x => x.userInterpersonalSkills)
                .ThenInclude(x => x.interpersonalSkill)
                .Include(x => x.userTechnicalSkills)
                .ThenInclude(x => x.technicalSkill)
                .Include(x => x.UserUniversitys)
                .ThenInclude(x => x.University)
                .Include(x => x.Projects).Where(x => x.Id == Id)
                .SingleOrDefault();
            List<int> interpersonalSkillIds = new List<int>();
            List<int> technicalSkillIds = new List<int>();
            UserDto userDto = new UserDto()
            {
                FirstName = editUser.FirstName,
                SecondName = editUser.SecondName,
                LastName = editUser.LastName,
                Address = editUser.Address,
                DateofBirth = editUser.DateofBirth,
                PesronalCV = editUser.CV,
                PortfolioEmail = editUser.PortfolioEmail,
                About = editUser.About,
                MobileNumber = (int)editUser.MobileNumber,
                PersonalImg = editUser.PersonalImage,
                Vision = editUser.Vision,
                LinkedInURL = editUser.LinkedInURL,
                FacebookURL = editUser.FacebookURL,
                TwitterURL = editUser.TwitterURL,
                JobTitle = editUser.JobTitle,
            };
            foreach (var x in editUser.userTechnicalSkills)
            {
                technicalSkillIds.Add(x.TechnicalSkillId);
            }
            userDto.TechnicalSkill = technicalSkillIds;
            var techskill = applicationDbContext.TechnicalSkills.ToList();


            foreach (var x in editUser.userInterpersonalSkills)
            {
               interpersonalSkillIds.Add(x.InterpersonalSkillId);
            }
            userDto.InterpersonalSkill=interpersonalSkillIds;
            var interskill = applicationDbContext.InterpersonalSkills.ToList();
            return  userDto;
        }
        public List<User> GetAllUser()
        {
            var user = applicationDbContext.Users.Include(x => x.userInterpersonalSkills)
                .ThenInclude(x => x.interpersonalSkill)
                .Include(x => x.userTechnicalSkills)
                .ThenInclude(x => x.technicalSkill)
                .Include(x => x.UserUniversitys)
                .ThenInclude(x => x.University)
                .Include(x => x.Projects)
                .ToList();
            return user;
        }

        public User ShowUser(string id)
        {
            var user = applicationDbContext.Users.Include(x => x.userInterpersonalSkills)
               .ThenInclude(x => x.interpersonalSkill)
               .Include(x => x.userTechnicalSkills)
               .ThenInclude(x => x.technicalSkill)
               .Include(x => x.UserUniversitys)
               .ThenInclude(x => x.University)
               .Include(x => x.Projects)
               .SingleOrDefault();
            return user;

        }
    }
}
