using Model.Contants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    [Table("MENU")]
    public class Menu
    {
        #region Property
        [Key, Column("ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "{0} được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Id { get; set; }

        [Column("NAME", TypeName = "NVARCHAR2")]
        [Display(Name = "Tên menu")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Name { get; set; }

        [Column("LINK", TypeName = "NVARCHAR2")]
        [Display(Name = "Liên kết")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxName, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Link { get; set; }

        [Column("PARENT_ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Mã menu cha")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string ParentId { get; set; } = string.Empty;

        [Column("MENU_TYPE", TypeName = "NVARCHAR2")]
        [Display(Name = "Loại menu")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string MenuType { get; set; } = string.Empty;

        [Column("MENU_ICON", TypeName = "NVARCHAR2")]
        [Display(Name = "Icon menu")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string MenuIcon { get; set; } = string.Empty;

        [Column("ORDER")]
        [Display(Name = "Thứ tự hiển thị")]
        public int Order { get; set; }

        [Column("PERMISSION_ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Quyền menu")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string PermissionId { get; set; } = string.Empty;
        #endregion

        #region Constraints
        [ForeignKey("ParentId")]
        public virtual Menu ParentMenu { get; set; }

        [ForeignKey("PermissionId")]
        public virtual Permission Permission { get; set; }
        #endregion
    }
}
