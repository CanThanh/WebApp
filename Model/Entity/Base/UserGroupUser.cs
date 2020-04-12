using Model.Contants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    [Table("USER_USERGROUP")]
    public class UserGroupUser
    {
        #region Property
        [Key, Column("USER_GROUP_ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Nhóm người dùng")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string UserGroupId { get; set; }

        [Key, Column("USER_ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Người dùng")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string UserId { get; set; }
        #endregion

        #region Constraints
        [ForeignKey("UserGroupId")]
        public virtual UserGroup UserGroup { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        #endregion
    }
}
