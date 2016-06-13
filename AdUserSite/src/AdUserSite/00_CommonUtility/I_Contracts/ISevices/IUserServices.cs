using System.Collections.Generic;
using AdUserSite._00_CommonUtility.Models;

namespace AdUserSite._00_CommonUtility.I_Contracts.ISevices
{
    public interface IUserServices
    {
        IEnumerable<User> GetAll();
        User FindByAccountName(string accountName);
        User FindByEmail(string eMail);
        void Add(User user);
        User Remove(string accountName);
        void Update(User user);

        bool CheckIfAccountnameExist(string accountname);
        bool CheckIfEmailExist(string eMail);
        bool CheckIfFullNameExist(string firstname, string lastname);
    }
}
