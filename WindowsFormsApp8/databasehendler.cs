using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    class databasehendler
    {
        MySqlConnection connection;
        string table = "pekseg";
        

        public databasehendler() {
            string host = "localhost";
            string password = "";
            string username = "root";
            string dbname = "doga";
            string connectionstring = $"user={username};password={password};host={host};database={dbname}";
            connection = new MySqlConnection(connectionstring);

        }
        public void readdb() {

            try
            {
                connection.Open();
                string query = $"select * from pekseg";
                MySqlCommand command = new MySqlCommand(query,connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    bakery onefood = new bakery();
                    onefood.id = read.GetInt32(read.GetOrdinal("id"));
                    onefood.name = read.GetString(read.GetOrdinal("nev"));
                    onefood.amount = read.GetInt32(read.GetOrdinal("mennyiseg"));
                    onefood.price = read.GetInt32(read.GetOrdinal("ar"));
                    bakery.products.Add(onefood);
                    
                }
                read.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void writedb(bakery oneproduct) {
            try
            {
                connection.Open();
                string query = $"insert into pekseg (nev,mennyiseg,ar)values('{oneproduct.name}','{oneproduct.amount}','{oneproduct.price}')";
                MySqlCommand command = new MySqlCommand(query,connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

            }
            catch (Exception e)
            {

                MessageBox.Show(e+"");
            }
        }
        public void deletdb(bakery onproduct) {
            try
            {
                connection.Open();
                string query = $"delete from pekseg where id = {onproduct.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                bakery.products.Remove(onproduct);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        
    }
}
