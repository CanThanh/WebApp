using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [MaxLength(20, ErrorMessage = "Tên quá dài. Nhập 20 ký tự")]
        public string Name { get; set; }
        [Display(Name = "Lương")]
        [Required(ErrorMessage = "Vui lòng nhập lương")]
        [Range(0, Double.MaxValue, ErrorMessage = "Vui lòng nhập kiểu số")]
        public double Salary { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
    }
}
