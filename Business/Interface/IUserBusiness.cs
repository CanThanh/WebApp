using Common.Model;
using Model.Entity;
using Model.Model.Account;

namespace Business.Interface
{
    public interface IUserBusiness : IBaseBusiness<User>
    {
        UserSession Login(string userName, string password, string browserName, string ipAddress);
        bool CheckLogin(string userName, string ipAddress);
        string Register(RegisterModel registerModel);
        string ForgetPassword(ForgetPasswordModel registerModel);
        string ChangePassword(ChangePasswordModel registerModel);
    }
}
