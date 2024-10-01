using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Dolgozat
{
    public class databaseHandler
    {
        MySqlConnection connection;
        string tablename = "pekaruk";
        public databaseHandler()
        {
            string username = "root";
            string password = "";
            string host = "localhost";
            string dbname = "pékáru";
            string connectionstring = $"user={username}; password={password};host={host};database={dbname}";
            connection = new MySqlConnection(connectionstring);
        }
        public void readAll()
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tablename}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    int id = read.GetInt32(read.GetOrdinal("id"));
                    string name = read.GetString(read.GetOrdinal("name"));
                    int amount = read.GetInt32(read.GetOrdinal("amount"));
                    int price = read.GetInt32(read.GetOrdinal("price"));
                    pekaru onePek = new pekaru();
                    onePek.id = id;
                    onePek.name = name;
                    onePek.amount = amount;
                    onePek.price = price;
                    pekaru.pekaruk.Add(onePek);
                }
                read.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error:");
                
            }
        }
        public void add(pekaru onePek)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO {tablename} (name,amount,price) VALUES ('{onePek.name}',{onePek.amount},{onePek.price})";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error:"); ;
            }
        }
        public void deleteOne(pekaru onePek)
        {
            try
            {
                connection.Open();
                string query = $"Delete  FROM {tablename} WHERE id = {onePek.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                pekaru.pekaruk.Remove(onePek);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error:");
            }
        }

    }
}
