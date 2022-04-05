using SelfLearnSignUp.Models;
using SelfLearnSignUp.CommonHelper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelfLearnSignUp.Controllers
{
    public class HomeController : Controller
    {

        DbUserMasterConnect DUMC = new DbUserMasterConnect();
        // GET: Home
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult UserRecords()
        {
            return View();
        }
        public ActionResult Charts()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllUserData(string orderby, string whereclause)
        {
            List<UserAccount> UList = new List<UserAccount>();
            UList = DUMC.GetUserData(orderby, whereclause);
            return Json(new { data = UList }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CreateNewAccount(int Id, string FirstName, string LastName, string ContactNo, string EmailId, string Password, char Gender)
        {
            int flag = 0;
            UserAccount U = new UserAccount();
            {
                U.Id = Id;
                U.FirstName = FirstName;
                U.LastName = LastName;
                U.ContactNo = ContactNo;
                U.EmailId = EmailId;
                U.Gender = Gender;
                U.Password = Password;
                U.Status = 'Y';
            };

            flag = DUMC.InsertUserData(U);

            if (flag == 1)
            {
                var result = new { Success = "Success", Message = "Data Inserted Successfully..!!" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = "False", Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateUserStatus(int Id, char Status)
        {
            int flag = 0;
            UserAccount U = new UserAccount();
            {
                U.Id = Id;
                U.Status = Status;
            };

            flag = DUMC.UpdateUserStatus(U);
            if (flag == 1)
            {
                var result = new { Success = "Success", Message = "Status Updated Successfully..!!" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = "False", Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ChartCall(string SelectAsLabel, string GroupBy)
        {
            List<UserChartResponseModel> ULst = new List<UserChartResponseModel>();
            ULst = DUMC.GetUserChartData(SelectAsLabel, GroupBy);
            return Json(new { data = ULst }, JsonRequestBehavior.AllowGet);
        }

    }
}