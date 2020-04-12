using Model.Contants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    [Table("ROLE_PERMISSION")]
    public class RolePermission
    {
        #region Property
        [Key, Column("ROLE_ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Mã vai trò")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string RoleId { get; set; }

        [Key, Column("PERMISSION_ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Mã quyền")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string PermissionId { get; set; }
        #endregion

        #region Constraints
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("PermissionId")]
        public virtual Permission Permission { get; set; }
        #endregion
    }
}
