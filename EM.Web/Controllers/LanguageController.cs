using EM.Models.Language;
using EM.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EM.Web.Controllers
{
    public class LanguageController : Controller
    {
        public readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        // only view operation, no need to add post method
        public async Task<IActionResult> Index()
        {
            return View(await _languageService.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddOrEditlanguageModel model)
        {
            var isInserted = await _languageService.AddAsync(model);
            if (isInserted)
                TempData["message"] = "Language created successfully!";
            else
                TempData["message"] = "Unable to create language!";

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
                return NotFound();
            return View(await _languageService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AddOrEditlanguageModel model)
        {
            var isUpdated = await _languageService.UpdateAsync(model);
            if (isUpdated)
                TempData["message"] = "Language updated successfully!";
            else
                TempData["message"] = "Unable to update language!";

            return RedirectToAction(nameof(Index));
        }
        // only view operation, no need to add post method
        public async Task<IActionResult> Look(int id)
        {
            if (id <= 0)
                return NotFound();
            return View(await _languageService.GetByIdAsync(id));
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return NotFound();
            return View(await _languageService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(AddOrEditlanguageModel model)
        {
            var isDeleted = await _languageService.DeleteAsync(model.Id);
            if (isDeleted)
                TempData["message"] = "Language updated successfully!";
            else
                TempData["message"] = "Unable to delete language!";

            return RedirectToAction(nameof(Index));
        }
    }
}
