using KilimoHighSchool.Features.ClassStreams.Database;
using KilimoHighSchool.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KilimoHighSchool.Controllers
{
    public class ClassStreamController : Controller
    {
        private readonly IClassStreamRepository _repository;
        private readonly ILogger<ClassStreamController> _logger;
        public ClassStreamController(IClassStreamRepository repository, ILogger<ClassStreamController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // GET: ClassStream
        public ActionResult Index()
        {
            var streams = _repository.GetSet().ToList();
            return View(streams);
        }

        // GET: ClassStream/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClassStream/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassStream/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClassStream classStream)
        {
            try
            {
                await _repository.Add(classStream);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError("error {@error} experienced while saving the stream {@student}", ex, classStream);

                return View();
            }
        }

        // GET: ClassStream/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClassStream/Edit/5
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

        // GET: ClassStream/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClassStream/Delete/5
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
