using PortfolioProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
    public class InterpersonalSkillRepositoroes : IInterpersonalSkillRepositoroes
    {
        private readonly ApplicationDbContext applicationDbContext;
        public InterpersonalSkillRepositoroes(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        

        public async Task<List<InterpersonalSkill>> GettAllInterpersonalSkill()
        {
            var interpersonal= applicationDbContext.InterpersonalSkills.ToList();
            return interpersonal;
        }

        public async Task<List<InterpersonalSkill>> getAllInterPersonalSkillsById(string Id)
        {
            return applicationDbContext.UserInterpersonalSkills
               .Where(x => x.UserId == Id).Select(x => x.interpersonalSkill).ToList();
        }
        public List<InterpersonalSkill> getAllInterpersonalSkillsShow()
        {
            return applicationDbContext.InterpersonalSkills.ToList();
        }
        public void RemoveInterpersonalSkill(int Id)
        {
            var skill = applicationDbContext.InterpersonalSkills.Where(x => x.InterpersonalSkillId == Id).SingleOrDefault();
            applicationDbContext.InterpersonalSkills.Remove(skill);
            applicationDbContext.SaveChanges();
        }
        public void addInterpersonalSkill(InterpersonalSkill interpersonalSkills)
        {
            InterpersonalSkill interpersonalSkill = new InterpersonalSkill()
            {
                InterpersonalSkillName = interpersonalSkills.InterpersonalSkillName,
            };
            applicationDbContext.InterpersonalSkills.Add(interpersonalSkill);
            applicationDbContext.SaveChanges();
        }

        public InterpersonalSkill UpdateInterpersonalSkill(int InterpersonalSkillId)
        {
            var InterpersonalSkill = applicationDbContext.InterpersonalSkills.Where(x => x.InterpersonalSkillId == InterpersonalSkillId).SingleOrDefault();
            InterpersonalSkill InterpersonalSkill1 = new InterpersonalSkill()
            {
                InterpersonalSkillId = InterpersonalSkill.InterpersonalSkillId,
                InterpersonalSkillName = InterpersonalSkill.InterpersonalSkillName
            };
            return InterpersonalSkill1;
        }

        public void showupdate(InterpersonalSkill InterpersonalSkill)
        {
            var InterpersonalSkill1 = applicationDbContext.InterpersonalSkills.Where(x => x.InterpersonalSkillId == InterpersonalSkill.InterpersonalSkillId).SingleOrDefault();
            InterpersonalSkill1.InterpersonalSkillId = InterpersonalSkill.InterpersonalSkillId;
            InterpersonalSkill1.InterpersonalSkillName = InterpersonalSkill.InterpersonalSkillName;
            applicationDbContext.SaveChanges();
        }
    }
}
