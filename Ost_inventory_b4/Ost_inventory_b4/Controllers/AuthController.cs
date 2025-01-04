﻿using Ost_inventory_b4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ost_inventory_b4.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            Session["UserName"] = "";
            ViewBag.Message = "";
            return View();
        }
        [HttpPost]
        public ActionResult DoLogin(string txtUserName,string txtPassword)
        {
            Session["UserName"] = "";
            string Message = "Unauthorized";

            BaseAccount baseAccount = new BaseAccount();
            if (baseAccount.VerifyUser(txtUserName, txtPassword))
            {
                Message = "Authorized";
                Session["UserName"] = txtUserName;
                //return Redirect("www.google.com"); 
                return RedirectToAction("Dashboard", "Inventory");
            }
            ViewBag.Message = Message;
            //return RedirectToAction("Dashboard", "Inventory");
            return View("Login");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("UserName");  
            return View("Login");
        }
    }
}