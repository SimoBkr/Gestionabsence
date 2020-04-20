using Microsoft.AspNetCore.Mvc;
using coreProject.Data;
using coreProject.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace coreProject.Controllers
{
     [Authorize(Roles="Admin")]
    public class filiereController:Controller
    {
          private readonly ApplicationDbContext ApplicationDbContext;
          public filiereController(ApplicationDbContext ApplicationDbContext)
          {
              this.ApplicationDbContext = ApplicationDbContext;
          }
           [HttpGet]
        public ActionResult Index()
            {
               var Filieres = ApplicationDbContext.Filiere.ToList();
               return View(Filieres); 
            }
        [HttpGet]
        public ActionResult Details(int codeFiliere)  
        {
            var Filiere = ApplicationDbContext.Filiere.Find(codeFiliere);
            return View(Filiere);
        }  
        [HttpGet]
        public ActionResult Create()
         {
             return View();
         }
         [HttpPost]
          public ActionResult Create(Filiere flr)
         {
             ApplicationDbContext.Filiere.Add(flr);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
         [HttpGet]
        public ActionResult Edit(int codeFiliere )
         {
             var flr = ApplicationDbContext.Filiere.Find(codeFiliere);
            return View(flr);
         }
         [HttpPost]
          public ActionResult Edit(Filiere flr)
         {
             ApplicationDbContext.Filiere.Update(flr);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
         [HttpGet]
         public ActionResult Delete(int codeFiliere)
         {
             var mtr = ApplicationDbContext.Filiere.Find(codeFiliere);
             ApplicationDbContext.Filiere.Remove(mtr);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
        

    }
}