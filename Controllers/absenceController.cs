using coreProject.Data;
using coreProject.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace coreProject.Controllers
{
     [Authorize(Roles="Admin")]
    
    public class absenceController:Controller
    {
         private readonly ApplicationDbContext ApplicationDbContext;
         public absenceController(ApplicationDbContext ApplicationDbContext)
         {
             this.ApplicationDbContext = ApplicationDbContext;
         }
         [HttpGet]
         public ActionResult Index()
         {
             var absences = ApplicationDbContext.Absence.ToList();
             return View(absences);
         }
         [HttpGet]
         public ActionResult Details(string codeAbsence)
         {
            var absence = ApplicationDbContext.Absence.Find(codeAbsence);
             return View(absence);
         
          }
         [HttpGet]
         public ActionResult Create()
         {
             return View();
         }
         [HttpPost]
         public ActionResult Create(Absence abs)
         {
            ApplicationDbContext.Absence.Add(abs);
            ApplicationDbContext.SaveChanges();
            return RedirectToAction("Index");
         }
         [HttpGet]
         public ActionResult Edit(string codeAbsence)
         {
              var absence = ApplicationDbContext.Absence.Find(codeAbsence);
             return View(absence);
         }
         [HttpPost]
         public ActionResult Edit(Absence abs)
         {
            ApplicationDbContext.Absence.Update(abs);
            ApplicationDbContext.SaveChanges();
            return RedirectToAction("Index");
         }
         [HttpGet]
         public ActionResult Delete(string codeAbsence)
         {
              var absence = ApplicationDbContext.Absence.Find(codeAbsence);
              ApplicationDbContext.Absence.Remove(absence);
              ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }

         
        
    }
}