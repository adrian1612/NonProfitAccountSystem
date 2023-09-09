using Microsoft.Reporting.WebForms;
using NonProfitAccountSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NonProfitAccountSystem.Controllers
{
    public class HomeController : Controller
    {
        tbl_User user = new tbl_User();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RestrictedAccess()
        {
            return View();
        }

        public ActionResult Login(string Message = null)
        {
            ViewBag.Message = Message;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usr, string pwd)
        {
            var item = user.Login(usr, pwd);
            if (item == null)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
            }
            if (ModelState.IsValid)
            {
                Session["User"] = item;
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(tbl_User m)
        {
            if (ModelState.IsValid)
            {
                user.Create(m);
                return RedirectToAction("Login", new { Message = "Account Successfully Created"});
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/");
        }

        //public ActionResult Print(int ID)
        //{
        //    ReportViewer rv = new ReportViewer(); //EXCELOPENXML FOR EXCEL & application/vnd.ms-excel FOR contentType
        //    rv.LocalReport.ReportPath = Server.MapPath("~/Reports/Report.rdlc");
        //    var data = new object { };
        //    rv.LocalReport.DataSources.Add(new ReportDataSource("Report", data));
        //    var file = rv.LocalReport.Render("pdf");
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", $"inline;filename=Form.pdf");
        //    Response.Buffer = true;
        //    Response.Clear();
        //    Response.BinaryWrite(file);
        //    Response.End();
        //    return View(file);
        //}
    }
}