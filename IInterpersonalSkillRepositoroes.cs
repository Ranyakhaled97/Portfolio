using PortfolioProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
    public interface IInterpersonalSkillRepositoroes
    {
       public Task<List<InterpersonalSkill>> GettAllInterpersonalSkill();
        public Task<List<InterpersonalSkill>> getAllInterPersonalSkillsById(string Id);
        public List<InterpersonalSkill> getAllInterpersonalSkillsShow();
        public void addInterpersonalSkill(InterpersonalSkill interpersonalSkills);
        public void RemoveInterpersonalSkill(int Id);

        public InterpersonalSkill UpdateInterpersonalSkill(int InterpersonalSkillId);
        void showupdate(InterpersonalSkill InterpersonalSkill);

    }
}
