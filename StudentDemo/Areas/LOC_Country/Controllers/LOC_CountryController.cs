using Microsoft.AspNetCore.Mvc;
using StudentDemo.Areas.LOC_Country.Models;
using System.Data;
using System.Data.SqlClient;

namespace StudentDemo.Areas.LOC_Country.Controllers
{
    [Area("LOC_Country")]
    [Route("LOC_Country/{Controller}/{Action}")]
    public class LOC_CountryController : Controller
    {
        #region Configuration
        private IConfiguration Configuration;
        public LOC_CountryController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Country_SelectAll";
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            return View("Index", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CountryID)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.CommandText = "PR_Country_DeleteByPK";
            cmd.Parameters.Add("@CountryID",SqlDbType.Int).Value = CountryID;
                cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Index");
        }
        #endregion

        #region Create
        public IActionResult Create(int? CountryID)
        {
            if(CountryID != null)
            {
                string str = this.Configuration.GetConnectionString("myConnectionStrings");
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_Country_SelectByPK";
                cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;
                DataTable dt = new DataTable();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                conn.Close();
                LOC_CountryModel modelLOC_Country = new LOC_CountryModel();
                foreach (DataRow dr in dt.Rows)
                {
                    
                    modelLOC_Country.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_Country.CountryName = Convert.ToString(dr["CountryName"]);
                    modelLOC_Country.CountryCode = Convert.ToString(dr["CountryCode"]);
                }
                return View("Create", modelLOC_Country);




            }
            
            
                return View("Create");
            
            
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(LOC_CountryModel modelLOC_Country)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if (modelLOC_Country.CountryID == null)
            {
                cmd.CommandText = "PR_Country_Insert";

            }
            else
            {
                cmd.CommandText = "PR_Country_UpdateByPK";
                cmd.Parameters.Add("@CountryID",SqlDbType.Int).Value=modelLOC_Country.CountryID;

            }
            cmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = modelLOC_Country.CountryName;
            cmd.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = modelLOC_Country.CountryCode;
            if (Convert.ToBoolean(cmd.ExecuteNonQuery()))
            {
                if (modelLOC_Country.CountryID == null)
                {
                    TempData["Success"] = ("Country Added Successfully");

                }
                else
                {
                    TempData["Success"] = ("Country Updated Successfully");

                }

            }
            conn.Close();
            
            return RedirectToAction("Index");
        }
        #endregion
        #region Save
        //[HttpPost]
        public IActionResult Search(string CountryName, string CountryCode)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Country_SelectByPage";
            cmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = string.IsNullOrEmpty(CountryName) ? DBNull.Value : (object)CountryName;
            cmd.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = string.IsNullOrEmpty(CountryCode) ? DBNull.Value : (object)CountryCode;

            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();


            return View("Index", dt);
            //return RedirectToAction("Index");
        }

        #endregion

    }
}
    