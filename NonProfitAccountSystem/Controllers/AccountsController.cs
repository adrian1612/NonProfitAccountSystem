using NonProfitAccountSystem.Classes;
using NonProfitAccountSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NonProfitAccountSystem.Models
{
    public class AccountsController : Controller
    {
        dbcontrol exs;
        tbl_Accounts mod = new tbl_Accounts();
        public ActionResult Index()
        {
            var list = mod.List();
            return View(list);
        }

        [HttpPost]
        public ActionResult UploadExcel(HttpPostedFileBase file)
        {
            if (!Directory.Exists(Server.MapPath("~/ExcelFile")))
            {
                Directory.CreateDirectory(Server.MapPath("~/ExcelFile"));
            }
            var location = Server.MapPath("~/ExcelFile/" + file.FileName);
            file.SaveAs(location);
            exs = new dbcontrol($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={location};Extended Properties='Excel 12.0 Xml;HDR=YES';", AAJControl.DatabaseType.OLEDB);
            var listSubs = new tbl_Subscriber().List();
            var nonProfitStaff = new tbl_User().List();
            exs.Query("SELECT * FROM [Sheet1$]").ForEach(r =>
            {
                if (r != null)
                {
                    mod.Create(new tbl_Accounts
                    {
                        AccountName = Convert.ToString(r[0]),
                        AccountBday = Convert.ToDateTime(r[1]),
                        MedicaidDate = Convert.ToDateTime(r[2]),
                        AddressLine = Convert.ToString(r[3]),
                        City = Convert.ToString(r[4]),
                        State = Convert.ToString(r[5]),
                        Zipcode = Convert.ToString(r[6]),
                        PhoneHome = Convert.ToString(r[7]),
                        Language = Convert.ToString(r[8]),
                        HouseHoldIndicator = Convert.ToString(r[9]),
                        Subscriber = listSubs?.Find(f => f.Subscriber == Convert.ToString(r[10]))?.ID,
                        CountryCode = Convert.ToString(r[11]),
                        NonProfitStaff = nonProfitStaff?.Find(f => f.Username == Convert.ToString(r[12]))?.ID.ToString(),
                        CallAttemDateTime1 = Convert.ToDateTime(r[13]),
                        Comment1 = Convert.ToString(r[14]),
                        CallAttemDateTime2 = Convert.ToDateTime(r[15]),
                        Comment2 = Convert.ToString(r[16]),
                        CallAttemDateTime3 = Convert.ToDateTime(r[17]),
                        Comment3 = Convert.ToString(r[18]),
                        HomeVisitAttempDate = Convert.ToDateTime(r[19]),
                        HomeVisitComment = Convert.ToString(r[20]),
                        Unreachable = Convert.ToString(r[21]).ToUpper() == "YES" ? true : false,
                        ACA = Convert.ToString(r[22]).ToUpper() == "YES" ? true : false,
                        PersonalNotes = Convert.ToString(r[23])
                    });
                }
               
            });
            if (Directory.Exists(Server.MapPath("~/ExcelFile")))
            {
                Directory.Delete(Server.MapPath("~/ExcelFile"), true);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Action(string Type, int? ID = null)
        {
            switch (Type)
            {
                case "Add":
                    return RedirectToAction("Create");
                case "Edit":
                    return RedirectToAction("Edit", new { ID = ID });
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Accounts m)
        {
            if (ModelState.IsValid)
            {
                mod.Create(m);
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Edit(int ID)
        {
            var item = mod.Find(ID);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(tbl_Accounts m)
        {
            if (ModelState.IsValid)
            {
                mod.Update(m);
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Detail(int ID)
        {
            var item = mod.Find(ID);
            return View(item);
        }

        public ActionResult Delete(int ID)
        {
            var item = mod.Find(ID);
            return View(item);
        }

        [HttpPost]
        public ActionResult Delete(tbl_Accounts m)
        {
            m.Delete(m);
            return RedirectToAction("Index");
        }
    }
}