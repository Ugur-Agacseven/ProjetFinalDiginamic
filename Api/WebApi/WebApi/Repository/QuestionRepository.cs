using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class QuestionRepository
    {
        readonly SatisfactionSurveyEntities SatisfactionSurveyEntities;
        public QuestionRepository(SatisfactionSurveyEntities satisfactionSurveyEntities)
        {
            SatisfactionSurveyEntities = satisfactionSurveyEntities;
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            IEnumerable<Question> questions = SatisfactionSurveyEntities.Question;
            return questions;
        }

        public Question GetQuestion(int id)
        {
            return SatisfactionSurveyEntities.Question.FirstOrDefault(question => question.Id == id);
        }

        public int AddQuestion(Question question)
        {
            SatisfactionSurveyEntities.Question.Add(question);
            SatisfactionSurveyEntities.SaveChanges();
            return question.Id;
        }

        public int EditQuestion(Question question) //Possibilité de passer seulement les propriétés au lieu d'un objets si nécessaire
        {
            var questionToEdit = SatisfactionSurveyEntities.Question.FirstOrDefault(f => f.Id == question.Id);

            if (!string.IsNullOrEmpty(question.Contenu))
                questionToEdit.Contenu = question.Contenu;

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