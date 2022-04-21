
using Microsoft.AspNetCore.Mvc;
using MVC.CommonHelper;
using MVC.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        DbUserConnectMaster DUMC = new DbUserConnectMaster();
        public IActionResult SignUp()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewAccount(UserAccount userAccount)
        {
            int flag = 0;

            UserAccount U = new UserAccount();
            {
                U.Id = userAccount.Id;
                U.FirstName = userAccount.FirstName;
                U.LastName = userAccount.LastName;
                U.ContactNo = userAccount.ContactNo;
                U.EmailId = userAccount.EmailId;
                U.Gender = userAccount.Gender;
                U.Password = userAccount.Password;
                U.Status = 'Y';
            };

            flag = DUMC.InsertUserData(U);

            if (flag == 1)
            {
                var result = new { Success = "Success", Message = "Data Inserted Successfully..!!" };
                return this.Ok("Form Data Received");
            }
            else
            {
                var result = new { Success = "False", Message = "Error Message" };
                return this.BadRequest("Bad Request");
            }
        }
    }
}
