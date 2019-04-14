using _821_Citanje_Iz_Baze.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _821_Citanje_Iz_Baze.Controllers
{
    public class ADONETKomponenteController : Controller
    {
        public static string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True;
                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // GET: ADONETKomponente
        public ActionResult List()
        {

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cm = new SqlCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM tblPolaznici";

            SqlDataReader dr = null;
            List<PolaznikModel> lstPolaznici = new List<PolaznikModel>();

            try
            {
                conn.Open();
                dr = cm.ExecuteReader();

                if(dr != null)
                {
                    if(dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            PolaznikModel polaznik = new PolaznikModel();
                            polaznik.id = int.Parse(dr["id"].ToString());
                            polaznik.Ime = dr["Ime"].ToString();
                            polaznik.Prezime = dr["Prezime"].ToString();
                            polaznik.Email = dr["Email"].ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa polaznika! Opis: " + ex.Message;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cm.Dispose();
            }

            return View(lstPolaznici);
        }


       
       ////////////////////////////////////////////////////////
      
        [HttpGet]
        public ActionResult Details(int id)
        {
            SqlConnection conn = new SqlConnection(connStr);

            string cmdText = "SELECT *FROM tblPolaznici WHERE id = @id";

            SqlCommand cmd = new SqlCommand(cmdText, conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.DbType = DbType.Int32;
            param.Direction = ParameterDirection.Input;
            param.Value = id;
            cmd.Parameters.Add(param);

            SqlDataReader dr = null;
            PolaznikModel polaznik = new PolaznikModel();

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read()) 
                        {                            
                            polaznik.id = int.Parse(dr["id"].ToString());
                            polaznik.Ime = dr["Ime"].ToString();
                            polaznik.Prezime = dr["Prezime"].ToString();
                            polaznik.Email = dr["Email"].ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa polaznika! Opis: " + ex.Message;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }


            return View(polaznik);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PolaznikModel());
        }

        [HttpPost]
        public ActionResult Create(PolaznikModel model)
        {
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True;
                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string cmdText = "";
                    cmdText += "INSERT INTO tblPolaznici";
                    cmdText += "(Ime, Prezime, Email) ";
                    cmdText += "VALUES";
                    cmdText += "('" + model.Ime + "', '" + model.Prezime + "', '" + model.Email + "') ";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Connection.Open();

                    int brojDodnihRedaka = cmd.ExecuteNonQuery();
                    ViewBag.Message = "Broj dodanih redaka: " + brojDodnihRedaka;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa polaznika! Opis: " + ex.Message;
            }

            return View(model);

        }
    }
}