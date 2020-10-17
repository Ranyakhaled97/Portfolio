using PortfolioProject.Data;
using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
    public class DegreeRepositories : IDegreeRepositories
    {
        private readonly ApplicationDbContext applicationDbContext;
        public DegreeRepositories(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public List<Degree> getAllDegrees()
        {
            return applicationDbContext.Degrees.ToList();
        }

        public void add(Degree degree)
        {
            Degree degree1 = new Degree()
            {
                DegreeName = degree.DegreeName,
            };
            applicationDbContext.Degrees.Add(degree1);
            applicationDbContext.SaveChanges();
        }

        public void remove(int Id)
        {
            var degree = applicationDbContext.Degrees.Where(x => x.DegreeId == Id).SingleOrDefault();
            applicationDbContext.Degrees.Remove(degree);
            applicationDbContext.SaveChanges();
        }
        public async Task<List<Degree>> getAllDegree()
        {
            return applicationDbContext.Degrees.ToList();

        }
        public Degree UpdateDegree(int DegreeId)
        {
            var degree= applicationDbContext.Degrees.Where(x => x.DegreeId == DegreeId).SingleOrDefault();
            Degree degree1 = new Degree() 
            { 
                DegreeId=degree.DegreeId,
                DegreeName=degree.DegreeName
            };
            return degree1;
        }
        public void showupdate(Degree Degree)
        {
            var degree1 = applicationDbContext.Degrees.Where(x => x.DegreeId == Degree.DegreeId).SingleOrDefault();
            degree1.DegreeId = Degree.DegreeId;
            degree1.DegreeName = Degree.DegreeName;
            applicationDbContext.SaveChanges();
        }
    }
}
