using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;
using PortfolioProject.Models;
using PortfolioProject.Repositories;

namespace PortfolioProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        private readonly IUserRepositories userRepositories;
        private readonly IUserUniversityRepositories userUniversityRepositories;

        public AdminController(ApplicationDbContext applicationDbContext,IUserRepositories userRepositories, IUserUniversityRepositories userUniversityRepositories)
        {
            this.applicationDbContext = applicationDbContext;
            this.userRepositories = userRepositories;
            this.userUniversityRepositories = userUniversityRepositories;
        }
        [Authorize]
        public IActionResult AdminPage()
        {
           
                    var user = userRepositories.GetAllUser();
                    List<UserDto> userDtos = new List<UserDto>();
                    foreach (var x in user)
                    {
                        userDtos.Add(new UserDto()
                        {
                            UserId = x.Id,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            PortfolioEmail = x.PortfolioEmail,
                            MobileNumber = (int)x.MobileNumber
                        });
                    }
                    ViewBag.User = userDtos;
                    return View();
                 
        }
        [Authorize]
        public IActionResult ShowUser(string userId)
        {
            var unii = applicationDbContext.Universities.ToList();
            ViewBag.unii = unii;
            var degree = applicationDbContext.Degrees.ToList();
            var uni = applicationDbContext.UserUniversities.Where(x => x.UserId == userId).ToList();
            ViewBag.uni = uni;
            ViewBag.UserId = userId;
            return View();
        }
    }
    }
