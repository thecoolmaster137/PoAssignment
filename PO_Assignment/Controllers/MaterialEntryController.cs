using PO_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;


namespace PO_Assignment.Controllers
{
    public class MaterialEntryController : Controller
    {
        

        PodbContext db = new PodbContext();

        public ViewResult Index()
        {
            return View(db.MaterialEntryTable.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public ActionResult PostVendorList()
        {
            if (ModelState.IsValid)
            {
                MaterialEntryModel materialEntry = new MaterialEntryModel();
                TryUpdateModel(materialEntry);
                db.MaterialEntryTable.Add(materialEntry);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MaterialEntryModel materialEntry = db.MaterialEntryTable.Find(id);

            if (materialEntry == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(materialEntry);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            MaterialEntryModel materialEntry = db.MaterialEntryTable.Find(id);
            UpdateModel(materialEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MaterialEntryModel materialEntry = db.MaterialEntryTable.Find(id);
            if (materialEntry == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(materialEntry);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            MaterialEntryModel materialEntry = db.MaterialEntryTable.Find(id);
            db.MaterialEntryTable.Remove(materialEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}