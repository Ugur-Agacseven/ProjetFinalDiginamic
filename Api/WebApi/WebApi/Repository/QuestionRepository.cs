using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Bdd;

namespace WebApi.Repository
{
    public class QuestionRepository
    {
        readonly SatisfactionSurveyEntities satisfactionSurveyEntities = new SatisfactionSurveyEntities();
        //public QuestionRepository(SatisfactionSurveyEntities satisfactionSurveyEntities)
        //{
        //    SatisfactionSurveyEntities = satisfactionSurveyEntities;
        //}

        public IEnumerable<Question> GetAllQuestions()
        {
            IEnumerable<Question> questions = satisfactionSurveyEntities.Question;
            return questions;
        }

        public Question GetQuestion(int id)
        {
            return satisfactionSurveyEntities.Question.FirstOrDefault(question => question.Id == id);
        }

        public int AddQuestion(Question question)
        {
            satisfactionSurveyEntities.Question.Add(question);
            satisfactionSurveyEntities.SaveChanges();
            return question.id;
        }

        public int EditQuestion(Question question) //Possibilité de passer seulement les propriétés au lieu d'un objets si nécessaire
        {
            var questionToEdit = satisfactionSurveyEntities.Question.FirstOrDefault(f => f.id == question.id);

            if (!string.IsNullOrEmpty(question.contenu))
                questionToEdit.contenu = question.contenu;

                questionToEdit.Composant = question.Composant;
                questionToEdit.Reponse = question.Reponse;



            SatisfactionSurveyEntities.SaveChanges();

            return question.Id;
        }

        public void DeleteQuestion(int Id)
        {
            SatisfactionSurveyEntities.Question.Remove(GetQuestion(Id));
            SatisfactionSurveyEntities.SaveChanges();
        }





    }
}