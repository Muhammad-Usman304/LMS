using Edumin.Models;
using Edumin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Edumin.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        public async Task<IActionResult> Index()
        {
            var classes = await _classService.GetAllClassesAsync();
            return View(classes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ClassModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClassModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _classService.SaveClassAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var classData = await _classService.GetClassAsync(id);

            if (classData == null)
                return NotFound();

            return View(classData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClassModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _classService.SaveClassAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _classService.DeleteClassAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
