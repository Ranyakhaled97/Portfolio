using PortfolioProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
   public interface IUserUniversityRepositories
    {
        Task<List<University>> GettAllUniversities();
        public Task<List<University>> getAllUniversityById(string Id);
        public List<University> getAllUniversitiesEdit();
        public void remove(int Id);
        public void add(University university);
        public University UpdateUniversity(int UniversityId);
        void showupdate(University University);



    }
}
