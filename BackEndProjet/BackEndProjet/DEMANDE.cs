//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEndProjet
{
    using System;
    using System.Collections.Generic;
    
    public partial class DEMANDE
    {
        public decimal ID { get; set; }
        public Nullable<decimal> ID_EMPLOYE { get; set; }
        public Nullable<decimal> MONTANT { get; set; }
        public string MOTIF { get; set; }
        public string DESCRIPTION { get; set; }
        public string STATUT { get; set; }
        public string LOGIN { get; set; }
        public Nullable<System.DateTime> DATE_DEMANDE { get; set; }
        public Nullable<System.DateTime> DATE_VALIDATION { get; set; }
        public Nullable<System.DateTime> DATE_EXECUTION { get; set; }
        public Nullable<System.DateTime> CDATE { get; set; }
        public Nullable<System.DateTime> UDATE { get; set; }
        public string CUSER { get; set; }
        public string UUSER { get; set; }
    }
}