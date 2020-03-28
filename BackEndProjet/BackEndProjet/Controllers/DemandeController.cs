using BackEndProjet.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Data;
using System.Web.Http.Cors;
using System.Linq;

namespace BackEndProjet.Controllers
{
    [EnableCors(origins: "*", headers: " *", methods: "*")]
    public class DemandeController : ApiController
    {
        /* [Route("api/Demande/{id}"), HttpGet]
         // GET: api/Employe/5
         public demande Get(int id)
         {

             string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
             SqlConnection con = new SqlConnection(connString);
             demande d = new demande();
             SqlDataReader reader;


             try
             {


                 con.Open();

                 string sql = "select *\n" + "from dbo.Demande\n where ID="+id;


                 using (var command = new SqlCommand(sql, con))
                 {
                     reader = command.ExecuteReader();
                     while (reader.Read())
                     {
                         d.id = int.Parse(reader[0].ToString());
                         d.id_employe = int.Parse(reader[1].ToString());

                         d.montant = int.Parse(reader[2].ToString());
                         d.statut = reader[5].ToString();




                     }

                 }
                 return d;
             }

             catch
             {
                 return new demande();
             }
             finally
             {
                 con.Close();
             }
         }*/


        /*[Route("api/Demande/{id_employe}"), HttpGet]
         // GET: api/Employe/5
         public SqlDataReader GetD(int id_employe)
         {

             string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
             SqlConnection con = new SqlConnection(connString);
             demande d = new demande();
             SqlDataReader reader;



                 con.Open();

                 string sql = "select Count(*)\n" + "from dbo.Demande\n where ID_EMPLOYE=" + id_employe;

             var command = new SqlCommand(sql, con);

             reader = command.ExecuteReader();
             return reader;



         }*/
       /* [Route("api/Demande/details/{ID_EMPLOYE}"), HttpGet]
        // GET: api/Employe/5
        public demande Get(int ID_EMPLOYE)
        {

            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            demande d = new demande();
            SqlDataReader reader;


            try
            {


                con.Open();

                string sql = "select *\n" + "from dbo.Demande\n where ID_EMPLOYE=" + ID_EMPLOYE;


                using (var command = new SqlCommand(sql, con))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        d.id = int.Parse(reader[0].ToString());
                        d.id_employe = int.Parse(reader[1].ToString());

                        d.montant = int.Parse(reader[2].ToString());
                        d.statut = reader[5].ToString();
                        d.date_demande = reader[7].ToString();



                    }

                }
                return d;
            }

            catch
            {
                return new demande();
            }
            finally
            {
                con.Close();
            }}*/
        
        [Route("api/Demande/details/{LOGIN}"), HttpGet]
        // GET: api/Employe/5
        public demande Getbylog(string LOGIN)
        {

            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            demande d = new demande();
            SqlDataReader reader;


            try
            {


                con.Open();

                string sql = "select *\n" + "from dbo.Demande\n where LOGIN=@LOGIN";


                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add("@LOGIN", LOGIN);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        d.id = int.Parse(reader[0].ToString());
                        d.id_employe = int.Parse(reader[1].ToString());

                        d.montant = int.Parse(reader[2].ToString());
                        d.statut = reader[5].ToString();
                        d.date_demande = reader[7].ToString();



                    }

                }
                return d;
            }

            catch
            {
                return new demande();
            }
            finally
            {
                con.Close();
            }
        }
        [Route("api/Demande/{id}"), HttpDelete]
        //// DELETE: api/Employe/5
        public string Delete(int id)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            demande d = new demande();
            SqlDataReader reader;
            string t;



            con.Open();

            string sql = "Delete \n" + "from dbo.Demande\n where ID=" + id;


            var command = new SqlCommand(sql, con);

            int res = command.ExecuteNonQuery();
            if (res > 0)
            {
                t = "true";
            }
            else
            {
                t = "false";
            }

            con.Close();
            return t;




        }
        /*[EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/Demande"), HttpGet]
        public IEnumerable<DEMANDE> GetDemandesl()
        {
            using (ProjetEntities1 enti = new ProjetEntities1())
            {
                return enti.DEMANDE.ToList();
            }
        }*/
        [Route("api/Demande/{LOGIN}"), HttpGet]
        public IEnumerable<demande> GetDemandesparemployee(string LOGIN)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Em = new Employe();
            SqlDataAdapter ad;
            con.Open();
            DataTable dt = new DataTable();
            string sql = "select *\n" + "from dbo.Demande\n where LOGIN=@LOGIN";
            SqlCommand ins = new SqlCommand(sql, con);
            ins.Parameters.Add("@LOGIN", LOGIN);
            ad = new SqlDataAdapter
            {
                SelectCommand = ins
        };
            ad.Fill(dt);
            List<demande> demandes = new List<demande>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow DemandeRecord in dt.Rows)
                {
                    demandes.Add(new demande(DemandeRecord));
                }
            }
            return demandes;
        }
        /*
         *      [Route("api/Demande/{LOGIN}"), HttpGet]
        public IEnumerable<demande> GetDemandes()
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Em = new Employe();
            SqlDataAdapter ad;
            con.Open();
            DataTable dt = new DataTable();
            string sql = "select *\n" + "from dbo.Demande\n";
            SqlCommand SelectCommand = new SqlCommand(sql, con);
            ad = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(sql, con)
        };
            ad.Fill(dt);
            List<demande> demandes = new List<demande>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow DemandeRecord in dt.Rows)
                {
                    demandes.Add(new demande(DemandeRecord));
                }
            }
            return demandes;
        }
         */
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/Demande"), HttpPost]
        public string Post([FromBody]demande e)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Em = new Employe();

            con.Open();

            string sql = "Insert \n" + "into dbo.Demande(ID,ID_EMPLOYE,MONTANT,MOTIF,DESCRIPTION,STATUT,LOGIN,DATE_DEMANDE,CDATE    )\n values(@ID,@ID_EMPLOYE,@MONTANT,@MOTIF,@DESCRIPTION,@STATUT,@LOGIN,getdate(),getdate())";


            SqlCommand ins = new SqlCommand(sql, con);
            ins.Parameters.Add("@ID", e.id);
            ins.Parameters.Add("@ID_EMPLOYE", e.id_employe);
            ins.Parameters.Add("@MONTANT", e.montant);
            ins.Parameters.Add("@MOTIF", e.motif);
            ins.Parameters.Add("@DESCRIPTION", e.description);

            ins.Parameters.Add("@STATUT", e.statut);
            ins.Parameters.Add("@LOGIN", e.login);

            int res = ins.ExecuteNonQuery();
            if (res > 0) { return "inserted"; }
            else { return "false"; }


        }

        [Route("api/Demande/{id}"), HttpPut]
        public string Put(int id,[FromBody]demande e)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Em = new Employe();

            con.Open();

            string sql = "update dbo.Demande\n" + "set ID=@ID,ID_EMPLOYE=@ID_EMPLOYE,MONTANT=@MONTANT,MOTIF=@MOTIF,STATUT=@STATUT\n where ID=" + id;


            SqlCommand ins = new SqlCommand(sql, con);
            ins.Parameters.AddWithValue("@ID", e.id);
            ins.Parameters.AddWithValue("@ID_EMPLOYE", e.id_employe);
            ins.Parameters.AddWithValue("@MONTANT", e.montant);
            ins.Parameters.AddWithValue("@MOTIF", e.motif);
            ins.Parameters.AddWithValue("@STATUT", e.statut);

            int res = ins.ExecuteNonQuery();
            if (res > 0) { return "updated"; }
            else { return "false"; }


        }


    }
}
