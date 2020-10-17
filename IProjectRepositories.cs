using PortfolioProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
   public interface IProjectRepositories
    {
        Task<List<Project>> GetAllProject();
        public Task<List<Project>> getAllProjectById(string Id);
        public Project getProjectById(int Id);

    }
}
