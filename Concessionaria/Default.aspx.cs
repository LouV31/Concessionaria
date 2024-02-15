using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Concessionaria
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["concessionariaDb"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "SELECT idAuto, Modello FROM Auto";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = reader["Modello"].ToString();
                    item.Value = reader["idAuto"].ToString();

                    ddlExample.Items.Add(item);



                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: ");
                Response.Write(ex.Message);
            }
            finally { conn.Close(); }
        }



        protected void sleziona_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["concessionariaDb"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string selectedValue = ddlExample.SelectedValue;
            if (selectedValue != null)
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT * FROM Auto WHERE idAuto =  '{selectedValue}' ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        immagine.ImageUrl = reader["Immagine"].ToString();
                        modello.InnerHtml = $"Modello: {reader["Modello"].ToString()}";
                        prezzo.InnerHtml = $"Prezzo: {reader["PrezzoBase"].ToString()}";


                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error: ");
                    Response.Write(ex.Message);
                }
                finally { conn.Close(); }
            }
        }

        protected void prezzoFinale_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["concessionariaDb"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string selectedValue = ddlExample.SelectedValue;
            Response.Write(selectedValue);


            try
            {
                conn.Open();
                string query = $"SELECT PrezzoBase, CerchiInLega, Vernice, Climatizzatore, DoppioAirBag, ABS, PrezzoGaranzia FROM Auto WHERE idAuto =  '{selectedValue}' ";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                double prezzoBase = Convert.ToDouble(reader["PrezzoBase"]);
                double prezzoGaranzia = 120;
                double garanziaSelezionata = Convert.ToInt32(garanzia.SelectedValue);
                double prezzoFinale = prezzoBase + (prezzoGaranzia * garanziaSelezionata);
                while (reader.Read())
                {
                    Response.Write(reader["CerchiInLega"]);
                    if (cerchiInLega.Checked)
                    {
                        prezzoFinale += Convert.ToDouble(reader["CerchiInLega"]);
                    }
                    if (vernice.Checked)
                    {
                        prezzoFinale += Convert.ToDouble(reader["Vernice"]);
                    }
                    if (climatizzatore.Checked)
                    {
                        prezzoFinale += Convert.ToDouble(reader["Climatizzatore"]);
                    }
                    if (airbag.Checked)
                    {
                        prezzoFinale += Convert.ToDouble(reader["DoppioAirBag"]);
                    }
                    if (abs.Checked)
                    {
                        prezzoFinale += Convert.ToDouble(reader["ABS"]);
                    }



                }
                mostraPrezzoFinale.InnerText = Convert.ToString(prezzoFinale);
            }
            catch (Exception ex)
            {
                Response.Write("Error: ");
                Response.Write(ex.Message);
            }
            finally { conn.Close(); }

        }
    }
}
