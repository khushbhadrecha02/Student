using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

using StudentDemo.Areas.LOC_State.Models;
using StudentDemo.Areas.LOC_Country.Models;
using StudentDemo.DAL;

namespace StudentDemo.Areas.LOC_State.Controllers
{
    [Area("LOC_State")]
    [Route("LOC_State/{Controller}/{Action}")]
    public class LOC_StateController : Controller
    {
        #region Configuration
        private IConfiguration Configuration;
        public LOC_StateController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Index
        public IActionResult Index(int? CountryID)
        {
            #region ComboBox
            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal1 = new LOC_DAL();
            DataTable dt1 = dal1.PR_Country_SelectByComboBox(connstr);
            List<LOC_Country_DropDownModel> list = new List<LOC_Country_DropDownModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                LOC_Country_DropDownModel vlst = new LOC_Country_DropDownModel();
                vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst.CountryName = Convert.ToString(dr["CountryName"]);
                list.Add(vlst);

            }
            ViewBag.CountryList = list;

            #endregion
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal = new LOC_DAL();
            DataTable dt;
            LOC_State_SearchModel searchModel = new LOC_State_SearchModel();
            searchModel.CountryID = CountryID;
            if (CountryID != null)
            {
                dt = dal.PR_State_SelectByPage(str, searchModel.CountryID, null, null);

            }
            else
            {
                 dt = dal.PR_State_SelectAll(str);
            }
            var viewModel = new LOC_State_ViewModel
            {
                StateDataTable = dt,
                SearchModel = new LOC_State_SearchModel()
            };

            return View("Index", viewModel);



        }
        #endregion


        #region Delete
        public IActionResult Delete(int StateID)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal = new LOC_DAL();
            dal.PR_State_DeleteByPK(str,StateID);
            TempData["Success"] = ("State Deleted Successfully");
            return RedirectToAction("Index");
        }
        #endregion

        #region Create
        public IActionResult Create(int? StateID)
        {
            #region ComboBox
            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal = new LOC_DAL();
            DataTable dt1 = dal.PR_Country_SelectByComboBox(connstr);
            List<LOC_Country_DropDownModel> list = new List<LOC_Country_DropDownModel>();
            foreach(DataRow dr in dt1.Rows)
            {
                LOC_Country_DropDownModel vlst = new LOC_Country_DropDownModel();
                vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst.CountryName = Convert.ToString(dr["CountryName"]);
                list.Add(vlst);

            }
            ViewBag.CountryList = list;

            #endregion

            #region SelectBYPK
            if (StateID != null)
            {
                string str = this.Configuration.GetConnectionString("myConnectionStrings");

               DataTable dt = dal.PR_State_SelectByPK(str,StateID);
                
                LOC_StateModel modelLOC_State = new LOC_StateModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelLOC_State.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_State.StateName = Convert.ToString(dr["StateName"]);
                    modelLOC_State.StateCode = Convert.ToString(dr["StateCode"]);
                    modelLOC_State.StateID = Convert.ToInt32(dr["StateID"]);
                }
                return View("Create", modelLOC_State);
            }
            return View("Create");
            #endregion
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(LOC_StateModel modelLOC_State)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal = new LOC_DAL();

            if (modelLOC_State.StateID == null)
            {
                dal.PR_State_Insert(str,modelLOC_State.CountryID,modelLOC_State.StateName,modelLOC_State.StateCode);

            }
            else
            {
                dal.PR_State_UpdateByPK(str,modelLOC_State.StateID.Value,modelLOC_State.CountryID, modelLOC_State.StateName, modelLOC_State.StateCode);

            }
            
            
                if (modelLOC_State.StateID == null)
                {
                    TempData["Success"] = ("State Added Successfully");

                }
                else
                {
                    TempData["Success"] = ("State Updated Successfully");

                }

            


            return RedirectToAction("Index");
        }
        #endregion
        #region Search
        [HttpPost]
        public IActionResult Search(LOC_State_SearchModel searchModel)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal = new LOC_DAL();
            DataTable dt = dal.PR_State_SelectByPage(str,searchModel.CountryID, searchModel.StateName, searchModel.StateCode);
            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal1 = new LOC_DAL();
            DataTable dt1 = dal1.PR_Country_SelectByComboBox(connstr);
            List<LOC_Country_DropDownModel> list = new List<LOC_Country_DropDownModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                LOC_Country_DropDownModel vlst = new LOC_Country_DropDownModel();
                vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst.CountryName = Convert.ToString(dr["CountryName"]);
                list.Add(vlst);
            }
            ViewBag.CountryList = list;

            var viewModel = new LOC_State_ViewModel
            {
                StateDataTable = dt,
                SearchModel = searchModel,
            };

            return View("Index", viewModel);
        }


        #endregion

    }
}
