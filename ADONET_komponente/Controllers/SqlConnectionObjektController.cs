using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADONET_komponente.Controllers
{
    public class SqlConnectionObjektController : Controller
    {
        // GET: SqlConnectionObjekt
        public ActionResult Index()
        {
            //prvo moramo sastaviti connection string
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True;
                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //zatim instanciramo SqlConnection objekt
            SqlConnection conn = new SqlConnection(connString);

            // otvaramo vezu s bazom

            try
            {
                conn.Open();
                // ako je veza otvorena uspjeli smo se spojiti

                if (conn.State == ConnectionState.Open)
                {
                    Response.Write("Konekcija uspjela!");
                }
                
            }
            catch (SqlException sqlEx)
            {
                //u slučaju da konekcija nije uspjela, ispisujemo poruku o greški
                Response.Write("Konekcija nije uspjela " + sqlEx.Message);
            }
            finally
            {
                //kad obavimo sve operacije u bazi konekciju je potrebno zatvoriti
                conn.Close();
            }


            return View();
        }
    }
}