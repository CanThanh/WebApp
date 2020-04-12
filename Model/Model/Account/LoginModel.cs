using Model.Contants;
using Model.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model.Account
{
    public class LoginModel
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        //[MinLength(9, ErrorMessage = "{0} quá ngắn, cần chứa tối thiểu {1} ký tự")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ")]
        public bool Checked { get; set; }
    }

    [NotMapped]
    public class RegisterModel
    {
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự ")]
        public string FullName { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Password { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [Compare("Password", ErrorMessage = "Vui lòng nhập trùng với nhập khẩu")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "{0} không đúng định dạng")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự ")]
        public string Email { get; set; }
    }

    [NotMapped]
    public class ForgetPasswordModel
    {
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "{0} không đúng định dạng")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự ")]
        public string Email { get; set; }
    }

    [NotMapped]
    public class ChangePasswordModel
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu cũ")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string OldPassword { get; set; }

        [Display(Name = "Mật khẩu mới")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Password { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [Compare("Password", ErrorMessage = "Vui lòng nhập trùng với nhập khẩu mới")]
        public string ConfirmPassword { get; set; }
    }
}
