using DOTNETCoreMVC_ADODOTNET.Models;
using Microsoft.AspNetCore.Mvc;
using SolrNet.Utils;

namespace DOTNETCoreMVC_ADODOTNET.Controllers
{
    public class StudentController : Controller
    {
        StudentDataAccessLayer x = new StudentDataAccessLayer();
        public IActionResult Index()
        {
            List<Student> c = new List<Student>();
            c = x.GetAllCustomers().ToList();
            return View(c);
        }

        [HttpGet]
        public IActionResult Create_Student()
        {
            return View();
        }

        

        [HttpGet]
        public IActionResult Edit_student(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student customer = x.GetCustomerData(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create_Student([Bind] Student student)
        {
            if (ModelState.IsValid)
            {
                x.AddCustomer(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit_student(int id, [Bind] Student cust)
        {
            if (id != cust.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                x.UpdateCustomer(cust);
                return RedirectToAction("Index");
            }
            return View(x);
        }
        [HttpGet]
        public IActionResult student_Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student student = x.GetCustomerData(id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Delete_student(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student student = x.GetCustomerData(id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete_student")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            x.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
    
}
