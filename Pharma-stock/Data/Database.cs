using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Database
    {
        // Code issu de https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL  
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Database()
        {
            server = "localhost";
            database = "entrepot-pharmacie";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
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
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string reference, string nom, string description, Decimal prix_achat, Int32 code, Decimal marge, Decimal prix_revente, Int32 qteDispo)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd;

                //Execute command
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO articles(reference,nom,description,prix_achat,code_fournisseur,marge_benef,prix_revente,date_creation) VALUES(?referenceADonner,?nomADonner,?descriptionADonner,?prix_achatADonner,?codeADonner,?margeADonner,?prix_reventeADonner,NOW())";
                    cmd.Parameters.Add("?referenceADonner", MySqlDbType.VarChar).Value = reference;
                    cmd.Parameters.Add("?nomADonner", MySqlDbType.VarChar).Value = nom;
                    cmd.Parameters.Add("?descriptionADonner", MySqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("?prix_achatADonner", MySqlDbType.Decimal).Value = prix_achat;
                    cmd.Parameters.Add("?codeADonner", MySqlDbType.Int32).Value = code;
                    cmd.Parameters.Add("?margeADonner", MySqlDbType.Decimal).Value = marge;
                    cmd.Parameters.Add("?prix_reventeADonner", MySqlDbType.Decimal).Value = prix_revente;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO stock(refArticle,qteStock,idEntrepot) VALUES(?referenceADonner,?qteStockADonner,?idEntrepotADonner)";
                    cmd.Parameters.Add("?qteStockADonner", MySqlDbType.Int32).Value = qteDispo;
                    cmd.Parameters.Add("?idEntrepotADonner", MySqlDbType.Int32).Value = 1;
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
        }

        //Update statement
        public void Update()
        {
            //string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";
            string query = "UPDATE `article` SET `Description` = 'en argent et or' WHERE `article`.`Id` = 5";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd;/*
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO articles(reference,nom,description,prix_achat,code_fournisseur,marge_benef,prix_revente,date_creation) VALUES(?referenceADonner,?nomADonner,?descriptionADonner,?prix_achatADonner,?codeADonner,?margeADonner,?prix_reventeADonner,NOW())";
                    cmd.Parameters.Add("?referenceADonner", MySqlDbType.VarChar).Value = reference;
                    cmd.Parameters.Add("?nomADonner", MySqlDbType.VarChar).Value = nom;
                    cmd.Parameters.Add("?descriptionADonner", MySqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("?prix_achatADonner", MySqlDbType.Decimal).Value = prix_achat;
                    cmd.Parameters.Add("?codeADonner", MySqlDbType.Int32).Value = code;
                    cmd.Parameters.Add("?margeADonner", MySqlDbType.Decimal).Value = marge;
                    cmd.Parameters.Add("?prix_reventeADonner", MySqlDbType.Decimal).Value = prix_revente;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO stock(refArticle,qteStock,idEntrepot) VALUES(?referenceADonner,?qteStockADonner,?idEntrepotADonner)";
                    cmd.Parameters.Add("?qteStockADonner", MySqlDbType.Int32).Value = qteDispo;
                    cmd.Parameters.Add("?idEntrepotADonner", MySqlDbType.Int32).Value = 1;
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }*/
            }
        }

        //Delete statement
        public void Delete(string reference)
        {
            string query = "DELETE a, b FROM articles a INNER JOIN stock b WHERE b.refArticle = a.reference and a.reference = ?refADonner";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.Add("?refADonner", MySqlDbType.VarChar).Value = reference;
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }


        //Select statement
        public void Select()
        {
            string query = "SELECT reference,nom,description,prix_achat,marge_benef,qteStock FROM articles INNER JOIN stock ON articles.reference = stock.refArticle";

            string reference = "";
            string nom = "";
            string description = "";
            decimal prix_achat = 0m;
            decimal marge_benef = 0m;
            int qteStock = 0;


            if (this.OpenConnection() == true)
            {
                
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    reference = dataReader.GetString("reference");
                    nom = dataReader.GetString("nom");
                    description = dataReader.GetString("description");
                    prix_achat = dataReader.GetDecimal("prix_achat");
                    marge_benef = dataReader.GetDecimal("marge_benef");
                    qteStock = dataReader.GetInt16("qteStock");
                    Console.WriteLine("article " + reference + " " + nom + " " + description + " " + prix_achat + " " + marge_benef + " " + qteStock);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
            }
        }

        public void SelectArticles(string refInput)
        {
            string query = "SELECT reference,nom,description,prix_achat,marge_benef,qteStock FROM articles INNER JOIN stock ON articles.reference = stock.refArticle WHERE articles.reference = ?refADonner";

            string reference = "";
            string nom = "";
            string description = "";
            decimal prix_achat = 0m;
            decimal marge_benef = 0m;
            int qteStock = 0;


            if (this.OpenConnection() == true)
            {

                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                cmd.Parameters.Add("?refADonner", MySqlDbType.VarChar).Value = refInput;
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    reference = dataReader.GetString("reference");
                    nom = dataReader.GetString("nom");
                    description = dataReader.GetString("description");
                    prix_achat = dataReader.GetDecimal("prix_achat");
                    marge_benef = dataReader.GetDecimal("marge_benef");
                    qteStock = dataReader.GetInt16("qteStock");
                    
                }
                //close Data Reader
                Console.WriteLine("article " + reference + " " + nom + " " + description + " " + prix_achat + " " + marge_benef + " " + qteStock + "\n");
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                
            }
        }

        public void SelectArticle(string reference, Boolean isRef)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd;
                using (cmd = connection.CreateCommand())
                {
                    if (isRef == true)
                    {
                        cmd.CommandText = "SELECT reference,nom,description,prix_achat,marge_benef,qteStock FROM articles INNER JOIN stock ON articles.reference = stock.refArticle WHERE articles.reference LIKE ?refADonner ";
                        cmd.Parameters.AddWithValue("?refADonner", "%" + reference + "%");
                    }
                    else if (isRef == false)
                    {
                        cmd.CommandText = "SELECT reference,nom,description,prix_achat,marge_benef,qteStock FROM articles LEFT JOIN stock ON articles.reference = stock.refArticle WHERE articles.nom LIKE ?refADonner ";
                        cmd.Parameters.AddWithValue("?refADonner", "%" + reference + "%");
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0].ToString() +" "+ reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString() + "\n");
                            }
                        } else
                        {
                            Console.WriteLine("Article non trouvé\n");
                        }
                    }
                    this.CloseConnection();
                }
            }
        }
        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM article";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }


    }
}
