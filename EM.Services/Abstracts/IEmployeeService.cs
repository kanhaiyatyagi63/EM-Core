using EM.Models.Employee;

namespace EM.Services.Abstracts
{
    public interface IEmployeeService
    {
        //Task Delete(int id);
        Task<List<EmployeeViewModel>> GetAllAsync();
        Task<bool> AddAsync(EmployeeAddModel model, CancellationToken cancellationToken = default);
    }
}
