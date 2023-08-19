using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using StudentDemo.Areas.LOC_Country.Models;
using StudentDemo.Areas.MST_Branch.Models;

namespace StudentDemo.Areas.MST_Branch.Controllers
{
    [Area("MST_Branch")]
    [Route("MST_Branch/{Controller}/{Action}")]
    public class MST_BranchController : Controller
    {
        #region Configuration
        private IConfiguration Configuration;
        public MST_BranchController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion
        #region SelectAll
        public IActionResult Index()
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Branch_SelectAll";
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            return View("Index", dt);
        }
        #endregion
        #region Delete
        public IActionResult Delete(int BranchID)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Branch_DeleteByPK";
            cmd.Parameters.Add("@BranchID", SqlDbType.Int).Value = BranchID;
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Index");
        }
        #endregion
        #region InsertEdit
        public IActionResult Create(int? BranchID)
        {
            if (BranchID != null)
            {
                string str = this.Configuration.GetConnectionString("myConnectionStrings");
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_Branch_SelectByPK";
                cmd.Parameters.Add("@BranchID", SqlDbType.Int).Value = BranchID;
                DataTable dt = new DataTable();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                conn.Close();
                MST_BranchModel modelMST_Branch = new MST_BranchModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelMST_Branch.BranchID = Convert.ToInt32(dr["BranchID"]);
                    modelMST_Branch.BranchName = Convert.ToString(dr["BranchName"]);
                    modelMST_Branch.BranchCode = Convert.ToString(dr["BranchCode"]);
                }
                return View("Create", modelMST_Branch);




            }


            return View("Create");


        }


        [HttpPost]
        public IActionResult Save(MST_BranchModel modelMST_Branch)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if (modelMST_Branch.BranchID == null)
            {
                cmd.CommandText = "PR_Branch_Insert";

            }
            else
            {
                cmd.CommandText = "PR_Branch_UpdateByPK";
                cmd.Parameters.Add("@BranchID", SqlDbType.Int).Value = modelMST_Branch.BranchID;

            }
            cmd.Parameters.Add("@BranchName", SqlDbType.VarChar).Value = modelMST_Branch.BranchName;
            cmd.Parameters.Add("@BranchCode", SqlDbType.VarChar).Value = modelMST_Branch.BranchCode;
            if (Convert.ToBoolean(cmd.ExecuteNonQuery()))
            {
                if (modelMST_Branch.BranchID == null)
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
    }
}
