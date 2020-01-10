using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Common;
using Model;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController : BaseController
    {
        private static List<Student> LstStudents = new List<Student>();

        public static  void InitData()
        {
            for (int i = 1; i <= 10; i++)
            {
                var student = new Student()
                {
                    Id = i,
                    Name = i.ToString(),
                    Email = i.ToString(),
                };
                LstStudents.Add(student);
            }
        }

        // GET: Student
        public ActionResult Index()
        {
            InitData();
            var data = new StudentSearchModel();
            return View(data);
        }

        [HttpPost]
        public ActionResult Search(SearchModel<StudentSearchModel> parameter)
        {
            var query = LstStudents.Where(x =>
                    string.IsNullOrEmpty(parameter.Cretia.Keyword) ||
                    x.Name.ToLower().Contains(parameter.Cretia.Keyword.ToLower()) ||
                    x.Email.ToLower().Contains(parameter.Cretia.Keyword.ToLower()))
                ;
            var result = new SearchResultModel<List<Student>>()
            {
                Data = query.Skip((parameter.PageIndex - 1) * parameter.PageSize).Take(parameter.PageSize).ToList(),
                TotalRecord = query.Count(),
                PageIndex = parameter.PageIndex,
                PageSize = parameter.PageSize
            };
            return PartialView("_DataSearch", result);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id)
        {
            var data = LstStudents.FirstOrDefault(x => x.Id == id);
            return PartialView("_AddOrEdit", data);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Student data)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { IsError = true, ErrorCode = 1, Message = RenderRazorViewToString("_AddOrEdit", data) }, JsonRequestBehavior.AllowGet);
            }

            if (data.Id == 0)
            {
                LstStudents.Add(data);
            }
            else
            {
                var existObj = LstStudents.FirstOrDefault(x => x.Id == data.Id);
                if (existObj == null)
                {
                    return Json(new { IsError = true, Message = "Dữ liệu không hợp lệ" }, JsonRequestBehavior.AllowGet);
                }
                existObj.Name = data.Name;
                existObj.Email = data.Email;
            }
            return Json(new { IsError = false, Message = String.Empty }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existObj = LstStudents.FirstOrDefault(x => x.Id == id);
            if (existObj == null)
            {
                return Json(new { IsError = true, Message = "Dữ liệu không hợp lệ" }, JsonRequestBehavior.AllowGet);
            }

            LstStudents.Remove(existObj);
            return Json(new { IsError = false, Message = String.Empty }, JsonRequestBehavior.AllowGet);
        }
    }
}