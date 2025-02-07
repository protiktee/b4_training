using Ost_inventory_b4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ost_inventory_b4.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Dashboard()
        {
            if (Session["Message"] == null)
                Session["Message"] = "";
            BaseEquipment baseEquipment = new BaseEquipment();
            List<BaseEquipment> equipments = baseEquipment.LstEquipment();

            ViewBag.Equipment = equipments; 

            return View();
        }
        [HttpPost]
        public ActionResult Dashboard(FormCollection formCollection)
        {
            int hdSelectedEquipmentID = Convert.ToInt32(formCollection["hdSelectedEquipmentID"].ToString());
            string hdSelectedOpType = formCollection["hdSelectedOpType"].ToString();

            BaseEquipment baseEquipmentNew= new BaseEquipment();
            baseEquipmentNew.EquipmentId = hdSelectedEquipmentID;
            baseEquipmentNew.EquipmentName = formCollection["txtName"].ToString();
            baseEquipmentNew.Quantity = Convert.ToInt32(formCollection["txtQuantity"].ToString());
            baseEquipmentNew.EntryDate = DateTime.ParseExact(formCollection["txtEntryDate"].ToString(), "dd/MM/yyyy", null);
            baseEquipmentNew.ReceiveDate = DateTime.ParseExact(formCollection["txtReceiveDate"].ToString(), "dd/MM/yyyy", null);
            if (hdSelectedOpType != "Delete" && hdSelectedOpType != "Update")
            {
                if (baseEquipmentNew.SaveEquipment())
                {
                    Session["Message"] = "Save Successfully";
                }
                else
                {
                    Session["Message"] = "Error Occured";
                }
            }
            else
            {
                try
                {
                    baseEquipmentNew.UpdateEquipment(hdSelectedOpType);
                    Session["Message"] = hdSelectedOpType == "Delete" ? "Deleted Successfully" : "Updated Successfully";
                }
                catch(Exception ex) {
                    Session["Message"] = ex.Message;
                }
                
            }
            
            BaseEquipment baseEquipment = new BaseEquipment();
            List<BaseEquipment> equipments = baseEquipment.LstEquipment();

            ViewBag.Equipment = equipments; 
            return View();
        }
        public ActionResult CustomerAssignment()
        {
            if (Session["Message"] == null)
                Session["Message"] = "";
            return View(); 
        }
        [HttpPost]
        public ActionResult CustomerAssignment(FormCollection frmColl)
        {
             


            BaseEquipment baseEquipment= new BaseEquipment();
            int ddlCustomer = Convert.ToInt32(frmColl["ddlCustomer"].ToString());
            int ddlEquipment = Convert.ToInt32(frmColl["ddlEquipment"].ToString());
            int txtEquiCount = Convert.ToInt32(frmColl["txtEquiCount"].ToString());

            List<BaseEquipment> LstEquipment = baseEquipment.LstEquipment();

            var instock = (from a in LstEquipment where a.EquipmentId == ddlEquipment select a.Stock).FirstOrDefault();

            bool status = true;
            if (instock != null)
            {
                if (txtEquiCount > Convert.ToInt32(instock))
                {
                    status = false;
                }
            }
            //select top 1 a.Stock from table where EquipmentId=@EquipmentId
            if (status)
            {
                baseEquipment.SaveCustomerEquipmentAssignment(frmColl);
                Session["Message"] = "Save Successfully";
                return RedirectToAction("Dashboard", "Inventory");
            }
            else
            {
                Session["Message"] = "Requested quantity not available";
                return View();
            }
        }
    }
}