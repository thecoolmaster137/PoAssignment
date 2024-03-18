using PO_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace PO_Assignment.Controllers
{
    public class VendorEntryController : Controller
    {
        

        PodbContext db = new PodbContext();

        public ViewResult Index()
        {
            return View(db.VentorEntryTable.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ActionName("Create")]
        public ActionResult PostVendorList()
        {
            if(ModelState.IsValid)
            {
                VendorEntryModel vendorEntry = new VendorEntryModel();
                TryUpdateModel(vendorEntry);
                db.VentorEntryTable.Add(vendorEntry);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VendorEntryModel vendorEntry = db.VentorEntryTable.Find(id);

            if(vendorEntry == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(vendorEntry);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            VendorEntryModel vendorEntry = db.VentorEntryTable.Find(id);
            UpdateModel(vendorEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VendorEntryModel vendorEntry = db.VentorEntryTable.Find(id);
            if(vendorEntry == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(vendorEntry);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            VendorEntryModel vendorEntry = db.VentorEntryTable.Find(id);
            db.VentorEntryTable.Remove(vendorEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

