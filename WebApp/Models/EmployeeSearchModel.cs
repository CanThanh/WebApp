using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmployeeSearchModel
    {
        [Display(Name = "Từ khóa")]
        public string Keyword { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}