//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hiring_Projet.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Candidat
    {
        public int id_candidat { get; set; }
        public string nom_candidat { get; set; }
        public string prénom_candidat { get; set; }
        public Nullable<int> âge { get; set; }
        public string titre { get; set; }
        public string diplôme { get; set; }
        public Nullable<int> nombre_année_expérience { get; set; }
        public byte[] CV { get; set; }
    }
}