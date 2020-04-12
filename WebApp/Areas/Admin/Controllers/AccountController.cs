using Business.Interface;
using Common;
using Common.Function;
using Common.Model;
using Model.Model.Account;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        readonly IUserBusiness userBusiness;
        public AccountController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        #region Login/Logout
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                loginModel.UserName = loginModel.UserName.ToLower();
                var ipAddress = GetIpAddress();
                var browserName = GetBrowserName();
                if (userBusiness.CheckLogin(loginModel.UserName, ipAddress))
                {
                    loginModel.Password = AES.EncryptString(loginModel.Password, loginModel.UserName);
                    var userSession = userBusiness.Login(loginModel.UserName, loginModel.Password, browserName, ipAddress);
                    userSession.BrowserName = browserName;
                    userSession.IpAddress = ipAddress;
                    if (!string.IsNullOrEmpty(userSession.UserId))
                    {
                        Session.Add(CommonConstants.UserSession, userSession);
                        return RedirectToAction("Index", "Student", new { @Area = "" });
                        //return Json(new { IsError = false, Url = Url.Action("Index", "Student", new { @Area = "" }) });
                    }
                }
            }
            ModelState.AddModelError("UserName", "Đăng nhập sai quá nhiều. Quay lại sau 1 tiếng nữa");
            return View("Login", loginModel);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Account", new { @Area = "Admin" });
        }
        #endregion

        #region Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            CaptchaResponse response = ValidateCaptcha(Request["g-recaptcha-response"]);
            if (response.Success && ModelState.IsValid)
            {
                registerModel.UserName = registerModel.UserName.ToLower();
                registerModel.Password = AES.EncryptString(registerModel.Password, registerModel.UserName);
                if (!string.IsNullOrEmpty(userBusiness.Register(registerModel)))
                {
                    return RedirectToAction("Index", "Student", new { @Area = "" });
                }
            }
            return View("Register", registerModel);
        }
        public CaptchaResponse ValidateCaptcha(string response)
        {
            string secret = "6LdON-YUAAAAAIzHnItgnjhoVn2wSnBic3kaNT-v";
            var client = new WebClient();
            var jsonResult = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            return JsonConvert.DeserializeObject<CaptchaResponse>(jsonResult.ToString());
        }
        #endregion

        #region ForgetPassword
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordModel forgetPasswordModel)
        {
            CaptchaResponse response = ValidateCaptcha(Request["g-recaptcha-response"]);
            if (response.Success && ModelState.IsValid)
            {
                var result = userBusiness.ForgetPassword(forgetPasswordModel);
                if (!string.IsNullOrEmpty(result))
                {
                    //Gửi mail xác nhận thay đổi mật khẩu
                    CommonFunctions.SendGmail(new MailModel {
                        SenderAccount = "canthanh028428@gmail.com",
                        SenderPassword = "017028428",
                        SenderName = "Pizza",
                        Subject = "Đổi mật khẩu",
                        Body = string.Format("<a href='http://localhost:57853/Admin/Account/ResetPassword?sessionId={0}&newPassword={1}'></a>", result, CommonFunctions.CreateRandomPassword()),
                        LstReceiver = new List<string> { forgetPasswordModel.Email }
                    });
                    return RedirectToAction("Login", "Account", new { @Area = "Admin" });
                }
            }
            return View("ForgetPassword", forgetPasswordModel);
        }
        #endregion

        #region ResetPassword
        public ActionResult ResetPassword(string sessionId, string newPassword)
        {

            return View();
        }
        #endregion

        #region ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var session = (UserSession)Session[CommonConstants.UserSession];
            if (session != null)
            {
                changePasswordModel.UserName = session.UserName;
                changePasswordModel.OldPassword = AES.EncryptString(changePasswordModel.OldPassword, changePasswordModel.UserName);
                changePasswordModel.Password = AES.EncryptString(changePasswordModel.Password, changePasswordModel.UserName);
                if (!string.IsNullOrEmpty(userBusiness.ChangePassword(changePasswordModel)))
                {
                    return RedirectToAction("Index", "Student", new { @Area = "" });
                }
            }
            return View();
        }

        private string GetIpAddress()
        {
            string ipAdd = string.Empty;
            try
            {
                ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ipAdd))
                {
                    ipAdd = Request.ServerVariables["REMOTE_ADDR"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ipAdd.ToLower();
        }

        private string GetBrowserName()
        {
            string webBrowserName = string.Empty;
            try
            {
                webBrowserName = System.Web.HttpContext.Current.Request.Browser.Browser;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return webBrowserName.ToLower();
        }
        #endregion
    }
}