using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BackEndProjet.Models
{
    public class demande
    {
        public int id { get; set; }
        public int id_employe { get; set; }
        public int montant { get; set; }
        public String motif { get; set; }
        public String description { get; set; }
        public String statut { get; set; }
        public String login { get; set; }
        public String date_demande { get; set; }
        public String date_validation { get; set; }
        public String date_execution { get; set; }
        public String cdate { get; set; }
        public String cuser { get; set; }
        public String udate { get; set; }
        public String uuser { get; set; }

        private DataRow DemandeRecord;


        public demande()
        {
        }

        public demande(DataRow DemandeRecord)
        {
            id = Convert.ToInt32(DemandeRecord["id"]);
            id_employe = Convert.ToInt32(DemandeRecord["id_employe"]);
            montant = Convert.ToInt32(DemandeRecord["montant"]);
            motif = DemandeRecord["motif"].ToString();
            description = DemandeRecord["description"].ToString();
            statut = DemandeRecord["statut"].ToString();
            login = DemandeRecord["login"].ToString();
            cuser = DemandeRecord["cuser"].ToString();
            uuser = DemandeRecord["uuser"].ToString();


        }

    }
}