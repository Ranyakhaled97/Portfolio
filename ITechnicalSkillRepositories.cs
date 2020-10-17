using PortfolioProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
    public interface ITechnicalSkillRepositories
    {
        Task<List<TechnicalSkill>> GetAllTechnicalSkill();
        public Task<List<TechnicalSkill>> getAllTechnicalSkillById(string Id);
        public void addTechnicalSkill(TechnicalSkill technicalSkills);
        public List<TechnicalSkill> getAllTechnicalSkillsShow();
        public void RemoveTechnicalSkill(int Id);

        public TechnicalSkill UpdateTechnicalSkill(int TechnicalSkillId);
        void showupdate(TechnicalSkill technicalSkill);


    }
}
