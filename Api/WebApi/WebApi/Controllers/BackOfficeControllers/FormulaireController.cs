using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers.BackOfficeControllers
{
    public class FormulaireController : Controller
    {
        readonly SatisfactionSurveyEntities satisfactionSurveyEntities = new SatisfactionSurveyEntities();
        readonly FormulaireRepository FormRep = new FormulaireRepository(); 
        // GET: Formulaire
        public ActionResult Index()
        {
            return View(FormRep.GetAllFormulaires());
        }

        // GET: Formulaire/Details/5
        public ActionResult Details(int id)
        {
            return View(FormRep.GetFormulaire(id));
        }

        // GET: Formulaire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formulaire/Create
        [HttpPost]
        public ActionResult Create(Formulaire formulaire)
        {
            //if(formulaire isvalid ) //Methode is valid ?
            //{

                satisfactionSurveyEntities.Formulaire.Add(formulaire);
                satisfactionSurveyEntities.SaveChanges();

                return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View();
            //}
        }

        // GET: Formulaire/Edit/5
        public ActionResult Edit(int id)
        {
            FormRep.GetFormulaire(id);
            return View();
        }

        // POST: Formulaire/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            //if(formulaire isvalid ) //Methode is valid ?
            //{
            // TODO: Add update logic here


            return RedirectToAction("Index");
            }
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Formulaire/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Formulaire/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
