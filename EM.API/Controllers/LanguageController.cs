using EM.DataLayer.Context;
using EM.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EM.API.Controllers
{
    public class LanguageController : BaseController
    {
        public static EmployeeContext _dbContext;

        public LanguageController(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Language), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var tt = IpAddress;
            if (id <= 0)
                return BadRequest("Id must be greater than 0 ");
            var language = await _dbContext.Languages.FirstOrDefaultAsync(x => x.Id == id);
            if (language == null)
                return BadRequest("Unable to find the language");
            return Ok(language);
        }
    }
}
