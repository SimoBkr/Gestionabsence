using System.Linq;
using coreProject.Data;
using Microsoft.AspNetCore.Mvc;
using coreProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace coreProject.Controllers
{
     [Authorize(Roles="Admin")]
    public class professeurController:Controller
    {
        private readonly ApplicationDbContext ApplicationDbContext;
        public professeurController(ApplicationDbContext ApplicationDbContext)
        {
            this.ApplicationDbContext = ApplicationDbContext;
        }
        [HttpGet]
        public ActionResult Index()
            {
               var Professers = ApplicationDbContext.Professeur.ToList();
               return View(Professers); 
            }
        [HttpGet]
        public ActionResult Details(int codeProf)  
        {
            var Professer = ApplicationDbContext.Professeur.Find(codeProf);
            return View(Professer);
        }  
        [HttpGet]
        public ActionResult Create()
         {
             return View();
         }
         [HttpPost]
          public ActionResult Create(Professeur prof)
         {
             ApplicationDbContext.Professeur.Add(prof);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
         [HttpGet]
        public ActionResult Edit(int codeProf )
         {
             var Professer = ApplicationDbContext.Professeur.Find(codeProf);
            return View(Professer);
         }
         [HttpPost]
          public ActionResult Edit(Professeur prof)
         {
             ApplicationDbContext.Professeur.Update(prof);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
         [HttpGet]
         public ActionResult Delete(int codeProf)
         {
             var Professer = ApplicationDbContext.Professeur.Find(codeProf);
             ApplicationDbContext.Professeur.Remove(Professer);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
        
        



        
    }
}