﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKeeda.Entity;
using TechnologyKeeda.Repositories.Interfaces;

namespace TechnologyKeeda.Repositories.Implementations
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> GetUserInfo(string username, string password)
        {
            var user = await _context.userInfos.FirstOrDefaultAsync(
                x => x.UserName.ToLower() == username.ToLower()
            && x.Password == password);
            return user;
        }

        public async Task Register(UserInfo userInfo)
        {
            if(!Exists(userInfo.UserName))
            {
                await _context.userInfos.AddAsync(userInfo);
                await _context.SaveChangesAsync();
            }
   
        }

        private bool Exists(string username)
        {
            return _context.userInfos.Any(x=>x.UserName.ToLower() == username.ToLower());
        }
    }
}
