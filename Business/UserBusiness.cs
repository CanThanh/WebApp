using Business.Interface;
using Common;
using Common.Model;
using Model.Contants;
using Model.Entity;
using Model.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class UserBusiness : BaseBusiness<User> , IUserBusiness
    {
        public UserBusiness() : base()
        {
        }
        public override bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override User GetById(string id)
        {
            throw new NotImplementedException();
        }

        public override string InsertOrUpdate(string id)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string tableName, string objectId, string value, string createBy, bool isSaveChange = false)
        {
            WriteLog(tableName, objectId, value, createBy, isSaveChange);
        }

        public string Register(RegisterModel registerModel)
        {
            var result = string.Empty;
            try
            {
                var userExist = baseDbContext.Users.FirstOrDefault(x => x.UserName == registerModel.UserName || x.Email == registerModel.Email);
                if(userExist == null)
                {
                    var userType = baseDbContext.UserTypes.First(x => x.Name.ToLower() == UserTypeNameConst.Guest.ToLower());
                    var user = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = registerModel.UserName,
                        Password = registerModel.Password,
                        FullName = registerModel.FullName,
                        Email = registerModel.Email,
                        UserType = userType
                    };
                    baseDbContext.Users.Add(user);
                    baseDbContext.SaveChanges();
                    result = user.Id;
                }
            }
            catch (Exception ex)
            {
                result = string.Empty;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public UserSession Login(string userName, string password, string browserName, string ipAddress)
        {
            var result = new UserSession();
            try
            {
                var user = baseDbContext.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
                if(user != null)
                {
                    result.UserId = user.Id;
                    result.UserName = user.UserName;
                    if(user.UserType.Name.ToLower() == UserTypeNameConst.Admin.ToLower())
                    {
                        result.LstPermission = baseDbContext.Permissions.Select(x => x.Name).ToList();
                    }
                    else
                    {
                        //Lấy theo vai trò + loại người dùng
                        result.LstPermission = new List<string>();
                    }
                }
                else
                {
                    var loginFail = new LoginFail
                    {
                        Id = Guid.NewGuid().ToString(),
                        IpAddress = ipAddress,
                        Browser = browserName,
                        UserName = userName
                    };
                    baseDbContext.LoginFails.Add(loginFail);
                    baseDbContext.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = new UserSession();
            }
            return result;
        }

        public bool CheckLogin(string userName, string ipAddress)
        {
            var result = true;
            try
            {
                var timeCheck = DateTime.Now.AddHours(-1).Ticks;
                var lstLoginFail = baseDbContext.LoginFails.Where(x => x.LogTime > timeCheck).ToList();
                if(lstLoginFail.Where(x=>x.IpAddress == ipAddress).Count() >= 5)
                {
                    result = false;
                }
                if (lstLoginFail.Where(x => x.UserName == userName).Count() >= 3)
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            return result;
        }
        public string ForgetPassword(ForgetPasswordModel forgetPasswordModel)
        {
            var result = string.Empty;
            try
            {
                var userExist = baseDbContext.Users.FirstOrDefault(x => x.Email == forgetPasswordModel.Email);
                if (userExist != null)
                {
                    userExist.ResetPasswordCode = Guid.NewGuid().ToString();
                    userExist.TimeResetPasswordExpire = DateTime.Now.AddHours(1).Ticks;
                    //Cập nhật user
                    baseDbContext.Entry(userExist).CurrentValues.SetValues(userExist);
                    baseDbContext.SaveChanges();
                    result = userExist.ResetPasswordCode;
                }
            }
            catch (Exception ex)
            {
                result = string.Empty;
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        public string ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var result = string.Empty;
            try
            {
                var userExist = baseDbContext.Users.FirstOrDefault(x => x.UserName == changePasswordModel.UserName && x.Password == changePasswordModel.OldPassword);
                if (userExist != null)
                {
                    userExist.Password = changePasswordModel.Password;
                    //Cập nhật user
                    baseDbContext.Entry(userExist).CurrentValues.SetValues(userExist);
                    baseDbContext.SaveChanges();
                    result = userExist.Id;
                }
            }
            catch (Exception ex)
            {
                result = string.Empty;
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
