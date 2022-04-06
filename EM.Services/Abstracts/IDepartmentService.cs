using EM.Models.Department;

namespace EM.Services.Abstracts
{
    public interface IDepartmentService
    {
        Task<bool> AddAsync(AddOrEditDepartment model, CancellationToken cancellationToken = default);
        Task<List<AddOrEditDepartment>> GetAllAsync();
        Task<AddOrEditDepartment> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(AddOrEditDepartment model, CancellationToken cancellationToken = default);
    }
}
