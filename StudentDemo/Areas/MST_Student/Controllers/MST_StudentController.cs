using Microsoft.AspNetCore.Mvc;
using System.Data;
using StudentDemo.Areas.LOC_City.Models;
using StudentDemo.Areas.MST_Branch.Models;
using StudentDemo.Areas.MST_Student.Models;
using StudentDemo.DAL;

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

        #region Index
        public IActionResult Index()
        {
            #region ComboBox

            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            MST_DAL dal = new MST_DAL();

            DataTable dt1 = dal.PR_Branch_SelectByComboBox(connstr);
            DataTable dt2 = dal.PR_City_SelectByComboBox(connstr);


            List<MST_Branch_DropDownModel> list = new List<MST_Branch_DropDownModel>();
            List<LOC_City_DropDownModel> list1 = new List<LOC_City_DropDownModel>();

            foreach (DataRow dr in dt1.Rows)
            {
                MST_Branch_DropDownModel vlst = new MST_Branch_DropDownModel();
                vlst.BranchID = Convert.ToInt32(dr["BranchID"]);
                vlst.BranchName = Convert.ToString(dr["BranchName"]);
                list.Add(vlst);
            }

            foreach (DataRow dr in dt2.Rows)
            {
                LOC_City_DropDownModel vlst1 = new LOC_City_DropDownModel();
                vlst1.CityID = Convert.ToInt32(dr["CityID"]);
                vlst1.CityName = Convert.ToString(dr["CityName"]);
                list1.Add(vlst1);
            }

            ViewBag.BranchList = list;
            ViewBag.CityList = list1;
            #endregion
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            DataTable dt = dal.PR_Student_SelectAll(str);
            var viewModel = new MST_Student_ViewModel
            {
                StudentDataTable = dt,
                SearchModel = new MST_Student_SearchModel()
            };
            
            return View("Index", viewModel);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int StudentID)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            MST_DAL dal = new MST_DAL();
            dal.PR_Student_DeleteByPK(str, StudentID);
            TempData["Success"] = ("Student Deleted Successfully");
            return RedirectToAction("Index");
        }
        #endregion

        #region Create
        public IActionResult Create(int? StudentID)
        {
            #region ComboBox

            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            MST_DAL dal = new MST_DAL();
            
            DataTable dt1 = dal.PR_Branch_SelectByComboBox(connstr);
            DataTable dt2 = dal.PR_City_SelectByComboBox(connstr) ;


            List<MST_Branch_DropDownModel> list = new List<MST_Branch_DropDownModel>();
            List<LOC_City_DropDownModel> list1 = new List<LOC_City_DropDownModel>();

            foreach (DataRow dr in dt1.Rows)
            {
                MST_Branch_DropDownModel vlst = new MST_Branch_DropDownModel();
                vlst.BranchID = Convert.ToInt32(dr["BranchID"]);
                vlst.BranchName = Convert.ToString(dr["BranchName"]);
                list.Add(vlst);
            }

            foreach (DataRow dr in dt2.Rows)
            {
                LOC_City_DropDownModel vlst1 = new LOC_City_DropDownModel();
                vlst1.CityID = Convert.ToInt32(dr["CityID"]);
                vlst1.CityName = Convert.ToString(dr["CityName"]);
                list1.Add(vlst1);
            }

            ViewBag.BranchList = list;
            ViewBag.CityList = list1;
            #endregion



            #region SelectByPK
            if (StudentID != null)
            {
                string str = this.Configuration.GetConnectionString("myConnectionStrings");
                DataTable dt = dal.PR_Student_SelectByPK(str, StudentID);
                MST_StudentModel modelMST_Student = new MST_StudentModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelMST_Student.StudentID = Convert.ToInt32(dr["StudentID"]);
                    modelMST_Student.StudentName = Convert.ToString(dr["StudentName"]);
                    modelMST_Student.BranchID = Convert.ToInt32(dr["BranchID"]);
                    modelMST_Student.CityID = Convert.ToInt32(dr["CityID"]);
                    modelMST_Student.MobileNoStudent = Convert.ToString(dr["MobileNoStudent"]);
                    modelMST_Student.MobileNoFather = Convert.ToString(dr["MobileNoFather"]);
                    modelMST_Student.Address = Convert.ToString(dr["Address"]);
                    modelMST_Student.Email = Convert.ToString(dr["Email"]);
                    modelMST_Student.Gender = Convert.ToString(dr["Gender"]);
                    modelMST_Student.IsActive = Convert.ToString(dr["IsActive"]);
                    modelMST_Student.age = Convert.ToInt32(dr["age"]);
                    modelMST_Student.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
                    modelMST_Student.PhotoPath = Convert.ToString(dr["PhotoPath"]);
                    modelMST_Student.Password = Convert.ToString(dr["Password"]);

                }
                return View("Create", modelMST_Student);
            }
            return View("Create");

            #endregion


        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(MST_StudentModel modelMST_Student)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            MST_DAL dal =new MST_DAL();
            if (modelMST_Student.File != null)
            {
                String FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileNameWithPath = Path.Combine(path, modelMST_Student.File.FileName);
                modelMST_Student.PhotoPath = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelMST_Student.File.FileName;
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelMST_Student.File.CopyTo(stream);
                }
            }
            if (modelMST_Student.StudentID == null)
            {
                dal.PR_Student_Insert
                (
                    str,
                    modelMST_Student.StudentName,
                    modelMST_Student.BranchID,
                    modelMST_Student.CityID,
                    modelMST_Student.MobileNoStudent,
                    modelMST_Student.MobileNoFather,
                    modelMST_Student.Address,
                    modelMST_Student.Email,
                    modelMST_Student.Gender,
                    modelMST_Student.IsActive,
                    modelMST_Student.age,
                    modelMST_Student.BirthDate,
                    modelMST_Student.PhotoPath,
                    modelMST_Student.Password
                );

            }
            else
            {
                dal.PR_Student_UpdateByPK
                (
                    str,
                    modelMST_Student.StudentID.Value,
                    modelMST_Student.StudentName,
                    modelMST_Student.BranchID,
                    modelMST_Student.CityID,
                    modelMST_Student.MobileNoStudent,
                    modelMST_Student.MobileNoFather,
                    modelMST_Student.Address,
                    modelMST_Student.Email,
                    modelMST_Student.Gender,
                    modelMST_Student.IsActive,
                    modelMST_Student.age,
                    modelMST_Student.BirthDate,
                    modelMST_Student.PhotoPath,
                    modelMST_Student.Password
                );

            }

            


            
            
                if (modelMST_Student.StudentID == null)
                {
                    TempData["Success"] = ("Student Added Successfully");

                }
                else
                {
                    TempData["Success"] = ("Student Updated Successfully");

                }

            
            
            

            return RedirectToAction("Index");
        }
        #endregion

        #region Search
        [HttpPost]
        public IActionResult Search(MST_Student_SearchModel searchModel)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            MST_DAL dal = new MST_DAL();
            DataTable dt = dal.PR_Student_SelectByPage(str, searchModel.BranchID, searchModel.CityID, searchModel.StudentName,searchModel.Gender,searchModel.IsActive,searchModel.Age);
            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            DataTable dt1 = dal.PR_Branch_SelectByComboBox(connstr);
            DataTable dt2 = dal.PR_City_SelectByComboBox(connstr);


            List<MST_Branch_DropDownModel> list = new List<MST_Branch_DropDownModel>();
            List<LOC_City_DropDownModel> list1 = new List<LOC_City_DropDownModel>();

            foreach (DataRow dr in dt1.Rows)
            {
                MST_Branch_DropDownModel vlst = new MST_Branch_DropDownModel();
                vlst.BranchID = Convert.ToInt32(dr["BranchID"]);
                vlst.BranchName = Convert.ToString(dr["BranchName"]);
                list.Add(vlst);
            }

            foreach (DataRow dr in dt2.Rows)
            {
                LOC_City_DropDownModel vlst1 = new LOC_City_DropDownModel();
                vlst1.CityID = Convert.ToInt32(dr["CityID"]);
                vlst1.CityName = Convert.ToString(dr["CityName"]);
                list1.Add(vlst1);
            }

            ViewBag.BranchList = list;
            ViewBag.CityList = list1;
            
            var viewModel = new MST_Student_ViewModel
            {
                StudentDataTable = dt,
                SearchModel = searchModel,
            };

            return View("Index", viewModel);
        }


        #endregion
    }
}
