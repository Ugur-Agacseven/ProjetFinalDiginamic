using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models.Bdd;
using WebApi.Repository;

namespace WebApi.Controllers.ApiControllers
{
    public class FormulaireApiController : ApiController
    {
        public FormulaireRepository formulairectrl = new FormulaireRepository();
        public SondageRepository sondagectrl = new SondageRepository();

        //Rappatrier les formulaires valides
        public IHttpActionResult GetFormulaires()
        {
            return Ok(formulairectrl.GetAllFormulaires());
        }

        // get api/formulairesapi/id
        [ResponseType(typeof(Formulaire))]
        public IHttpActionResult GetFormulaires(int id)
        {
            Formulaire form = formulairectrl.GetFormulaire(id);
            return Ok(form);
        }


        // Envoi des réponses dans la table ChoixRéponse
        [HttpPost]
        public  IHttpActionResult PostSondage(Sondage sondage)
        {
            
            return Ok(sondagectrl.AddSondage(sondage));
        }


    }
}
