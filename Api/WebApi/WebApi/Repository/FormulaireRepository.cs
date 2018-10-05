using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class FormulaireRepository
    {
        public readonly SatisfactionSurveyEntities SatisfactionSurveyEntities;
        public FormulaireRepository(SatisfactionSurveyEntities satisfactionSurveyEntities)
        {
            satisfactionSurveyEntities = SatisfactionSurveyEntities;
        }

        public IEnumerable<Formulaire> GetAllFormulaires()
        {
            IEnumerable<Formulaire> formulaires = SatisfactionSurveyEntities.Formulaire;
            return formulaires;
        }

        public Formulaire GetFormulaire(int id)
        {
            return SatisfactionSurveyEntities.Formulaire.FirstOrDefault(formulaire => formulaire.Id == id);
        }

        public string AddFormulaire(Formulaire formulaire)
        {
            SatisfactionSurveyEntities.Formulaire.Add(formulaire);
            SatisfactionSurveyEntities.SaveChanges();
            return formulaire.Titre;
        }

        public string EditFormulaire(Formulaire formulaire) //Possibilité de passer seulement les propriétés au lieu d'un objets si nécessaire
        {
            var formulaireToEdit = SatisfactionSurveyEntities.Formulaire.FirstOrDefault(f => f.Id == formulaire.Id);

            if (!string.IsNullOrEmpty(formulaire.Description))
                formulaireToEdit.Description = formulaire.Description;

            if (!string.IsNullOrEmpty(formulaire.Titre))
                formulaireToEdit.Titre = formulaire.Titre;

            formulaireToEdit.Composant = formulaire.Composant;

            SatisfactionSurveyEntities.SaveChanges();

            return formulaire.Titre;
        }

        public void DeleteFormulaire(int Id)
        {
            SatisfactionSurveyEntities.Formulaire.Remove(GetFormulaire(Id));
            SatisfactionSurveyEntities.SaveChanges();
        }

    }
}