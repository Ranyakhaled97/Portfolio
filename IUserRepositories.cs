using PortfolioProject.Data;
using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Repositories
{
   public interface IUserRepositories
    {
        Task<List<User>> GetAllUsers(UserDto dto);
        List<User> GetAllUser();
        User getShowUser(string id);
        public UserDto EditUser(string Id);
        void  UpdateUser(UserDto user);
        User getShowAdmin(string id);



    }
}
