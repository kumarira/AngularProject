using BusinessLogic.Profile;
using BusinessLogic.Tweets;
using CommonModel;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        ProfileBL objProfile = new ProfileBL();
        TweetsBL objTweet = new TweetsBL();
        // GET: Home
        public ActionResult Index()
        {
          
            var userid = Session["UserID"].ToString();  
            ViewBag.followerCount = objProfile.GetFollowerCountBL(userid);
            ViewBag.followingCount = objProfile.GetFollowingCountBL(userid);
            ViewBag.tweetsCount = objProfile.GetTweetsCountBL(userid);
            var viewIndexed = objTweet.GetIndexedViewTweetsBL(userid);
            return View(viewIndexed);
        }

        public ActionResult Followers()
        {
            return View();
        }

        public ActionResult Following()
        {
            return View();
        } 

        [HttpPost] 
        public ActionResult tweets(IndexViewtweet model)
        {
            var userid = Session["UserID"].ToString();
             tweets obj = new CommonModel.tweets();
            obj.message = model.Details.message;
            obj.tweet_Id = model.Details.tweet_Id;
             var co = objTweet.AddUpdateTweetBL(obj, userid,"A");
            return RedirectToAction("Index");
        }
       

        [HttpPost] 
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                TempData["LogoutMessage"] = "You are now successful loged out.";
                FormsAuthentication.SignOut();
            }
            return RedirectToAction("Login", "Login");  
        }
    }
}