using coreProject.Data;
using coreProject.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace coreProject.Controllers
{
   [Authorize(Roles="Admin,Professeur")]
   
    public class methodsController:Controller
    {
        
          private readonly ApplicationDbContext ApplicationDbContext;
          public methodsController(ApplicationDbContext ApplicationDbContext)
    {
    this.ApplicationDbContext = ApplicationDbContext;
    }
        [HttpGet]
         public ActionResult listAbsenceMatiere()
         {
           var absences =(from etudiant in ApplicationDbContext.Etudiant
             join absence in ApplicationDbContext.Absence  on etudiant.codeCart equals absence.codeCart 
             select new listAbsenceMatiere {
                  nomEtudiant =  etudiant.nomEtudiant , 
                   prenomEtudiant =  etudiant.prenomEtudiant ,
                   dateAbsence=  absence.dateAbsence ,
                     codeMatiere= absence.codeMatiere
                 }).ToList();
             return View(absences );
         }
         [HttpGet]
         public ActionResult listPresenceMatiere()
         {
             var presences = (from etudiant in ApplicationDbContext.Etudiant
             join absence in ApplicationDbContext.Absence  on etudiant.codeCart !equals absence.codeCart 
             select new listPresenceMatiere {
               nomEtudiant= etudiant.nomEtudiant , 
               prenomEtudiant= etudiant.prenomEtudiant  ,
               codeMatiere= absence.codeMatiere});
             return View(presences);
         }
         [HttpGet]
         public ActionResult tauxMatiere()
         {
            int nbrAllMatier = ApplicationDbContext.Absence.Count();
            var tauxMatier = (from matier in ApplicationDbContext.Matiere 
             join absence in ApplicationDbContext.Absence on matier.codeMatiere equals absence.codeMatiere
               select new tauxMatiere{
                   nomMatiere=matier.nomMatiere , 
                    taux = (absence.codeMatiere.Count()/nbrAllMatier)*100}
              );
             return View(tauxMatier);
         }
         [HttpGet]
         public ActionResult nombreEtudiantAbsnce()
         {
             var etudiantAbsence = (from etudiant in ApplicationDbContext.Etudiant
              join absence in ApplicationDbContext.Absence on etudiant.codeCart equals absence.codeCart
              select new nombreEtudiantAbsnce  {
                  nomEtudiant=  etudiant.nomEtudiant , 
                  prenomEtudiant=  etudiant.prenomEtudiant , 
                  nombre = absence.codeCart.Count()}
             );
             return View(etudiantAbsence);
         }
         [HttpGet]
         public ActionResult tauxEtudiantAbsenteisme()
         {
             var nbrallAbsence =  ApplicationDbContext.Absence.Count();
             var tauxAbsencer = (from etudiant in ApplicationDbContext.Etudiant 
             join absence in ApplicationDbContext.Absence on etudiant.codeCart equals absence.codeCart
               select new tauxEtudiantAbsenteisme {
                 codeCart =  etudiant.codeCart ,
                 taux = (absence.codeCart.Count()/nbrallAbsence)*100}
              );
             return View(tauxAbsencer);
         }
    }
}