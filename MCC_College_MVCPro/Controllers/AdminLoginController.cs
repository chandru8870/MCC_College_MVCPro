using MCC_College_MVCPro.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MCC_College_MVCPro.Controllers
{
    public class AdminLoginController : Controller
    {
        string sqlCon = ConfigurationManager.ConnectionStrings["MVCConnection"].ConnectionString;
        // GET: AdminLogin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLogin login)
        {
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_login", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("userName", login.userName);
            cmd.Parameters.AddWithValue("Password", login.Password);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FormsAuthentication.SetAuthCookie(login.userName, true);
                Session["userName"] =login.userName.ToString();
                return RedirectToAction("Employee", "AdminLogin");
            }
            else
            {
                ViewData["Message"] = "Invalid data"; 
            }
            con.Close();
            return View();
        }

        public ActionResult Employee()
        {
            return View();
        }
    }
}
