using PortfolioProject.Data;
using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
   public interface IDegreeRepositories
    {
        public Task<List<Degree>> getAllDegree();
        public void remove(int Id);
        public void add(Degree degree);
        public List<Degree> getAllDegrees();

        public Degree UpdateDegree(int DegreeId);
        void showupdate(Degree Degree);
    }
}
