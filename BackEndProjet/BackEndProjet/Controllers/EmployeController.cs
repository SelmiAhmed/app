using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Http.Cors;

using System.Data.SqlClient;
using BackEndProjet.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackEndProjet.Controllers
{

[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeController : ApiController
        {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/Employes/"), HttpGet]
         public IEnumerable<Employe> GetEmployes()
         {
             string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
             SqlConnection con = new SqlConnection(connString);
             Employe Em = new Employe();
             SqlDataAdapter ad;
             con.Open();
             DataTable dt = new DataTable();
             string sql = "select *\n" + "from dbo.Employe\n";
             ad = new SqlDataAdapter {
                  SelectCommand = new SqlCommand(sql, con)
             };
             ad.Fill(dt);
             List<Employe> employes = new List<Employe>(dt.Rows.Count);
             if (dt.Rows.Count > 0) { foreach(DataRow EmployeRecord in dt.Rows)
                 {
                     employes.Add(new Employe(EmployeRecord));
                 } }
             return employes;
         }
         
        public int VerifID(int id)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Em = new Employe();
            SqlDataAdapter ad;
            con.Open();
            DataTable dt = new DataTable();
            string sql = "select id\n" + "from dbo.Employe\n where ID="+id;
            SqlCommand ins = new SqlCommand(sql, con);
            ad = new SqlDataAdapter
            {
                SelectCommand = ins

        };
            ad.Fill(dt);
            List<Employe> employes = new List<Employe>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /*[Route("api/Employe/{loginemploye}/{matricule}"), HttpGet]*/
        public int Veriflog(string loginemploye)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Em = new Employe();
            SqlDataAdapter ad;
            con.Open();
            DataTable dt = new DataTable();
            string sql = "select loginemploye\n" + "from dbo.Employe\n where LOGINEMPLOYE=@LOGINEMPLOYE ";
            SqlCommand ins = new SqlCommand(sql, con);
            ins.Parameters.Add("@LOGINEMPLOYE", loginemploye);

            ad = new SqlDataAdapter
            {
                SelectCommand = ins

            };
            ad.Fill(dt);
            List<Employe> employes = new List<Employe>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int VerifMat( string matricule)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Em = new Employe();
            SqlDataAdapter ad;
            con.Open();
            DataTable dt = new DataTable();
            string sql = "select *\n" + "from dbo.Employe\n where matricule=@matricule";
            SqlCommand ins = new SqlCommand(sql, con);
            ins.Parameters.Add("@matricule",matricule);
            ad = new SqlDataAdapter
            {
                SelectCommand = ins

            };
            ad.Fill(dt);
            List<Employe> employes = new List<Employe>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

         [Route("api/Employe/details/{loginemploye}/{matricule}/"),HttpPost]
         public int GetBy(string loginemploye,string matricule)
         {
             string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
             SqlConnection con = new SqlConnection(connString);
             Employe Em = new Employe();
             SqlDataAdapter ad;
             con.Open();
             DataTable dt = new DataTable();
             string sql = "select loginemploye,MATRICULE\n" + "from dbo.Employe\n where loginemploye=@loginemploye and MATRICULE=@MATRICULE ";
             SqlCommand ins = new SqlCommand(sql, con);
             ins.Parameters.Add("@loginemploye", loginemploye);
             ins.Parameters.Add("@MATRICULE", matricule);
             ad = new SqlDataAdapter
             {
                 SelectCommand = ins

             };
             ad.Fill(dt);
             List<Employe> employes = new List<Employe>(dt.Rows.Count);
             if (dt.Rows.Count > 0)
             {
                 return 1;
             }
             else
             {
                 return 0;
             }
         }
        [AcceptVerbs("GET", "POST", "PUT", "DELETE")]
        [Route("api/Employe/{loginemploye}/{matricule}"), HttpGet]
        public int GET(string loginemploye, string matricule)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Em = new Employe();
            SqlDataAdapter ad;
            con.Open();
            DataTable dt = new DataTable();
            string sql = "select loginemploye,MATRICULE\n" + "from dbo.Employe\n where loginemploye=@loginemploye and MATRICULE=@MATRICULE ";
            SqlCommand ins = new SqlCommand(sql, con);
            ins.Parameters.Add("@loginemploye", loginemploye);
            ins.Parameters.Add("@MATRICULE", matricule);
            ad = new SqlDataAdapter
            {
                SelectCommand = ins

            };
            ad.Fill(dt);
            List<Employe> employes = new List<Employe>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int VerifCarte(long numcarte)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Em = new Employe();
            SqlDataAdapter ad;
            con.Open();
            DataTable dt = new DataTable();
            string sql = "select numcarte\n" + "from dbo.Employe\n where NUMCARTE=@NUMCARTE";
            SqlCommand ins = new SqlCommand(sql, con);
            ins.Parameters.Add("@NUMCARTE", numcarte);
            ad = new SqlDataAdapter
            {
                SelectCommand = ins

            };
            ad.Fill(dt);
            List<Employe> employes = new List<Employe>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int VerifTel(int mobile)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Em = new Employe();
            SqlDataAdapter ad;
            con.Open();
            DataTable dt = new DataTable();
            string sql = "select mobile\n" + "from dbo.Employe\n where MOBILE=@MOBILE";
            SqlCommand ins = new SqlCommand(sql, con);
            ins.Parameters.Add("@MOBILE", mobile);
            ad = new SqlDataAdapter
            {
                SelectCommand = ins

            };
            ad.Fill(dt);
            List<Employe> employes = new List<Employe>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        /*[Route("api/Employe/details/{loginemploye}/{matricule}/"), HttpPost]
  // GET: api/Employe/5
  public Employe Get2(string loginemploye,string matricule)
  {

      string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
      SqlConnection con = new SqlConnection(connString);
      Employe Emp = new Employe();
      SqlDataReader reader;
      DataTable dt = new DataTable();


      try
      {


          con.Open();

          string sql = "select *\n" + "from dbo.Employe\n where LOGINEMPLOYE=@loginemploye and MATRICULE=@MATRICULE";


          using (var command = new SqlCommand(sql, con))
          {
              command.Parameters.Add("@loginemploye", loginemploye);
              command.Parameters.Add("@MATRICULE", matricule);

                    reader = command.ExecuteReader();
              while (reader.Read())
              {
                        Emp.id = int.Parse(reader[0].ToString());
                        Emp.nom = reader[1].ToString();
                        Emp.prenom = reader[2].ToString();
                        Emp.numcarte = long.Parse(reader[3].ToString());
                        Emp.salaire = int.Parse(reader[4].ToString());
                        Emp.capacite = int.Parse(reader[5].ToString());
                        Emp.nbabsence = int.Parse(reader[6].ToString());

                        Emp.matricule = reader[7].ToString();
                        Emp.entreprise = reader[8].ToString();
                        Emp.loginemploye = reader[9].ToString();
                        Emp.loginemployeur = reader[10].ToString();
                        Emp.mobile = int.Parse(reader[11].ToString());
                        Emp.adresse = reader[12].ToString();
                        Emp.email = reader[13].ToString();

                        Emp.cdate = reader[14].ToString();

                        Emp.cuser = reader[15].ToString();
                        Emp.uuser = reader[16].ToString();
                        Emp.udate = reader[17].ToString();






                    }

                }
          return Emp;
      }

      catch
      {
          return new Employe();
      }
      finally
      {
          con.Close();
      }
  }*/
       [ActionName("Login")]
        [Route("api/Employe/login/{loginemploye}/"), HttpGet]
        // GET: api/Employe/5
        public Employe GetBYlogin(string loginemploye)
        {

            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Emp = new Employe();
            SqlDataReader reader;
            DataTable dt = new DataTable();


            try
            {


                con.Open();

                string sql = "select *\n" + "from dbo.Employe\n where LOGINEMPLOYE=@loginemploye";


                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add("@loginemploye", loginemploye);

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Emp.id = int.Parse(reader[0].ToString());
                        Emp.nom = reader[1].ToString();
                        Emp.prenom = reader[2].ToString();
                        Emp.numcarte = long.Parse(reader[3].ToString());
                        Emp.salaire = int.Parse(reader[4].ToString());
                        Emp.capacite = int.Parse(reader[5].ToString());
                        Emp.nbabsence = int.Parse(reader[6].ToString());

                        Emp.matricule = reader[7].ToString();
                        Emp.entreprise = reader[8].ToString();
                        Emp.loginemploye = reader[9].ToString();
                        Emp.loginemployeur = reader[10].ToString();
                        Emp.mobile = int.Parse(reader[11].ToString());
                        Emp.adresse = reader[12].ToString();
                        Emp.email = reader[13].ToString();

                        Emp.cdate = reader[14].ToString();

                        Emp.cuser = reader[15].ToString();
                        Emp.uuser = reader[16].ToString();
                        Emp.udate = reader[17].ToString();






                    }

                }
                return Emp;
            }

            catch
            {
                return new Employe();
            }
            finally
            {
                con.Close();
            }
        }
        


        /* [Route("api/Employe/{id}"),HttpGet]
           public Employe GetByID(int id)
           {
               //    return "value";
               string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
               SqlConnection con = new SqlConnection(connString);
               SqlDataReader reader;
              SqlDataAdapter ad;
              Employe Emp= new Employe() ;

              try
              {


                   con.Open();

                  string sql = "select *\n" + "from dbo.Employe\n where ID="+id;

                   using (var command = new SqlCommand(sql, con))
                   {
                       reader = command.ExecuteReader();

                       while (reader.Read())
                       {
                          Emp.id = int.Parse(reader[0].ToString());
                           Emp.nom = reader[1].ToString();
                            Emp.prenom = reader[2].ToString();
                           Emp.numcarte = long.Parse(reader[3].ToString());
                          Emp.salaire = int.Parse(reader[4].ToString());
                          Emp.capacite = int.Parse(reader[5].ToString());
                        Emp.nbabsence = int.Parse(reader[6].ToString());

                          Emp.matricule = reader[7].ToString();
                           Emp.entreprise = reader[8].ToString();
                           Emp.loginemploye = reader[9].ToString();
                           Emp.loginemployeur = reader[10].ToString();
                           Emp.mobile = int.Parse(reader[11].ToString());
                          Emp.adresse = reader[12].ToString();
                          Emp.email = reader[13].ToString();

                          Emp.cdate = reader[14].ToString();

                          Emp.cuser = reader[15].ToString();
                           Emp.uuser = reader[16].ToString();
                          Emp.udate = reader[17].ToString();


                      }

                  }

                   return Emp;
               }
             catch
               {
                   return new Employe();
               }
               finally
               {
                   con.Close();
               }
           }
           */

        [Route("api/Employe"), HttpPost]
        // POST: api/Employe
        public string Post([FromBody]Employe e)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);

            con.Open();


            string sql = "Insert \n" + "into dbo.Employe(ID,NOM,PRENOM,NUMCARTE,SALAIRE,CAPACITE,NBABSENCE,MATRICULE,ENTREPRISE,LOGINEMPLOYE,LOGINEMPLOYEUR,MOBILE,ADRESSE,EMAIL,CDATE)\n values(@ID,@NOM,@PRENOM,@NUMCARTE,@SALAIRE,@SALAIRE*0.4,@NBABSENCE,@MATRICULE,@ENTREPRISE,@LOGINEMPLOYE,@LOGINEMPLOYEUR,@MOBILE,@ADRESSE,@EMAIL,getdate())";

            if ((VerifID(e.id) == 0)&& (VerifTel(e.mobile) == 0) && (VerifMat(e.matricule) == 0) && (Veriflog(e.loginemploye) == 0) && (VerifCarte(e.numcarte)==0) && ((e.numcarte.ToString().Length == 16)) && ((e.mobile.ToString().Length == 8)) && ((e.salaire>300)))
            {
                SqlCommand ins = new SqlCommand(sql, con);

                ins.Parameters.Add("@ID", e.id);
                ins.Parameters.Add("@NOM", e.nom);
                ins.Parameters.Add("@PRENOM", e.prenom);

                    ins.Parameters.Add("@NUMCARTE", e.numcarte); 

                 ins.Parameters.Add("@SALAIRE", e.salaire); 
                ins.Parameters.Add("@NBABSENCE", e.nbabsence);
                ins.Parameters.Add("@CAPACITE", e.capacite);
                ins.Parameters.Add("@ENTREPRISE", e.entreprise);
                ins.Parameters.Add("@MATRICULE", e.matricule);
               ins.Parameters.Add("@LOGINEMPLOYE", e.loginemploye);
                ins.Parameters.Add("@LOGINEMPLOYEUR", e.loginemployeur);
                ins.Parameters.Add("@MOBILE", e.mobile); 
                ins.Parameters.Add("@ADRESSE", e.adresse);
                ins.Parameters.Add("@EMAIL", e.email);

                var res = ins.ExecuteNonQuery();
                if (res > 0) { return "inserted"; }
                else { return "false"; }
            }
            else {
                
                if (VerifID(e.id) == 1) { return "id existant"; };
                if (Veriflog(e.loginemploye) == 1) { return "login existant"; };
                if (VerifCarte(e.numcarte) == 1) { return "NumCarte existant"; };
                if (VerifTel(e.mobile) == 1) { return "Mobile existant"; };
                if (VerifMat(e.matricule) == 1) { return "Matricule existant"; };

                if ((e.numcarte.ToString().Length) != 16) { return "NumCarte doit etre 16 chiffres"; };
                if ((e.mobile.ToString().Length) != 8) { return "Mobile doit etre 8 chiffres"; };
                if ((e.salaire <300)) { return "Salaire doit etre superieur à 300"; };

                return "erreur";

            }
        }

        //// PUT: api/Employe/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        [Route("api/Employe/{id}"), HttpDelete]
        //// DELETE: api/Employe/5
        public string Delete (int id)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe Em = new Employe();
            SqlDataReader reader;
            string t;

           

                con.Open();

                string sql = "Delete \n" + "from dbo.Employe\n where ID=" + id;


                var command = new SqlCommand(sql, con);
                
                int res = command.ExecuteNonQuery();
                    if (res > 0)
                    {
                        t = "Supprime";
                    }
                    else
                    {
                        t = "Employee non existant";
                    }

                con.Close();
                return t;
            


         
        }
        /*[Route("api/Employe/{id}"), HttpPut]
        public string Update(int id)
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            Employe e = new Employe();
            SqlDataReader reader;
            string t;



            con.Open();

            string sql = "Update dbo.Employe \n" + "Set NOM=@NOM,PRENOM=@PRENOM,NUMCARTE=@NUMCARTE,SALAIRE=@SALAIRE,NBABSENCE=@NBABSENCE,CAPACITE=@CAPACITE,ENTREPRISE=@ENTREPRISE,MATRICULE=@MATRICULE,LOGINEMPLOYE=@LOGINEMPLOYE,LOGINEMPLOYEUR=@LOGINEMPLOYEUR,MOBILE=@MOBILE,ADRESSE=@ADRESSE,EMAIL=@EMAIL\n where ID=" + id;


            var ins = new SqlCommand(sql, con);
            ins.Parameters.Add("@ID", e.id);
            ins.Parameters.Add("@NOM", e.nom);
            ins.Parameters.Add("@PRENOM", e.prenom);

            ins.Parameters.Add("@NUMCARTE", e.numcarte);

            ins.Parameters.Add("@SALAIRE", e.salaire);
            ins.Parameters.Add("@NBABSENCE", e.nbabsence);
            ins.Parameters.Add("@CAPACITE", e.capacite);
            ins.Parameters.Add("@ENTREPRISE", e.entreprise);
            ins.Parameters.Add("@MATRICULE", e.matricule);
            ins.Parameters.Add("@LOGINEMPLOYE", e.loginemploye);
            ins.Parameters.Add("@LOGINEMPLOYEUR", e.loginemployeur);
            ins.Parameters.Add("@MOBILE", e.mobile);
            ins.Parameters.Add("@ADRESSE", e.adresse);
            ins.Parameters.Add("@EMAIL", e.email);
            int res = ins.ExecuteNonQuery();
            if (res > 0)
            {
                t = "Updated";
            }
            else
            {
                t = "Employee non existant";
            }

            con.Close();
            return t;




        }*/










    }











}














        












    

