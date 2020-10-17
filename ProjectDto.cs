using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Models
{
    public class ProjectDto
    {

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public IFormFile ProjectImage { get; set; }
        public byte[] ProjectImg { get; set; }
        public IFormFile ProjectPDF { get; set; }
        public byte[] Projectpdf { get; set; }
    }
}
