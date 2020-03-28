using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace BackEndProjet.Controllers
{
    public class ChartController : Controller
    {

        [Route("api/Chart"), HttpGet]
        protected void Page_Load(object sender, EventArgs e)
        {
                ShowData();
        }

        private void ShowData()
        {
            string connString = @"Data Source=DESKTOP-OLSE3HJ\SQLEXPRESS01;Initial Catalog=Projet;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader;
            SqlDataAdapter ad;
            String query = "Select nom,prenom from dbo.Employe Where NBABSENCE>0 order by id desc";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable tb = new DataTable();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                tb.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
            }
            catch { }

            if (tb != null)
            {
                String chart = "";
                chart = "<canvas id=\"line-chart\" width=\"100%\" height=\"40\"></canvas>";
                chart += "<script>";
                chart += "new Chart(document.getElementById(\"line-chart\"), { type: 'line', data: {labels: [";

                // more detais
                for (int i = 0; i < 50; i++)
                    chart += i.ToString() + ",";
                chart = chart.Substring(0, chart.Length - 1);

                chart += "],datasets: [{ data: [";

                // get data from database and add to chart
                String value = "";
                for (int i = 0; i < tb.Rows.Count; i++)
                    value += tb.Rows[i]["NhietDo"].ToString() + ",";
                value = value.Substring(0, value.Length - 1);
                chart += value;

                chart += "],label: \"Air Temperature\",borderColor: \"#3e95cd\",fill: true}"; // Chart color
                chart += "]},options: { title: { display: true,text: 'Air Temperature (oC)'} }"; // Chart title
                chart += "});";
                chart += "</script>";

            }
        }

    }
}