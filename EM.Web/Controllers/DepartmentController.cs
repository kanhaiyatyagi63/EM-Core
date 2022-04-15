using EM.Models.Department;

namespace EM.Web.Controllers;


public class DepartmentController : Controller
{
    public readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    // only view operation, no need to add post method
    public async Task<IActionResult> Index()
    {
        return View(await _departmentService.GetAllAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(AddOrEditDepartment model)
    {
        var isInserted = await _departmentService.AddAsync(model);
        if (isInserted)
            TempData["message"] = "Department created successfully!";
        else
            TempData["message"] = "Unable to create department!";

        return RedirectToAction(nameof(Index));
    }
    [Route("department/update/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        if (id <= 0)
            return NotFound();
        return View(await _departmentService.GetByIdAsync(id));
    }
    [HttpPost, Route("department/update")]
    public async Task<IActionResult> Edit(AddOrEditDepartment model)
    {
        var isUpdated = await _departmentService.UpdateAsync(model);
        if (isUpdated)
            TempData["message"] = "Department updated successfully!";
        else
            TempData["message"] = "Unable to update department!";

        return RedirectToAction(nameof(Index));
    }
    // only view operation, no need to add post method
    public async Task<IActionResult> Look(int id)
    {
        if (id <= 0)
            return NotFound();
        return View(await _departmentService.GetByIdAsync(id));
    }
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return NotFound();
        return View(await _departmentService.GetByIdAsync(id));
    }
    [HttpPost]
    public async Task<IActionResult> Delete(AddOrEditDepartment model)
    {
        var isDeleted = await _departmentService.DeleteAsync(model.Id);
        if (isDeleted)
            TempData["message"] = "Department updated successfully!";
        else
            TempData["message"] = "Unable to delete department!";

        return RedirectToAction(nameof(Index));
    }
}
