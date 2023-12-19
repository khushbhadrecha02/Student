using Microsoft.AspNetCore.Mvc;
using StudentDemo.Areas.Login.Models;
using StudentDemo.DAL;
using System.Data;
using Microsoft.AspNetCore.Http;


namespace StudentDemo.Areas.Login.Controllers
{
    [Area("Login")]
    [Route("Login/{Controller}/{Action}")]
    public class LoginController : Controller
    {
        #region Configuration
        private IConfiguration Configuration;
        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Index","Home");
            }
            return View();  
        }
        [HttpPost]
        public IActionResult Login(LoginModel modelLogin)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            MST_DAL dal  = new MST_DAL();
            DataTable dt = dal.PR_Login_SelectByEmailAndpassword(str,modelLogin.Email, modelLogin.Password);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HttpContext.Session.SetString("UserSession", Convert.ToString(dr["UserName"]));
                    HttpContext.Session.SetString("Role", Convert.ToString(dr["Role"]));
                    HttpContext.Session.SetString("Photo",Convert.ToString(dr["PhotoPath"]));


                }


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Login Fail....";
                return RedirectToAction("Login");
            }

            
        }
        public IActionResult LogOut()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Register(LoginModel loginModel)
        {
            string str = this.Configuration.GetConnectionString("myConnectionStrings");
            MST_DAL dal = new MST_DAL();
            if (loginModel.File != null)
            {
                String FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileNameWithPath = Path.Combine(path, loginModel.File.FileName);
                loginModel.PhotoPath = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + loginModel.File.FileName;
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    loginModel.File.CopyTo(stream);
                }
            }
            dal.PR_Login_Insert
               (
                   str,
                   loginModel.UserName,
                   loginModel.Email,
                   loginModel.Role,
                   loginModel.PhotoPath,
                   loginModel.Password
                   
               );

            return RedirectToAction("Login");
        }
    }
}
