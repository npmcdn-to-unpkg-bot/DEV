using System;
using System.Collections.Generic;
using AdUserSite._00_CommonUtility.I_Contracts.IRepo;
using AdUserSite._00_CommonUtility.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdUserSite._01_DataAccess.Repo
{
    public class UserRepo: IUserRepo
    {
        //private readonly DataContext _context;
        //public UserRepo(DataContext context)
        //{
        //    _context = context;
        //}
        private readonly DataContext _context;
        public UserRepo(DataContext context)
        {
            _context = context;
        }


        public User FindByAccountName(string accountName)
        {
                User user = _context.Users.SingleOrDefault(u => u.AccountName == accountName);
                return user;                                
        }

        public User FindByEmail(string email)
        {
            //var user = _context.Users.Single(m => m.Id == id);
            User user = _context.Users.SingleOrDefault(u => u.Email == email);
            return user;
        }

        public User FindByFullName(string firstname, string lastname)
        {
            User fullName =
                _context.Users.FirstOrDefault(u => u.FirstName == firstname && u.LastName == lastname);
            return fullName;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _context.Users.ToList();
            return users;
        }



        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public User Remove(string accountName)
        {
            User user = _context.Users.Single(u => u.AccountName == accountName);
            _context.Users.Remove(user);
            return user;
        }
       
        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
