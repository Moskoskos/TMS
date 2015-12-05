using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using System.Configuration;

namespace TMS
{
    class DbConnect
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public DbConnect()
        {
            server = "127.0.0.1"; //IP-addressen til databasen. 
            database = "cts"; // Navnet til databasen som skal kobles til.
            uid = "root"; //Brukernavnet for å få logget seg på databasen,
            password = ""; //Passordet som blir brukt i samsvar med brukernavnet.
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }
        public DbConnect(string serverIP, string databaseName, string uid, string password)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["ctsConnectionString"].ConnectionString = "Data Source=" + serverIP + ";" + "Initial Catalog=blah;UID=blah;password=blah";
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        public bool OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Close();
                    connection.Open();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        public bool CloseConnection()
        {

            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
    }
}
