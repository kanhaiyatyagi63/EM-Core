using EM.Models.Employee;

namespace EM.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly ILanguageService _languageService;


        public EmployeeController(IEmployeeService employeeService,
            IDepartmentService departmentService,
            ILanguageService languageService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View(await _employeeService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.departments = await _departmentService.GetAllAsync();
            ViewBag.languages = await _languageService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeAddModel employee)
        {
            if (!ModelState.IsValid)
                return View(employee);
            var isInserted = await _employeeService.AddAsync(employee);
            if (isInserted)
                TempData["message"] = "Employee created successfully!";
            else
                TempData["message"] = "Unable to create employee!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id <= 0)
                return NotFound();
            //var employee = _employeeList.Where(x => x.Id == id)
            //                             .FirstOrDefault();
            //if (employee == null)
            //    return NotFound();
            return View();
        }
        [HttpPost]
        public IActionResult Update(EmployeeAddModel model)
        {

            //var employee = _employeeList.Where(x => x.Id == model.Id)
            //                             .FirstOrDefault();
            //if (employee == null)
            //    return NotFound();

            //employee.Name = model.Name;
            //employee.DateOfBirth = model.DateOfBirth;
            TempData["message"] = "Employee updated successfully!";
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Look(int id)
        {
            if (id <= 0)
                return NotFound();
            //var employee = _employeeList.Where(x => x.Id == id)
            //                             .FirstOrDefault();
            //if (employee == null)
            //    return NotFound();
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();
            //var employee = _employeeList.Where(x => x.Id == id)
            //                             .FirstOrDefault();
            //if (employee == null)
            //    return NotFound();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(EmployeeAddModel model)
        {

            //var employee = _employeeList.Where(x => x.Id == model.Id)
            //                             .FirstOrDefault();
            //if (employee == null)
            //    return NotFound();
            //_employeeList.Remove(employee);
            TempData["message"] = "Employee deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
