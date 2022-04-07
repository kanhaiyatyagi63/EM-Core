using EM.DataLayer.Context;
using EM.DataLayer.Entities;
using EM.Models.Language;
using EM.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EM.Services
{
    public class LanguageService : ILanguageService
    {
        public static EmployeeContext _dbContext;

        public LanguageService(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddOrEditlanguageModel> GetByIdAsync(int id)
        {
            return await _dbContext.Languages.Select(x => new AddOrEditlanguageModel()
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<AddOrEditlanguageModel>> GetAllAsync()
        {
            return await _dbContext.Languages.Select(x => new AddOrEditlanguageModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task<bool> AddAsync(AddOrEditlanguageModel model, CancellationToken cancellationToken = default)
        {
            try
            {
                var lang = _dbContext.Languages
                                     .Any(x => x.Name == model.Name.Trim());
                if (lang)
                {
                    return false;
                }
                var language = new Language()
                {
                    Name = model.Name.Trim()
                };
                await _dbContext.Languages.AddAsync(language);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(AddOrEditlanguageModel model, CancellationToken cancellationToken = default)
        {
            try
            {
                var lang = _dbContext.Languages
                                     .Any(x => x.Name == model.Name.Trim()
                                            && x.Id != model.Id);
                if (lang)
                {
                    return false;
                }
                var language = new Language()
                {
                    Id = model.Id,
                    Name = model.Name.Trim()
                };
                _dbContext.Languages.Update(language);
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
            var language = await _dbContext.Languages.FirstOrDefaultAsync(x => x.Id == id);
            if (language == null)
                return false;
            _dbContext.Languages.Remove(language);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
