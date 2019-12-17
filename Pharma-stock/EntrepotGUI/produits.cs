using System;
using System.Data;
using System.Windows.Forms;
using Data MySql.Data.MySqlClient;
using Data.Database;

namespace EntrepotGUI
{
    public partial class produits : Form
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        private MySqlConnection connection;

        public produits()
        {
            InitializeComponent();
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }
        private void produits_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "entrepot-pharmacie";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter("select * from composers", connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];

                //close connection
                this.CloseConnection();
            }
        }

        private void BtnEditProduit_Click(object sender, EventArgs e)
        {
            EditerProduit frm = new EditerProduit();
            frm.Show();

        }
    }
}
