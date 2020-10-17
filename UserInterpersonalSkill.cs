using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Data
{
    public class UserInterpersonalSkill
    {
        public int InterpersonalSkillId { get; set; }
        public string UserId { get; set; }
        public InterpersonalSkill interpersonalSkill { get; set; }
        public User user { get; set; }
    }
}
