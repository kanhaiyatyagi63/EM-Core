using EM.DataLayer.Context;
using EM.DataLayer.Entities;
using EM.Models.Department;
using EM.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EM.Services
{
    public class DepartmentService : IDepartmentService
    {
        public static EmployeeContext _dbContext;

        public DepartmentService(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddOrEditDepartment> GetByIdAsync(int id)
        {
            return await _dbContext.Departments.Select(x => new AddOrEditDepartment()
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync(x => x.Id == id);
        }



        public async Task<List<AddOrEditDepartment>> GetAllAsync()
        {
            return await _dbContext.Departments.Select(x => new AddOrEditDepartment()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task<bool> AddAsync(AddOrEditDepartment model, CancellationToken cancellationToken = default)
        {
            try
            {
                var dept = _dbContext.Departments
                                     .Any(x => x.Name == model.Name.Trim());
                if (dept)
                {
                    return false;
                }
                var department = new Department()
                {
                    Name = model.Name.Trim()
                };
                await _dbContext.Departments.AddAsync(department);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(AddOrEditDepartment model, CancellationToken cancellationToken = default)
        {
            try
            {
                var dept = _dbContext.Departments
                                     .Any(x => x.Name == model.Name.Trim()
                                            && x.Id != model.Id);
                if (dept)
                {
                    return false;
                }
                var department = new Department()
                {
                    Id = model.Id,
                    Name = model.Name.Trim()
                };
                _dbContext.Departments.Update(department);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
                return false;
            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
