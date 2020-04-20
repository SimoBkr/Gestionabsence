using Microsoft.AspNetCore.Mvc;
using coreProject.Data;
using coreProject.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace coreProject.Controllers
{
     [Authorize(Roles="Admin")]
    public class matiereController:Controller
    { 
        private readonly ApplicationDbContext ApplicationDbContext;
          public matiereController(ApplicationDbContext ApplicationDbContext)
          {
               this.ApplicationDbContext = ApplicationDbContext;
          }
          [HttpGet]
        public ActionResult Index()
            {
               var Matieres = ApplicationDbContext.Matiere.ToList();
               return View(Matieres); 
            }
        [HttpGet]
        public ActionResult Details(string codeMatiere)  
        {
            var matiere = ApplicationDbContext.Matiere.Find(codeMatiere);
            return View(matiere);
        }  
        [HttpGet]
        public ActionResult Create()
         {
             return View();
         }
         [HttpPost]
          public ActionResult Create(Matiere mtr)
         {
             ApplicationDbContext.Matiere.Add(mtr);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
         [HttpGet]
        public ActionResult Edit(string codeMatiere )
         {
             var mtr = ApplicationDbContext.Matiere.Find(codeMatiere);
            return View(mtr);
         }
         [HttpPost]
          public ActionResult Edit(Matiere mtr)
         {
             ApplicationDbContext.Matiere.Update(mtr);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
         [HttpGet]
         public ActionResult Delete(string codeMatiere)
         {
             var mtr = ApplicationDbContext.Matiere.Find(codeMatiere);
             ApplicationDbContext.Matiere.Remove(mtr);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
        
        
    }
}