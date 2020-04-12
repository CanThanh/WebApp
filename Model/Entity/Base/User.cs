using Model.Contants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    [Table("USER")]
    public class User : BaseEntity
    {
        #region Property
        [Key, Column("ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Id { get; set; }

        [Column("USER_NAME", TypeName = "NVARCHAR2")]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string UserName { get; set; }

        [Column("PASSWORD", TypeName = "NVARCHAR2")]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Password { get; set; }

        [Column("FULL_NAME", TypeName = "NVARCHAR2")]
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự ")]
        public string FullName { get; set; }

        [Column("EMAIL", TypeName = "NVARCHAR2")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "{0} không đúng định dạng")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự ")]
        public string Email { get; set; }

        [Column("MOBILE_PHONE", TypeName = "NVARCHAR2")]
        [Display(Name = "Số điện thoại")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự ")]
        public string MobilePhone { get; set; }

        [Column("STATUS")]
        public int Status { get; set; } = DesignDbConst.NewUser;

        [Column("RESET_PASSWORD_CODE")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự ")]
        public string ResetPasswordCode { get; set; }

        [Column("TIME_RESET_PASSWORD_EXPIRE")]
        public long? TimeResetPasswordExpire { get; set; }

        [Column("USER_TYPE_ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Loại người dùng")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự ")]
        public string UserTypeId { get; set; }
        #endregion

        #region Constraints
        [ForeignKey("UserTypeId")]
        public virtual UserType UserType { get; set; }
        #endregion
    }
}
