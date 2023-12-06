using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP3.Models;
using TP3.Models.Repositories;

namespace TP3.Controllers
{
    [Authorize(Roles = "Manager")]


    public class SchoolController : Controller
    {
        readonly ISchoolRepository schoolRepository;
       // private readonly IWebHostEnvironment hostingEnvironment;

        public SchoolController(ISchoolRepository schoolRepositor)
        {
           // this.hostingEnvironment = hostingEnvironment;
           this.schoolRepository = schoolRepositor;

        }
        // GET: SchoolController
        [AllowAnonymous]

        public ActionResult Index()
        {
            var schools= schoolRepository.GetAll();
            return View(schools);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            var school = schoolRepository.GetById(id);
            return View(school);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School sc)
        {
            try
            {
                schoolRepository.Add(sc);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            var school = schoolRepository.GetById(id);
            return View(school);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(School sc)
        {
            try
            {
                schoolRepository.Edit(sc);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var sc= schoolRepository.GetById(id);
            return View(sc);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(School sc)
        {
            try
            {
                schoolRepository.Delete(sc);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
