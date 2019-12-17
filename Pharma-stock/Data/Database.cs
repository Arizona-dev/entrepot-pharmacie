using entrepot_pharmacie;
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
        public void CreerArticle(Article article, int idEntrepot)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd;
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO articles(reference,nom,description,prix_achat,idFournisseur,marge_benef,prix_revente,date_creation) VALUES(?referenceADonner,?nomADonner,?descriptionADonner,?prix_achatADonner,?codeADonner,?margeADonner,?prix_reventeADonner,NOW())";
                    cmd.Parameters.Add("?referenceADonner", MySqlDbType.VarChar).Value = article.Reference;
                    cmd.Parameters.Add("?nomADonner", MySqlDbType.VarChar).Value = article.Nom;
                    cmd.Parameters.Add("?descriptionADonner", MySqlDbType.VarChar).Value = article.Description;
                    cmd.Parameters.Add("?prix_achatADonner", MySqlDbType.Decimal).Value = article.Prix_achat;
                    cmd.Parameters.Add("?codeADonner", MySqlDbType.Int32).Value = article.Code_fournisseur;
                    cmd.Parameters.Add("?margeADonner", MySqlDbType.Decimal).Value = article.Marge_benef;
                    cmd.Parameters.Add("?prix_reventeADonner", MySqlDbType.Decimal).Value = article.Prix_achat + article.Marge_benef;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO stock(Articles_reference,qteStock,idEntrepot,date_creation, date_modification) VALUES(?referenceADonner,?qteStockADonner,?idEntrepotADonner,NOW(),NOW())";
                    cmd.Parameters.Add("?qteStockADonner", MySqlDbType.Int32).Value = article.QuantiteStock;
                    cmd.Parameters.Add("?idEntrepotADonner", MySqlDbType.Int32).Value = 1;
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
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
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd;
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE a, b FROM articles a INNER JOIN stock b WHERE b.refArticle = a.reference and a.reference = ?refADonner";
                    cmd.Parameters.Add("?refADonner", MySqlDbType.VarChar).Value = reference;
                    int ligneSupp = cmd.ExecuteNonQuery();
                    if (ligneSupp >= 1)
                    {
                        Console.WriteLine("Articles supprimé avec succès : " + ligneSupp + "\n");
                    } else if (ligneSupp == 0)
                    {
                        Console.WriteLine("Auncu article trouvé avec cette référence produit\n");
                    }
                    
                }
                this.CloseConnection();
            }
        }

        // Si l'entrepot existe return True sinon False
        public bool SelectEntrepotExist(int entrepot)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd;
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT idEntrepot FROM entrepot WHERE entrepot.idEntrepot = ?entrepot";
                    cmd.Parameters.Add("?entrepot", MySqlDbType.Int32).Value = entrepot;
                    using (var reader = cmd.ExecuteReader())
                    {
                        return LigneExist(reader);
                    }
                }
            }
            return false;
        }

        // Si le code fournisseur existe return True sinon False
        public bool SelectFournisseurExist(int fournisseur)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd;
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT idFournisseurs FROM fournisseurs WHERE fournisseurs.idFournisseurs = ?idFournisseur";
                    cmd.Parameters.Add("?idFournisseur", MySqlDbType.Int32).Value = fournisseur;
                    using (var reader = cmd.ExecuteReader())
                    {
                        return LigneExist(reader);
                    }
                }
            }
            return false;
        }

        // Si la référence d'article existe return True sinon False
        public bool SelectReferenceExist(string reference)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd;
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT reference FROM articles INNER JOIN stock ON articles.reference = stock.idArticle WHERE articles.reference = ?reference";
                    cmd.Parameters.Add("?reference", MySqlDbType.VarChar).Value = reference;
                    using (var reader = cmd.ExecuteReader())
                    {
                        return LigneExist(reader);
                    }
                }
            }
            return false;
        }

        // Select articles list
        public void Select()
        {   
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd;
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT reference,nom,description,prix_achat,marge_benef,qteStock,idFournisseur,idEntrepot FROM articles INNER JOIN stock ON articles.reference = stock.idArticle WHERE articles.reference";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString() + reader[6].ToString() + "\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Articles non trouvé\n");
                        }
                        reader.Close();
                    }
                }
                this.CloseConnection();
            }
        }


        // Selectionner un article par sa référence
        public Article SelectArticleParReference(string reference)
        {
            Article article = null;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd;
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT reference,nom,description,prix_achat,marge_benef,qteStock,idFournisseur FROM articles INNER JOIN stock ON articles.reference = stock.idArticle WHERE articles.reference = ?reference";
                    cmd.Parameters.Add("?reference", MySqlDbType.VarChar).Value = reference;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string refArticle = reader[0].ToString();
                                string nom = reader[1].ToString();
                                string description = reader[2].ToString();
                                decimal prixAchat = Decimal.Parse(reader[3].ToString());
                                decimal marge = Decimal.Parse(reader[4].ToString());
                                int qteStock = Int32.Parse(reader[5].ToString());
                                int code = Int32.Parse(reader[6].ToString());
                                article = new Article(nom, refArticle, description, prixAchat, marge, code, qteStock);
                                
                            }
                            reader.Close();
                            this.CloseConnection();
                            return article;
                        } else
                        {
                            Console.WriteLine("Article non trouvé\n");
                            reader.Close();
                            this.CloseConnection();
                            return null;
                        }
                    }
                }
            }
            return null;
        }
        // Selectionner un article par son Nom
        public Article SelectArticleParNom(string nomArticle)
        {
            Article article = null;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd;
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT reference,nom,description,prix_achat,marge_benef,qteStock,idFournisseur FROM articles LEFT JOIN stock ON articles.reference = stock.idArticle WHERE articles.nom = ?nomArticle ";
                    cmd.Parameters.Add("?nomArticle", MySqlDbType.VarChar).Value = nomArticle;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string refArticle = reader[0].ToString();
                                string nom = reader[1].ToString();
                                string description = reader[2].ToString();
                                decimal prixAchat = Decimal.Parse(reader[3].ToString());
                                decimal marge = Decimal.Parse(reader[4].ToString());
                                int qteStock = Int32.Parse(reader[5].ToString());
                                int code = Int32.Parse(reader[6].ToString());
                                article = new Article(nom, refArticle, description, prixAchat, marge, code, qteStock);
                            }
                            reader.Close();
                            this.CloseConnection();
                            return article;
                        }
                        else
                        {
                            Console.WriteLine("Article non trouvé\n");
                            reader.Close();
                            this.CloseConnection();
                            return null;
                        }
                    }
                }
            }
            return null;
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

        private bool LigneExist(MySqlDataReader reader)
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Console.WriteLine("Article trouvé\n");
                }
                reader.Close();
                this.CloseConnection();
                return true;
            }
            else
            {
                //Console.WriteLine("Article non trouvé\n");
                reader.Close();
                this.CloseConnection();
                return false;
            }
        }

    }
}
