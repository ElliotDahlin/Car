using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DatabasProjekt1
{
    internal class CarDB
    {
        public static MySqlConnection GetConnection()
        {
           string server = "Library";
           string databas = "mydb";
           string dbUser = "root";
           string dbPass = "Dahlin12345!";
           string dbPort = "3306";
           string dbHost = "127.0.0.1";
           string connString = $"SERVER={server};DATABASE={databas};UID={dbUser};PASSWORD={dbPass};PORT={dbPort};HOST={dbHost};Allow User Variables=true";

            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySql Connection!" + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
            return conn;
        }
        //här kommer mina metoder för att lägga till updatera och ta bort från appen
        public static void AddCar(Car cr)
        {
            string connString = "INSERT INTO car (Brand, Model, Mileage, Cost, Phonenumber) VALUES (@Brand, @Model, @Mileage, @Cost, @Phonenumber)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(connString, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@Brand", MySqlDbType.VarChar).Value = cr.Brand;
            cmd.Parameters.Add("@Model", MySqlDbType.VarChar).Value = cr.Model;
            cmd.Parameters.Add("@Mileage", MySqlDbType.VarChar).Value = cr.Mileage;
            cmd.Parameters.Add("@Cost", MySqlDbType.VarChar).Value = cr.Cost;
            cmd.Parameters.Add("@Phonenumber", MySqlDbType.VarChar).Value = cr.Phonenumber;
            
            
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Car not inserted" + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

            public static void UpdateCar(Car cr, string id)
        {
            string connString = "UPDATE car SET Brand = @Brand, Model = @Model, Mileage = @Mileage, Cost = @Cost, Phonenumber = @Phonenumber  WHERE CarID = @CarID";
            MySqlConnection conn = GetConnection(); 
            MySqlCommand cmd = new MySqlCommand(connString, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@CarID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@Brand", MySqlDbType.VarChar).Value = cr.Brand;
            cmd.Parameters.Add("@Model", MySqlDbType.VarChar).Value = cr.Model;
            cmd.Parameters.Add("@Mileage", MySqlDbType.VarChar).Value = cr.Mileage;
            cmd.Parameters.Add("@Cost", MySqlDbType.VarChar).Value = cr.Cost;
            cmd.Parameters.Add("@Phonenumber", MySqlDbType.VarChar).Value = cr.Phonenumber;
            
           
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Car not inserted" + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();

        }

        public static void DeleteCar(string id)
        {
            string connString = " DELETE FROM car WHERE CarID = @CarID";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(connString, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@CarID", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Car not Deleted" + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();

        }
        //metod för att displaya infon till datagridden
        public static void DisplayAndSearch(string query, DataGridView datagrid)
        {
            string connstring = query;
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(connstring, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            datagrid.DataSource = tbl;
            conn.Close();
        }

        


    }


}
