//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models.Bdd
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reponse
    {
        public int id { get; set; }
        public string contenu { get; set; }
        public string commentaire { get; set; }
        public Nullable<int> idQuestion { get; set; }
    
        public virtual Question Question { get; set; }
    }
}
