using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class StudentSearchModel
    {
        [Display(Name = "Từ khóa")]
        public string Keyword { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}