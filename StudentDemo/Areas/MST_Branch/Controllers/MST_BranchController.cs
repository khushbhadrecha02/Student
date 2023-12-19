using Microsoft.AspNetCore.Mvc;

using System.Data;

using StudentDemo.Areas.MST_Branch.Models;
using StudentDemo.DAL;


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

        #region Index
        public IActionResult Index()
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            MST_DAL dal = new MST_DAL();
            DataTable dt = dal.PR_Branch_SelectAll(str);
            var viewModel = new MST_Branch_ViewModel
            {
                BranchDataTable = dt,
                SearchModel = new MST_Branch_SearchModel() // You can initialize properties if needed
            };
            return View("Index", viewModel);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int BranchID)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            MST_DAL dal = new MST_DAL();
            dal.PR_Branch_DeleteByPK(str, BranchID);
            TempData["Success"] = ("Branch Deleted Successfully");
            return RedirectToAction("Index");
        }
        #endregion

        #region Create
        public IActionResult Create(int? BranchID)
        {
            if (BranchID != null)
            {
                string str = this.Configuration.GetConnectionString("myConnectionStrings");
                MST_DAL dal = new MST_DAL();
                DataTable dt = dal.PR_Branch_SelectByPK(str, BranchID);
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
        #endregion

        #region Save


        [HttpPost]
        public IActionResult Save(MST_BranchModel modelMST_Branch)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            MST_DAL dal = new MST_DAL();
           
            if (modelMST_Branch.BranchID == null)
            {
                dal.PR_Branch_Insert(str,modelMST_Branch.BranchName,modelMST_Branch.BranchCode);

            }
            else
            {
                dal.PR_Country_UpdateByPK(str, modelMST_Branch.BranchID.Value, modelMST_Branch.BranchName, modelMST_Branch.BranchCode);

            }
            

                if (modelMST_Branch.BranchID == null)
                {
                    TempData["Success"] = ("Branch Added Successfully");

                }
                else
                {
                    TempData["Success"] = ("Branch Updated Successfully");

                }

            
            

            return RedirectToAction("Index");
        }
        #endregion

        #region Search
        [HttpPost]
        public IActionResult Search(MST_Branch_SearchModel searchModel)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            MST_DAL dal = new MST_DAL();
            DataTable dt = dal.PR_Branch_SelectByPage(str, searchModel.BranchName, searchModel.BranchCode);

            var viewModel = new MST_Branch_ViewModel
            {
                BranchDataTable = dt,
                SearchModel = searchModel
            };

            return View("Index", viewModel);
        }


        #endregion
    }
}
