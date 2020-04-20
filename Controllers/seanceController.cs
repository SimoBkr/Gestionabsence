using Microsoft.AspNetCore.Mvc;
using coreProject.Data;
using coreProject.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace coreProject.Controllers
{
     [Authorize(Roles="Admin")]
    public class seanceController:Controller
    {
     private readonly ApplicationDbContext ApplicationDbContext;
     public seanceController(ApplicationDbContext ApplicationDbContext)
     {
         this.ApplicationDbContext = ApplicationDbContext;
     }
       [HttpGet]
        public ActionResult Index()
            {
               var seances = ApplicationDbContext.Seance.ToList();
               return View(seances); 
            }
        [HttpGet]
        public ActionResult Details(int codeSeance)  
        {
            var Seance = ApplicationDbContext.Seance.Find(codeSeance);
            return View(Seance);
        }  
        [HttpGet]
        public ActionResult Create()
         {
             return View();
         }
         [HttpPost]
          public ActionResult Create(Seance sc)
         {
             ApplicationDbContext.Seance.Add(sc);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
         [HttpGet]
        public ActionResult Edit(int codeSeance )
         {
             var sc = ApplicationDbContext.Seance.Find(codeSeance);
            return View(sc);
         }
         [HttpPost]
          public ActionResult Edit(Seance sc)
         {
             ApplicationDbContext.Seance.Update(sc);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
         [HttpGet]
         public ActionResult Delete(int codeSeance)
         {
             var sc = ApplicationDbContext.Seance.Find(codeSeance);
             ApplicationDbContext.Seance.Remove(sc);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
     

    }
}