using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ReponseRepository
    {
    readonly SatisfactionSurveyEntities SatisfactionSurveyEntities;
    public ReponseRepository(SatisfactionSurveyEntities satisfactionSurveyEntities)
        {
            satisfactionSurveyEntities = SatisfactionSurveyEntities;
        }

        public IEnumerable<Reponse> GetAllReponses()
        {
            IEnumerable<Reponse> reponses = SatisfactionSurveyEntities.Reponse;
            return reponses;
        }

        public Reponse GetReponse(int id)
        {
            return SatisfactionSurveyEntities.Reponse.FirstOrDefault(Reponse => Reponse.Id == id);
        }

        public int AddFormulaire(Reponse reponse)
        {
            SatisfactionSurveyEntities.Reponse.Add(reponse);
            SatisfactionSurveyEntities.SaveChanges();
            return reponse.Id;
        }

        public int EditReponse(Reponse reponse) //Possibilité de passer seulement les propriétés au lieu d'un objets si nécessaire
        {
            var reponseToEdit = SatisfactionSurveyEntities.Reponse.FirstOrDefault(f => f.Id == reponse.Id);

            if (!string.IsNullOrEmpty(reponse.Contenu))
                reponseToEdit.Contenu = reponse.Contenu;

           

            SatisfactionSurveyEntities.SaveChanges();

            return reponse.Id;
        }

        public void DeleteFormulaire(int Id)
        {
            SatisfactionSurveyEntities.Reponse.Remove(GetReponse(Id));
            SatisfactionSurveyEntities.SaveChanges();
        }




    }
}