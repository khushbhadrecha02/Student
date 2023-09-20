using Microsoft.AspNetCore.Mvc;
using StudentDemo.Areas.SEC_User.Models;

namespace StudentDemo.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/{Controller}/{Action}")]
    public class SEC_User : Controller
    {
        #region Configuration
        private IConfiguration Configuration;
        public SEC_User(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(SEC_UserModel modelSec_User)
        {
            string connstr = this.Configuration.GetConnectionString("myConnectionStrings");
            string error = null;
            if(modelSec_User.UserName == null)
            {
                error += "User Name is required";
            }
            if (modelSec_User.Password == null)
            {
                error += "</br>Password is required";
            }
            if(error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("Index");
            }

        }
        public IActionResult LOgout() 
        {

        }

    }
}
