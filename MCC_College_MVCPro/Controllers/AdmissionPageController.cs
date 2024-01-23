using MCC_College_MVCPro.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCC_College_MVCPro.Controllers
{
    public class AdmissionPageController : Controller
    {
        string ConString = ConfigurationManager.ConnectionStrings["MVCConnection"].ConnectionString;
        // GET: AdmissionPage
        public ActionResult Index()
        {
            List<AdmissionPage> admissionPageList = new List<AdmissionPage>();
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_fetchadmissionDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                admissionPageList.Add(new AdmissionPage
                {
                    id = Convert.ToInt32(dr["id"]),
                    Name = Convert.ToString(dr["Name"]),
                    FatherName = Convert.ToString(dr["FatherName"]),
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    JoiningDepartment = Convert.ToString(dr["JoiningDepartment"])
                });
            }

            con.Close();
            return View(admissionPageList);
        }

        // GET: AdmissionPage/Details/5
        public ActionResult Details(int id, AdmissionPage admission)
        {
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string query = "sp_get_admissionDetails " + admission.id;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                admission = new AdmissionPage
                {
                    id = Convert.ToInt32(dr["id"]),
                    Name = Convert.ToString(dr["Name"]),
                    FatherName = Convert.ToString(dr["FatherName"]),
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    JoiningDepartment = Convert.ToString(dr["JoiningDepartment"])
                };
            }
            return View(admission);
        }

        // GET: AdmissionPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmissionPage/Create
        [HttpPost]
        public ActionResult Create(AdmissionPage admission)
        {
            try
            {
               SqlConnection con = new SqlConnection(ConString);
                con.Open();
                string query = "sp_insertAdmission '" + admission.Name
                    + "','" + admission.FatherName
                    + "','" + admission.DateOfBirth
                    + "','" + admission.Gender
                    + "','" + admission.JoiningDepartment + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.ExecuteNonQuery();

                con.Close();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdmissionPage/Edit/5
        public ActionResult Edit(int id, AdmissionPage admission)
        {
            
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string query = "sp_get_admissionDetails " + admission.id;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                admission =  new AdmissionPage
                {
                    id = Convert.ToInt32(dr["id"]),
                    Name = Convert.ToString(dr["Name"]),
                    FatherName = Convert.ToString(dr["FatherName"]),
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    JoiningDepartment = Convert.ToString(dr["JoiningDepartment"])
                };
            }
            return View(admission);
        }

        // POST: AdmissionPage/Edit/5
        [HttpPost]
        public ActionResult Edit(AdmissionPage admission)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConString);
                con.Open();
                string query = "sp_edit_admissionDetails " + admission.id + ",'" + admission.Name
                    + "','" + admission.FatherName
                    + "','" + admission.DateOfBirth
                    + "','" + admission.Gender
                    + "','" + admission.JoiningDepartment + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdmissionPage/Delete/5
        public ActionResult Delete(int id, AdmissionPage admission)
        {
            
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string query = "sp_get_admissionDetails " + admission.id;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                admission = new AdmissionPage
                {
                    id = Convert.ToInt32(dr["id"]),
                    Name = Convert.ToString(dr["Name"]),
                    FatherName = Convert.ToString(dr["FatherName"]),
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    JoiningDepartment = Convert.ToString(dr["JoiningDepartment"])
                };
            }
            return View(admission);
        }

        // POST: AdmissionPage/Delete/5
        [HttpPost]
        public ActionResult Delete( AdmissionPage admission)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConString);
                con.Open();
                string query = "sp_delete_admissionDetails " + admission.id ;
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
