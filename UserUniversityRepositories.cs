using PortfolioProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
    public class UserUniversityRepositories : IUserUniversityRepositories
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserUniversityRepositories(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<University>> getAllUniversityById(string Id)
        {
            return applicationDbContext.UserUniversities
               .Where(x => x.UserId == Id).Select(x => x.University).ToList();
        }

        public async Task<List<University>> GettAllUniversities()
        {
            var Uni =  applicationDbContext.Universities.ToList();
            return  Uni;
        }
        public List<University> getAllUniversitiesEdit()
        {
            return applicationDbContext.Universities.ToList();
        }
        public void remove(int Id)
        {
            var university = applicationDbContext.Universities.Where(x => x.UniversityId == Id).SingleOrDefault();
            applicationDbContext.Universities.Remove(university);
            applicationDbContext.SaveChanges();
        }
        public void add(University university)
        {
            University university1 = new University()
            {
                UniversityName = university.UniversityName,
            };
            applicationDbContext.Universities.Add(university1);
            applicationDbContext.SaveChanges();
        }

        public University UpdateUniversity(int UniversityId)
        {
            var University = applicationDbContext.Universities.Where(x => x.UniversityId == UniversityId).SingleOrDefault();
            University University1 = new University()
            {
                UniversityId = University.UniversityId,
                UniversityName = University.UniversityName
            };
            return University1;
        }

        public void showupdate(University University)
        {
            var University1 = applicationDbContext.Universities.Where(x => x.UniversityId == University.UniversityId).SingleOrDefault();
            University1.UniversityId = University.UniversityId;
            University1.UniversityName = University.UniversityName;
            applicationDbContext.SaveChanges();
        }
    }
}
