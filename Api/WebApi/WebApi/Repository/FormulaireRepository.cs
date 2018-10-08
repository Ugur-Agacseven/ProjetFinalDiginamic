﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApi.Models.Bdd;

namespace WebApi.Repository
{
    public class FormulaireRepository
    {
        //public readonly SatisfactionSurveyEntities SatisfactionSurveyEntities;
        //public FormulaireRepository(SatisfactionSurveyEntities satisfactionSurveyEntities)
        //{
        //    satisfactionSurveyEntities = SatisfactionSurveyEntities;
        //}
        readonly SatisfactionSurveyEntities satisfactionSurveyEntities = new SatisfactionSurveyEntities();

        public IEnumerable<Formulaire> GetAllFormulaires()
        {
            IEnumerable<Formulaire> formulaires = satisfactionSurveyEntities.Formulaire;
            return formulaires;
        }

        public Formulaire GetFormulaire(int id)
        {
            return satisfactionSurveyEntities.Formulaire.FirstOrDefault(formulaire => formulaire.id == id);
        }

        public string AddFormulaire(Formulaire formulaire)
        {
            satisfactionSurveyEntities.Formulaire.Add(formulaire);
            satisfactionSurveyEntities.SaveChanges();
            return formulaire.titre;
        }

        public string EditFormulaire(Formulaire formulaire) //Possibilité de passer seulement les propriétés au lieu d'un objets si nécessaire
        {
            var formulaireToEdit = satisfactionSurveyEntities.Formulaire.FirstOrDefault(f => f.id == formulaire.id);

            if (!string.IsNullOrEmpty(formulaire.description))
                formulaireToEdit.description = formulaire.description;

            if (!string.IsNullOrEmpty(formulaire.titre))
                formulaireToEdit.titre = formulaire.titre;

            formulaireToEdit.Composant = formulaire.Composant;

            satisfactionSurveyEntities.SaveChanges();

            return formulaire.titre;
        }

        public void DeleteFormulaire(int Id)
        {
            satisfactionSurveyEntities.Formulaire.Remove(GetFormulaire(Id));
            satisfactionSurveyEntities.SaveChanges();
        }

    }
}