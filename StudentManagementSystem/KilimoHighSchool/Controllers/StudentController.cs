using KilimoHighSchool.Features.Students.Database;
using KilimoHighSchool.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KilimoHighSchool.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentController> _logger;
        public StudentController(IStudentRepository studentRepository, ILogger<StudentController> logger)
        {
            _repository = studentRepository;
            _logger = logger;
        }
        // GET: Student
        public ActionResult Index()
        {
            //_logger.LogInformation("Pulling student fro the db");

            var students = _repository.GetSet().ToList(); 

            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student student)
        {
            try
            {
               await _repository.Add(student);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _logger.LogError("error {@error} experienced while saving the student {@student}", ex, student);

                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
