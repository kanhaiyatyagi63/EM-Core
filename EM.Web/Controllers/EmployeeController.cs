using EM.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EM.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<EmployeeModel> _employeeList;
        public static int IdIncrement = 1;

        public EmployeeController()
        {
            if (_employeeList == null)
                _employeeList = new List<EmployeeModel>() {
                new EmployeeModel(){
                Id = 1,
                Name = "Kanhaiya",
                DateOfBirth = DateTime.Now,
                },
                new EmployeeModel(){
                Id = 2,
                Name = "Raghav",
                DateOfBirth = DateTime.Now,
                },
                new EmployeeModel(){
                Id = 3,
                Name = "Yash",
                DateOfBirth = DateTime.Now,
                }
                };
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_employeeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {
            employee.Id = IdIncrement;
            _employeeList.Add(employee);
            IdIncrement++;
            TempData["message"] = "Employee created successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id <= 0)
                return NotFound();
            var employee = _employeeList.Where(x => x.Id == id)
                                         .FirstOrDefault();
            if (employee == null)
                return NotFound();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(EmployeeModel model)
        {

            var employee = _employeeList.Where(x => x.Id == model.Id)
                                         .FirstOrDefault();
            if (employee == null)
                return NotFound();

            employee.Name = model.Name;
            employee.DateOfBirth = model.DateOfBirth;
            TempData["message"] = "Employee updated successfully!";
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Look(int id)
        {
            if (id <= 0)
                return NotFound();
            var employee = _employeeList.Where(x => x.Id == id)
                                         .FirstOrDefault();
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();
            var employee = _employeeList.Where(x => x.Id == id)
                                         .FirstOrDefault();
            if (employee == null)
                return NotFound();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeModel model)
        {

            var employee = _employeeList.Where(x => x.Id == model.Id)
                                         .FirstOrDefault();
            if (employee == null)
                return NotFound();
            _employeeList.Remove(employee);
            TempData["message"] = "Employee deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
