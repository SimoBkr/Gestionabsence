using System.Linq;
using coreProject.Data;
using coreProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace coreProject.Controllers
{
    [Authorize(Roles="Admin")]
    public class etudiantController:Controller
    {
        
        public  ApplicationDbContext ApplicationDbContext;
        public etudiantController(ApplicationDbContext ApplicationDbContext)
        {
            this.ApplicationDbContext = ApplicationDbContext;
        }
         [HttpGet]
         public ActionResult Index()
         {
             var Etudiants = ApplicationDbContext.Etudiant.ToList();
             return View(Etudiants);
         }
          [HttpGet]
           public ActionResult Details(string codeCart)
         {
             var Etudiant = ApplicationDbContext.Etudiant.Find(codeCart);
             return View(Etudiant);
         }
          [HttpGet]
         public ActionResult Create()
         {
             return View();
         }
         [HttpPost]
         public ActionResult Create(Etudiant etd)
         {
             ApplicationDbContext.Etudiant.Add(etd);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }
          [HttpGet]
         public ActionResult Edit(string codeCart)
         {
             var Etudiant = ApplicationDbContext.Etudiant.Find(codeCart);
             return View(Etudiant);
         }
         [HttpPost]
         public ActionResult Edit(Etudiant etd)
         {
             ApplicationDbContext.Etudiant.Update(etd);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }

          [HttpGet]
         public ActionResult Delete(string codeCart)
         {
             var Etudiant = ApplicationDbContext.Etudiant.Find(codeCart);
             ApplicationDbContext.Etudiant.Remove(Etudiant);
             ApplicationDbContext.SaveChanges();
             return RedirectToAction("Index");
         }

         

        
    }
}