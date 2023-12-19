using Microsoft.AspNetCore.Mvc;
using StudentDemo.Areas.LOC_Country.Models;
using StudentDemo.DAL;
using System.Data;


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
            LOC_DAL dal = new LOC_DAL();
            DataTable dt = dal.PR_Country_SelectAll(str);

            var viewModel = new LOC_Country_ViewModel
            {
                CountryDataTable = dt,
                SearchModel = new LOC_Country_SearchModel() // You can initialize properties if needed
            };

            return View("Index",viewModel);
        }

        #endregion

        #region Delete
        public IActionResult Delete(int CountryID)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal = new LOC_DAL();
            dal.PR_Country_DeleteByPK(str,CountryID);
            TempData["Success"] = ("Country Deleted Successfully");
            return RedirectToAction("Index");
        }
        #endregion

        #region Create
        public IActionResult Create(int? CountryID)
        {
            if(CountryID != null)
            {
                string str = this.Configuration.GetConnectionString("myConnectionStrings");
                LOC_DAL dal = new LOC_DAL();
                DataTable dt= dal.PR_Country_SelectByPK(str,CountryID);
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

            LOC_DAL dal = new LOC_DAL();
            
            if (modelLOC_Country.CountryID == null)
            {
                dal.PR_Country_Insert(str,modelLOC_Country.CountryName,modelLOC_Country.CountryCode);

            }
            else
            {
                dal.PR_Country_UpdateByPK(str, modelLOC_Country.CountryID.Value,modelLOC_Country.CountryName,modelLOC_Country.CountryCode);

            }

            if (modelLOC_Country.CountryID == null)
                {
                    TempData["Success"] = ("Country Added Successfully");

                }
            else
                {
                    TempData["Success"] = ("Country Updated Successfully");

                }

            
            
            
            return RedirectToAction("Index");
        }
        #endregion

        #region Search
        [HttpPost]
        public IActionResult Search(LOC_Country_SearchModel searchModel)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal = new LOC_DAL();
            DataTable dt = dal.PR_Country_SelectByPage(str,searchModel.CountryName,searchModel.CountryCode);

            var viewModel = new LOC_Country_ViewModel
            {
                CountryDataTable = dt,
                SearchModel = searchModel
            };

            return View("Index", viewModel);
        }


        #endregion

    }
}
    