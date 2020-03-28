using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BackEndProjet.Models
{
    public class Employe
    {
        public int id { get;  set; }
        public String nom;
        public String prenom;
        public long numcarte;
        public int salaire;
        public int capacite;
        public int nbabsence;

        public string matricule;
        public String entreprise;
        public String loginemploye;
        public String loginemployeur;
        public int mobile;
        public String adresse;
        public String email;

        public String cdate;
        public String cuser;
        public String udate;
        public String uuser;
        private DataRow employeRecord;

        public Employe()
        {
        }

        public Employe(DataRow employeRecord)
        {
            id = Convert.ToInt32(employeRecord["id"]);
            nom = employeRecord["nom"].ToString();
            prenom = employeRecord["prenom"].ToString();
            numcarte = Convert.ToInt64(employeRecord["numcarte"]);
            salaire = Convert.ToInt32(employeRecord["salaire"]); ;
            capacite = Convert.ToInt32(employeRecord["capacite"]);
            matricule = employeRecord["matricule"].ToString();
            entreprise = employeRecord["entreprise"].ToString();
            loginemploye = employeRecord["loginemploye"].ToString();
            loginemployeur = employeRecord["loginemployeur"].ToString();
            mobile = Convert.ToInt32(employeRecord["mobile"]);
            adresse = employeRecord["adresse"].ToString();
            cuser = employeRecord["cuser"].ToString();
            uuser = employeRecord["uuser"].ToString();


        }
    }
}