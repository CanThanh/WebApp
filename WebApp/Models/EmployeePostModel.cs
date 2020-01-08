using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Model;

namespace WebApp.Models
{
    public class EmployeePostModel : Employee
    {
        [DisplayName("Tệp đính kèm  ")]
        public List<HttpPostedFileBase> UploadFiles { get; set; }
    }
}