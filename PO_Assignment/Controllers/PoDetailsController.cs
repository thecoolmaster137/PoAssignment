using PO_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PO_Assignment.Controllers
{
    public class PoDetailsController : Controller
    {
        

        PodbContext db = new PodbContext();

        private List<MaterialEntryModel> GetMaterial()
        {
            return db.MaterialEntryTable.ToList();
        }

        public ActionResult PartialPoDetails()
        {
            var materials = GetMaterial(); 
            ViewBag.MaterialID = new SelectList(materials, "Id", "Code");
            return View();
        }

        public ActionResult GetMaterialDetails(long materialId)
        {
            var material = db.MaterialEntryTable.FirstOrDefault(m => m.ID == materialId);
            if (material != null)
            {
                return Json(new { shortText = material.ShortText, unit = material.Unit }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}