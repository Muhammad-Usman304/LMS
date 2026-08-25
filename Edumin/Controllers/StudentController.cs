using Edumin.Models;
using Edumin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edumin.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        private async Task LoadDropdowns(int? selectedClassId = null, int? selectedGenderId = null)
        {
            var classes = await _studentService.GetAllClassesAsync();
            var genders = await _studentService.GetAllGendersAsync();

            ViewBag.ClassList = new SelectList(classes, "ClassId", "ClassName", selectedClassId);
            ViewBag.GenderList = new SelectList(genders, "GenderId", "GenderName", selectedGenderId);
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students);
        }

        // CREATE
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();

            return View(new Student
            {
                RegistrationDate = DateTime.Now
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(student.ClassId, student.GenderId);
                return View(student);
            }

            await _studentService.SaveStudentAsync(student);
            return RedirectToAction(nameof(Index));
        }

        // EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentAsync(id);

            if (student == null)
                return NotFound();

            await LoadDropdowns(student.ClassId, student.GenderId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(student.ClassId, student.GenderId);
                return View(student);
            }

            await _studentService.SaveStudentAsync(student);
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}