using EM.Models.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Services.Abstracts
{
    public interface ILanguageService
    {
        Task<bool> AddAsync(AddOrEditlanguageModel model, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id);
        Task<List<AddOrEditlanguageModel>> GetAllAsync();
        Task<AddOrEditlanguageModel> GetByIdAsync(int id);
        Task<bool> UpdateAsync(AddOrEditlanguageModel model, CancellationToken cancellationToken = default);
    }
}
