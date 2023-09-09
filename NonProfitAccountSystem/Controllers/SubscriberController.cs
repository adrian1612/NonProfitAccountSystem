using NonProfitAccountSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NonProfitAccountSystem.Models
{
    public class SubscriberController : Controller
    {
        tbl_Subscriber mod = new tbl_Subscriber();
        public ActionResult Index()
        {
            var list = mod.List();
            return View(list);
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
        public ActionResult Create(tbl_Subscriber m)
        {
            if (mod.List().Exists(f => f.Subscriber == m.Subscriber))
            {
                ModelState.AddModelError("", "Subscriber already in the record!");
            }
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
        public ActionResult Edit(tbl_Subscriber m)
        {
            if (mod.List().Exists(f => f.Subscriber == m.Subscriber && m.ID != f.ID))
            {
                ModelState.AddModelError("", "Subscriber already in the record!");
            }
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
        public ActionResult Delete(tbl_Subscriber m)
        {
            m.Delete(m);
            return RedirectToAction("Index");
        }
    }
}