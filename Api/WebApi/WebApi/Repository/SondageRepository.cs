using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Bdd;

namespace WebApi.Repository
{
    public class SondageRepository
    {
        readonly SatisfactionSurveyEntities satisfactionSurveyEntities = new SatisfactionSurveyEntities();
        //public ReponseRepository(SatisfactionSurveyEntities satisfactionSurveyEntities)
        //    {
        //        satisfactionSurveyEntities = SatisfactionSurveyEntities;
        //    }

        public IEnumerable<Sondage> GetAllSondage()
        {
            IEnumerable<Sondage> sondages = satisfactionSurveyEntities.Sondage;
            return sondages;
        }

        public Sondage GetSondage(int id)
        {
            return satisfactionSurveyEntities.Sondage.FirstOrDefault(sondage => sondage.id == id);
        }

        public int AddSondage(Sondage sondage)
        {
            satisfactionSurveyEntities.Sondage.Add(sondage);
            satisfactionSurveyEntities.SaveChanges();
            return sondage.id;
        }


        //Pas besoin de modifier les sondages
        //public int EditSondage(Sondage sondage)  
        //{
        //    var sondageToEdit = satisfactionSurveyEntities.Sondage.FirstOrDefault(f => f.id == sondage.id);


        //    satisfactionSurveyEntities.SaveChanges();

        //    return sondage.id;
        //}

        public void DeleteFormulaire(int Id)
        {
            satisfactionSurveyEntities.Sondage.Remove(GetSondage(Id));
            satisfactionSurveyEntities.SaveChanges();
        }
    }
}