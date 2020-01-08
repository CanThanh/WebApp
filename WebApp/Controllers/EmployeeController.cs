using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Common;
using Model;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeController : BaseController
    {
        private static List<Employee> LstEmployees = new List<Employee>();

        public static void InitData()
        {
            Random random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                var employee = new Employee()
                {
                    Id = i,
                    Name = i.ToString(),
                    Salary = random.NextDouble(),
                };
                LstEmployees.Add(employee);
            }
        }
        // GET: Home
        public ActionResult Index()
        {
            InitData();
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchModel<EmployeeSearchModel> parameter)
        {
            var query = LstEmployees.Where(x =>
                    string.IsNullOrEmpty(parameter.Cretia.Keyword) ||
                    x.Name.ToLower().Contains(parameter.Cretia.Keyword.ToLower()))
                ;

            int totalRow = query.Count();

            var model = query.OrderByDescending(x => x.Id)
                .Skip((parameter.PageIndex - 1) * parameter.PageSize)
                .Take(parameter.PageSize);

            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id)
        {
            var data = LstEmployees.FirstOrDefault(x => x.Id == id);           
            return PartialView("_AddOrEdit", data);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee data)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { IsError = true, ErrorCode = 1, Message = RenderRazorViewToString("_AddOrEdit", data) }, JsonRequestBehavior.AllowGet);
            }

            if (data.Id == 0)
            {
                LstEmployees.Add(data);
            }
            else
            {
                var existObj = LstEmployees.FirstOrDefault(x => x.Id == data.Id);
                if (existObj == null)
                {
                    return Json(new { IsError = true, Message = "Dữ liệu không hợp lệ" }, JsonRequestBehavior.AllowGet);
                }
                existObj.Name = data.Name;
                existObj.Salary = data.Salary;
            }
            return Json(new { IsError = false, Message = String.Empty }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existObj = LstEmployees.FirstOrDefault(x => x.Id == id);
            if (existObj == null)
            {
                return Json(new { IsError = true, Message = "Dữ liệu không hợp lệ" }, JsonRequestBehavior.AllowGet);
            }

            LstEmployees.Remove(existObj);
            return Json(new { IsError = false, Message = String.Empty }, JsonRequestBehavior.AllowGet);
        }
    }
}