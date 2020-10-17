using PortfolioProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
    public class ProjectRepositories : IProjectRepositories
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ProjectRepositories(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<List<Project>> GetAllProject()
        {
           var project= applicationDbContext.Projects.ToList();
            return project; 
        }

        public async Task<List<Project>> getAllProjectById(string Id)
        {
            return applicationDbContext.Projects
               .Where(x => x.UserId == Id).ToList();
        }

        public Project getProjectById(int Id)
        {
            return applicationDbContext.Projects.Where(x => x.ProjectId == Id).FirstOrDefault();
        }
    }
}
