using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models.Ext;
using Models;
using System.Web.Script.Serialization;

namespace StudentManagerMVC.Controllers
{
    public class StudentsController : Controller
    {
        //
        // GET: /Students/

        public ActionResult Index()
        {
            return View("StudentManage");
        }

        [HttpPost]
        public ActionResult StudentManage()
        {
            string className = Request.Params["ClassName"];
            List<StudentsExt> stulist = new StudentsManage().queryStudentsbyClassName(className);
            ViewBag.className = className;
            ViewBag.stulist = stulist;
            return View();
        }

        [HttpGet]
        public ActionResult StudentDetail()
        {
            int studentId = Convert.ToInt32(Request.Params["StudentId"]);
            StudentsExt stu = new StudentsManage().queryStudentByStudentId(studentId);
            ViewBag.stu = stu;
            return View();
        }

        [HttpGet]
        public ActionResult StudentShow()
        {
            int studentId = Convert.ToInt32(Request.Params["StudentId"]);
            StudentsExt stu = new StudentsManage().queryStudentByStudentId(studentId);
            return View("StudentUpdate",stu);
        }

        [HttpPost]
        public ActionResult StudentUpdate(StudentsExt stu)
        {
            
            int result = new StudentsManage().UpdateStudent(stu);
            if (result >0) return Content("<script type='text/javascript'>alert('更新成功！');document.location='"+Url.Action("Index","Students")+"'</script>");
            else if (result == 0) return Content("<script type='text/javascript'>alert('更新失败！');document.location='" + Url.Action("Index", "Students") + "'</script>");
            else return Content("<script type='text/javascript'>alert('系统异常');document.location='" + Url.Action("Index", "Students") + "'</script>");
        }


        public ActionResult getStulistJsonByClassName(string ClassName)
        {
            List<StudentsExt> stulist = new StudentsManage().queryStudentsbyClassName(ClassName);
            string stus=new JavaScriptSerializer().Serialize(stulist);
            return Json(stus, JsonRequestBehavior.AllowGet);
        }
    }
}
