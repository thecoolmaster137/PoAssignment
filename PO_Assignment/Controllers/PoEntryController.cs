using PO_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace PO_Assignment.Controllers
{
    public class PoEntryController : Controller
    {
        
        PodbContext db = new PodbContext();

        public ViewResult Index()
        {
            return View(db.PoHeaderTable.ToList());
        }

        private List<VendorEntryModel> GetVendors()
        {
            return db.VentorEntryTable.ToList();
        }

        private List<MaterialEntryModel> GetMaterials()
        {
            return db.MaterialEntryTable.ToList();
        }



        public ActionResult GetNextPONumber()
        {
            string nextPONumber;

            long lastPONumber = GetLastPONumberFromDatabase();

            if (lastPONumber != 0)
            {
                long lastNumber = lastPONumber + 1;
                nextPONumber = lastNumber.ToString();
            }
            else
            {
                nextPONumber = "1";
            }

            return Json(new { nextPONumber }, JsonRequestBehavior.AllowGet);
        }

        private long GetLastPONumberFromDatabase()
        {
            var lastPONumber = db.PoHeaderTable
                                 .OrderByDescending(p => p.OrderNumber) 
                                 .Select(p => p.OrderNumber)
                                 .FirstOrDefault();

            return lastPONumber;
        }


       
        [HttpPost]
        public ActionResult Save(PoHeaderModel headerModel, string detailsJson)
        {
            
            List<PoDetailsModel> detailsModels = JsonConvert.DeserializeObject<List<PoDetailsModel>>(detailsJson);

            try
            {
                long orderValue = (long)(detailsModels.Sum(d => d.ItemValue));

                headerModel.OrderValue = orderValue;
                headerModel.OrderStatus = "Open";
                db.PoHeaderTable.Add(headerModel);
                db.SaveChanges();

                long orderId = headerModel.ID;

                
                foreach (var detailsModel in detailsModels)
                {
                    detailsModel.OrderID = orderId;
                    db.PoDetailsTable.Add(detailsModel);
                }

                
                db.SaveChanges();

               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error saving data: " + ex.Message });
            }
        }




        public ActionResult Create()
        {
            var vendors = GetVendors();
            ViewBag.VendorId = new SelectList(vendors, "Id", "Name");

            var materials = GetMaterials();
            ViewBag.Materials = new SelectList(materials, "Id", "Code");

            return View();
        }

        

    }
}
