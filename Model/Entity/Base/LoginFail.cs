using Model.Contants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    [Table("LOGIN_FAIL")]
    public class LoginFail
    {
        #region Property
        [Key, Column("ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "{0} được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Id { get; set; }

        [Display(Name = "Người đăng nhập")]
        [Required(ErrorMessage = "{0} được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string UserName { get; set; }

        [Column("LOG_TIME")]
        [Display(Name = "Thời gian đăng nhập")]
        public long LogTime { get; set; } = DateTime.Now.Ticks;

        [Column("IP_ADDRESS", TypeName = "NVARCHAR2")]
        [Display(Name = "IP Addess")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string IpAddress { get; set; }

        [Column("BROWSER", TypeName = "NVARCHAR2")]
        [Display(Name = "Browser")]
        [MaxLength(DesignDbConst.MaxName, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Browser { get; set; }
        #endregion

        #region Constraints
        #endregion
    }
}
