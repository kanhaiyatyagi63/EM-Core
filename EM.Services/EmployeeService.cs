using EM.DataLayer.Context;
using EM.DataLayer.Entities;
using EM.Models.Employee;
using EM.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EM.Services
{
    public class EmployeeService : IEmployeeService
    {
        public static EmployeeContext _dbContext;

        public EmployeeService(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            return await _dbContext.Employees.Select(x => new EmployeeViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                JobTitle = x.JobTitle,
                DateOfBirth = x.DateOfBirth
            }).ToListAsync();
        }

        public async Task<bool> AddAsync(EmployeeAddModel model, CancellationToken cancellationToken = default)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = model.Id,
                    JobTitle = model.JobTitle,
                    Gender = model.Gender,
                    Address = new Address()
                    {
                        City = model.City,
                        State = model.State,
                        Country = model.Country
                    },
                    DepartmentId = model.DepartmentId,
                    DateOfBirth = model.DateOfBirth,
                    Name = model.Name,
                    EmployeeLanguages = model.Languages.Select(x => new EmployeeLanguage()
                    {
                        LanguageId = x
                    }).ToList() ?? new List<EmployeeLanguage>()
                };
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
