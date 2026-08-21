using Edumin.Models;
using Edumin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edumin.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        private async Task LoadDropdowns(
            int? selectedGenderId = null,
            int? selectedDepartmentId = null,
            int? selectedDesignationId = null)
        {
            var genders = await _teacherService.GetAllGendersAsync();
            var departments = await _teacherService.GetAllDepartmentsAsync();
            var designations = await _teacherService.GetAllDesignationsAsync();

            ViewBag.GenderList = new SelectList(genders, "GenderId", "GenderName", selectedGenderId);
            ViewBag.DepartmentList = new SelectList(departments, "DepartmentId", "DepartmentName", selectedDepartmentId);
            ViewBag.DesignationList = new SelectList(designations, "DesignationId", "DesignationName", selectedDesignationId);
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return View(teachers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();

            return View(new TeacherModel
            {
                JoiningDate = DateTime.Now
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model.GenderId, model.DepartmentId, model.DesignationId);
                return View(model);
            }

            await _teacherService.SaveTeacherAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _teacherService.GetTeacherAsync(id);

            if (teacher == null)
                return NotFound();

            await LoadDropdowns(teacher.GenderId, teacher.DepartmentId, teacher.DesignationId);
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeacherModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model.GenderId, model.DepartmentId, model.DesignationId);
                return View(model);
            }

            await _teacherService.SaveTeacherAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherService.DeleteTeacherAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
