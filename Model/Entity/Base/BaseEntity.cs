using Model.Contants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    public class BaseEntity
    {
        [Column("CREATE_DATE")]
        [Display(Name = "Ngày tạo")]
        public long CreateDate { get; set; } = DateTime.Now.Ticks;

        [Column("CREATE_BY", TypeName = "NVARCHAR2")]
        [Display(Name = "Người tạo")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string CreateBy { get; set; }

        [Column("MODIFY_DATE")]
        [Display(Name = "Ngày sửa")]
        public long? ModifyDate { get; set; }

        [Column("MODIFY_BY", TypeName = "NVARCHAR2")]
        [Display(Name = "Người sửa")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string ModifyBy { get; set; }
    }
}
