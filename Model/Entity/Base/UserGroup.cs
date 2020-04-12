using Model.Contants;
using Model.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    [Table("USER_GROUP")]
    public class UserGroup : BaseEntity
    {
        #region Property
        [Key, Column("ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "{0} được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Id { get; set; }

        [Column("NAME", TypeName = "NVARCHAR2")]
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Name { get; set; }
        #endregion

        #region Constraints
        #endregion
    }
}
