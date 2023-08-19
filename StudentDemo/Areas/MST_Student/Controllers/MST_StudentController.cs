using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace StudentDemo.Areas.MST_Student.Controllers
{
    [Area("MST_Student")]
    [Route("MST_Student/{Controller}/{Action}")]
    public class MST_StudentController : Controller
    {
        #region Configuration
        private IConfiguration Configuration;
        public MST_StudentController(IConfiguration configuration)
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
            cmd.CommandText = "PR_Student_SelectAll";
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            return View("Index", dt);
        }
        #endregion
        #region Delete
        public IActionResult Delete(int StudentID)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Student_DeleteByPK";
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = StudentID;
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
