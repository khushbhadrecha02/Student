using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using StudentDemo.Areas.LOC_City.Models;
using StudentDemo.Areas.LOC_Country.Models;
using StudentDemo.Areas.LOC_State.Models;
using StudentDemo.DAL;

namespace StudentDemo.Areas.LOC_City.Controllers
{
    [Area("LOC_City")]
    [Route("LOC_City/{Controller}/{Action}")]
    public class LOC_CityController : Controller
    {
        #region Configuration
        private IConfiguration Configuration;
        public LOC_CityController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Index
        public IActionResult Index(int? CountryID)
        {
            LOC_DAL dal = new LOC_DAL();
            #region ComboBox
            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            DataTable dt1 = dal.PR_Country_SelectByComboBox(connstr);


            List<LOC_Country_DropDownModel> list = new List<LOC_Country_DropDownModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                LOC_Country_DropDownModel vlst = new LOC_Country_DropDownModel();
                vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst.CountryName = Convert.ToString(dr["CountryName"]);
                list.Add(vlst);
            }
            ViewBag.CountryList = list;
            List<LOC_State_DropDownModel> list1 = new List<LOC_State_DropDownModel>();
            ViewBag.StateList = list1;

            #endregion
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            DataTable dt;
            LOC_City_SearchModel searchModel = new LOC_City_SearchModel();
            searchModel.CountryID = CountryID;

            if (CountryID != null)
            {
                dt = dal.PR_City_SelectByPage(str, searchModel.CountryID,null,null,null);

            }
            else
            {
                dt = dal.PR_City_SelectAll(str);
            }
            var viewModel = new LOC_City_ViewModel
            {
                CityDataTable = dt,
                SearchModel = new LOC_City_SearchModel()
            };
            return View("Index", viewModel);
        }
        #endregion
        #region Index1
        public IActionResult Index1(int? StateID)
        {
            LOC_DAL dal = new LOC_DAL();
            #region ComboBox
            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            DataTable dt1 = dal.PR_Country_SelectByComboBox(connstr);


            List<LOC_Country_DropDownModel> list = new List<LOC_Country_DropDownModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                LOC_Country_DropDownModel vlst = new LOC_Country_DropDownModel();
                vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst.CountryName = Convert.ToString(dr["CountryName"]);
                list.Add(vlst);
            }
            ViewBag.CountryList = list;
            List<LOC_State_DropDownModel> list1 = new List<LOC_State_DropDownModel>();
            ViewBag.StateList = list1;

            #endregion
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            DataTable dt;
            LOC_City_SearchModel searchModel = new LOC_City_SearchModel();
            searchModel.StateID = StateID;
            if (StateID != null)

            {
                dt = dal.PR_City_SelectByPage(str, null, searchModel.StateID, null, null);

            }
            else
            {
                dt = dal.PR_City_SelectAll(str);
            }
            var viewModel = new LOC_City_ViewModel
            {
                CityDataTable = dt,
                SearchModel = new LOC_City_SearchModel()
            };
            return View("Index", viewModel);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CityID)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dAL = new LOC_DAL();
            dAL.PR_City_DeleteByPK(str, CityID);
            TempData["Success"] = ("City Deleted Successfully");
            return RedirectToAction("Index");
        }
        #endregion

        #region Create
        public IActionResult Create(int? CityID)
        {
            LOC_DAL dal = new LOC_DAL();
            #region ComboBox
            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            DataTable dt1 = dal.PR_Country_SelectByComboBox(connstr);
            
            
            List<LOC_Country_DropDownModel> list = new List<LOC_Country_DropDownModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                LOC_Country_DropDownModel vlst = new LOC_Country_DropDownModel();
                vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst.CountryName = Convert.ToString(dr["CountryName"]);
                list.Add(vlst);
            }
            ViewBag.CountryList = list;
            List<LOC_State_DropDownModel> list1 = new List<LOC_State_DropDownModel>();
            ViewBag.StateList = list1;

            #endregion

            #region SelectByPK
            if (CityID != null)
            {
                string str = this.Configuration.GetConnectionString("myConnectionStrings");
                DataTable dt = dal.PR_City_SelectByPK(str, CityID);
                LOC_CityModel modelLOC_City = new LOC_CityModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelLOC_City.CityID = Convert.ToInt32(dr["CityID"]);
                    modelLOC_City.CityName = Convert.ToString(dr["CityName"]);
                    modelLOC_City.CityCode = Convert.ToString(dr["CityCode"]);
                    modelLOC_City.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_City.StateID = Convert.ToInt32(dr["StateID"]);
                }
                return View("Create", modelLOC_City);
            }
            return View("Create");

            #endregion
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(LOC_CityModel modelLOC_City)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal = new LOC_DAL();
            if (modelLOC_City.CityID == null)
            {
                dal.PR_City_Insert
                (
                    str,
                    modelLOC_City.CountryID,
                    modelLOC_City.StateID,
                    modelLOC_City.CityName,
                    modelLOC_City.CityCode
                 );

            }
            else
            {
                dal.PR_City_UpdateByPK
                (
                    str,
                    modelLOC_City.CityID.Value,
                    modelLOC_City.StateID,
                    modelLOC_City.CountryID,
                    modelLOC_City.CityName,
                    modelLOC_City.CityCode
                 );

            }

            {
                if (modelLOC_City.CityID == null)
                {
                    TempData["Success"] = ("City Added Successfully");

                }
                else
                {
                    TempData["Success"] = ("City Updated Successfully");

                }



                return RedirectToAction("Index");
            }
        }
        #endregion

        #region DropdownByCountry
        [HttpPost]
        public IActionResult DropdownByCountry(int CountryID)
        {

            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal = new LOC_DAL();
            DataTable dt = dal.PR_State_SelectByComboBox(connstr, CountryID);
            List<LOC_State_DropDownModel> list = new  List<LOC_State_DropDownModel>();
            foreach(DataRow dr in dt.Rows)
            {
                LOC_State_DropDownModel vlst = new LOC_State_DropDownModel();
                vlst.StateID = Convert.ToInt32(dr["StateID"]);
                vlst.StateName = Convert.ToString(dr["StateName"]);
                list.Add(vlst);
            }
            var vModel = list;
            return Json(vModel);

        }
        #endregion
        #region Search
        [HttpPost]
        public IActionResult Search(LOC_City_SearchModel searchModel)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            LOC_DAL dal = new LOC_DAL();
            DataTable dt = dal.PR_City_SelectByPage(str, searchModel.CountryID, searchModel.StateID,searchModel.CityName, searchModel.CityCode);
            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            
            DataTable dt1 = dal.PR_Country_SelectByComboBox(connstr);


            List<LOC_Country_DropDownModel> list = new List<LOC_Country_DropDownModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                LOC_Country_DropDownModel vlst = new LOC_Country_DropDownModel();
                vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst.CountryName = Convert.ToString(dr["CountryName"]);
                list.Add(vlst);
            }
            ViewBag.CountryList = list;
            List<LOC_State_DropDownModel> list1 = new List<LOC_State_DropDownModel>();
            ViewBag.StateList = list1;

            var viewModel = new LOC_City_ViewModel
            {
                CityDataTable = dt,
                SearchModel = searchModel,
            };

            return View("Index", viewModel);
        }


        #endregion
    }
}
