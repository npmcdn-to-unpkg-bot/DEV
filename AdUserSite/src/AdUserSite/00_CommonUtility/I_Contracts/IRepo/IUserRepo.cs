using System.Collections.Generic;
using AdUserSite._00_CommonUtility.Models;

namespace AdUserSite._00_CommonUtility.I_Contracts.IRepo
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAll();
        User FindByAccountName(string accountName);
        User FindByEmail(string email);
        User FindByFullName(string firstname, string lastname);
        void Add(User user);
        User Remove(string accountName);
        void Update(User user);
    }
}
