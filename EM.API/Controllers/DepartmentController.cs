using EM.Models.Department;
using EM.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EM.API.Controllers
{
    public class DepartmentController : BaseController
    {
        public readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AddOrEditDepartment), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Id must be greater than 0 ");
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null)
                return BadRequest("Unable to find the department");
            return Ok(department);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AddOrEditDepartment>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _departmentService.GetAllAsync());
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]AddOrEditDepartment newDepartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check the details!");
            }

            var isInserted = await _departmentService.AddAsync(newDepartment);
            if (isInserted)
                return Ok(isInserted);
            else
                return BadRequest("Unable to add department!");
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(AddOrEditDepartment updateDepartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check the details!");
            }
            var isUpdated = await _departmentService.UpdateAsync(updateDepartment);
            if (isUpdated)
                return Ok(isUpdated);
            else
                return BadRequest("Unable to update department!");
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id must be greater than 0");
            var isDeleted = await _departmentService.DeleteAsync(id);
            if (isDeleted)
                return Ok(isDeleted);
            return BadRequest("Unable to delete department");
        }

    }
}
