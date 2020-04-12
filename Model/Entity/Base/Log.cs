using Model.Contants;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    [Table("LOG")]
    public class Log 
    {
        #region Property
        [Key, Column("ID", TypeName = "NVARCHAR2")]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "{0} được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Id { get; set; }

        [Column("TABLE_NAME", TypeName = "NVARCHAR2")]
        [Display(Name = "Tên bảng")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string TableName { get; set; }

        [Column("OBJECT_ID", TypeName = "NVARCHAR2")]
        [Display(Name = "ID đối tượng")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string ObjectId { get; set; }

        [Column("VALUE")]
        [Display(Name = "Giá trị")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public byte[] Value { get; set; }

        [Column("CREATE_DATE")]
        [Display(Name = "Ngày tạo")]
        public long CreateDate { get; set; } = DateTime.Now.Ticks;

        [Column("CREATE_BY", TypeName = "NVARCHAR2")]
        [Display(Name = "Người tạo")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string CreateBy { get; set; }

        [Column("IP_ADDRESS", TypeName = "NVARCHAR2")]
        [Display(Name = "Ip Address")]
        [MaxLength(DesignDbConst.MaxCode, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string IpAdress { get; set; }

        [Column("BROWSER", TypeName = "NVARCHAR2")]
        [Display(Name = "Browser")]
        [MaxLength(DesignDbConst.MaxName, ErrorMessage = "{0} quá dài, chỉ chứa tối đa {1} ký tự")]
        public string Browser { get; set; }
        #endregion

        #region Constraints
        #endregion
    }
}
