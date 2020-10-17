using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Models
{
    public class UserDto
    {
        public string UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name = "Birthday")]
        public DateTime DateofBirth { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        public int MobileNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Email ")]
        public string PortfolioEmail { get; set; }
        
        public byte[] PersonalImg { get; set; }
        [Required]
        [Display(Name = "Image")]
        public IFormFile PersonalImage { get; set; }
        [Required]
        public string Vision { get; set; }
        [Required]
        public string About { get; set; }
        public byte[] PesronalCV { get; set; }
        [Required]
        public IFormFile CV { get; set; }
        
        public List<UniversityDto> UniversityDto { get; set; }
        [Required]
        public List<int> InterpersonalSkill { get; set; }
        [Required]
        public List<int> TechnicalSkill { get; set; }
       
        public List<ProjectDto> ProjectDto { get; set; }
        [Required]
        [Display(Name = "Facebook URL")]
        public string FacebookURL { get; set; }
        [Required]
        [Display(Name = "Twitter URL")]
        public string TwitterURL { get; set; }
        [Required]
        [Display(Name = "LinkedIn URL")]
        public string LinkedInURL { get; set; }
        

    }

}
