using Auth_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication7.Controllers
{
    public class UserController : Controller
    {
        db obj = new db();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Signup(Signup model)
        {
            Signup s = new Signup();
            s.name = model.name;
            s.email = model.email;
            s.password = model.password;
            s.Confirmpassword = model.Confirmpassword;
            obj.Signups.Add(s);
            obj.SaveChanges();
            return RedirectToAction("Login");
        }

   
        

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]

        public ActionResult Login(Signup model)
        {
            Signup s = obj.Signups.Where(a => a.email.Equals(model.email) && a.password.Equals(model.password)).SingleOrDefault();
            if (s != null)
            {
                //HttpCookie hc1 = new HttpCookie("UserID", s.userid.ToString());
                //Response.Cookies,Add(hc1);
                //HttpCookie hc2 = new HttpCookie("UserEmail", s.email.ToString());
                //Response.Cookies,Add(hc2);

                //Response.Cookies["UserID"].Value = s.userid.ToString();
                //Response.Cookies["UserEmail"].Value = s.email.ToString();


                Session["UserID"] = s.userid.ToString();
                Session["UserEmail"] = s.email.ToString();

                return RedirectToAction("UserDashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Email/Id or Password";
            }
            return View();
        }
        public ActionResult UserDashboard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();


            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}