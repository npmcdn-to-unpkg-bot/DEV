using AdUserSite._00_CommonUtility.I_Contracts.IRepo;

namespace AdUserSite._00_CommonUtility.I_Contracts
{
    public interface IUoW
    {
        IUserRepo Users { get; }
        void SaveChanges();
    }
}
