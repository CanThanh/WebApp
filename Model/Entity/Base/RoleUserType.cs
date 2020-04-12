using Model.Contants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    [Table("ROLE_USERTYPE")]
    public class RoleUserType
    {
        #region Property
        [Key, Column("ROLE_ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Mã vai trò")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string RoleId { get; set; }

        [Key, Column("USERTYPE_ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Mã loại người dùng")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string UserTypeId { get; set; }
        #endregion

        #region Constraints
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("UserTypeId")]
        public virtual UserType UserType { get; set; }
        #endregion
    }
}
