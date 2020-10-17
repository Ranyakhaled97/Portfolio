using PortfolioProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
    public class TechnicalSkillRepositories : ITechnicalSkillRepositories
    {

        private readonly ApplicationDbContext applicationDbContext;
        public TechnicalSkillRepositories(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<List<TechnicalSkill>> GetAllTechnicalSkill()
        {
            var TechnicalSkills = applicationDbContext.TechnicalSkills.ToList();
            return TechnicalSkills;
        }

        public async Task<List<TechnicalSkill>> getAllTechnicalSkillById(string Id)
        {
            return applicationDbContext.UserTechnicalSkills
              .Where(x => x.UserId == Id).Select(x => x.technicalSkill).ToList();
        }
        public List<TechnicalSkill> getAllTechnicalSkillsShow()
        {
            return applicationDbContext.TechnicalSkills.ToList();
        }

        public void addTechnicalSkill(TechnicalSkill technicalSkills)
        {
            TechnicalSkill technicalSkill = new TechnicalSkill()
            {
                TechnicalSkillName = technicalSkills.TechnicalSkillName,
            };
            applicationDbContext.TechnicalSkills.Add(technicalSkill);
            applicationDbContext.SaveChanges();
        }
        public void RemoveTechnicalSkill(int Id)
        {
            var skill = applicationDbContext.TechnicalSkills.Where(x => x.TechnicalSkillId == Id).SingleOrDefault();
            applicationDbContext.TechnicalSkills.Remove(skill);
            applicationDbContext.SaveChanges();
        }

        public TechnicalSkill UpdateTechnicalSkill(int TechnicalSkillId)
        {
            var TechnicalSkill = applicationDbContext.TechnicalSkills.Where(x => x.TechnicalSkillId == TechnicalSkillId).SingleOrDefault();
            TechnicalSkill TechnicalSkill1 = new TechnicalSkill()
            {
                TechnicalSkillId = TechnicalSkill.TechnicalSkillId,
                TechnicalSkillName = TechnicalSkill.TechnicalSkillName
            };
            return TechnicalSkill1;
        }

        public void showupdate(TechnicalSkill technicalSkill)
        {
            var technicalSkill1 = applicationDbContext.TechnicalSkills.Where(x => x.TechnicalSkillId == technicalSkill.TechnicalSkillId).SingleOrDefault();
            technicalSkill1.TechnicalSkillId = technicalSkill.TechnicalSkillId;
            technicalSkill1.TechnicalSkillName = technicalSkill.TechnicalSkillName;
            applicationDbContext.SaveChanges();
        }
    }
}
