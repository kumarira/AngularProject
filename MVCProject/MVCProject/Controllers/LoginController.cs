using BusinessLogic.Login;
using CommonModel;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProject.Controllers
{
    public class LoginController : Controller
    {
        LoginBL objLogin = new LoginBL();
       
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }
        //
        // GET: /Account/Register
        [AllowAnonymous]       
        public ActionResult SignUp()
        {
            return View();
        } 
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Person model)
        { 
            var cnt= objLogin.SignUpBL(model); 
                return View("Login");
        }

        public ActionResult Login()
        {
            return View();
        }
       
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public  ActionResult Login(Person model)
        { 
            var result = objLogin.ValidateLoginBL(model);

            if (result == "SUCCESS")
            {
                FormsAuthentication.SetAuthCookie(model.UserId, false);
                Session["UserID"] = model.UserId;
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            } 
           
        }

    }
}