using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Address { get; set; }
        public string PortfolioEmail { get; set; }
        public byte[] PersonalImage { get; set; }
        public string Vision { get; set; }
        public string About { get; set; }
        public byte[] CV { get; set; }
        public int MobileNumber { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string LinkedInURL { get; set; }
        public ICollection<UserUniversity> UserUniversitys { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<UserTechnicalSkill> userTechnicalSkills { get; set; }
        public ICollection<UserInterpersonalSkill> userInterpersonalSkills { get; set; }

        
    }
}
