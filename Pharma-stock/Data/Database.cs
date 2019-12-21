using entrepot_pharmacie;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        private MySqlDataAdapter mySqlDataAdapter;

        public Database()
        {
            server = "localhost";
            database = "entrepot-pharmacie";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
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
        public bool CloseConnection()
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
                using (MySqlCommand cmd = connection.CreateCommand())
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
                    cmd.CommandText = "INSERT INTO stock(idArticle,qteStock,idEntrepot,date_creation, date_modification) VALUES(?referenceADonner,?qteStockADonner,?idEntrepotADonner,NOW(),NOW())";
                    cmd.Parameters.Add("?qteStockADonner", MySqlDbType.Int32).Value = article.QuantiteStock;
                    cmd.Parameters.Add("?idEntrepotADonner", MySqlDbType.Int32).Value = idEntrepot;
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
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT reference FROM articles WHERE articles.reference = ?reference";
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
                using (MySqlCommand cmd = connection.CreateCommand())
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
                                decimal prixAchat = decimal.Parse(reader[3].ToString());
                                decimal marge = decimal.Parse(reader[4].ToString());
                                int qteStock = int.Parse(reader[5].ToString());
                                int code = int.Parse(reader[6].ToString());
                                article = new Article(nom, refArticle, description, prixAchat, marge, code, qteStock, 0);
                                
                            }
                            reader.Close();
                            this.CloseConnection();
                            return article;
                        } else
                        {
                            Console.WriteLine("Article non trouvé\n");
                            Console.ReadLine();
                            reader.Close();
                            this.CloseConnection();
                            return article;
                        }
                    }
                }
            }
            return article;
        }
        // Selectionner un article par son Nom
        public Article SelectArticleParNom(string nomArticle)
        {
            Article article = null;
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = connection.CreateCommand())
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
                                decimal prixAchat = decimal.Parse(reader[3].ToString());
                                decimal marge = decimal.Parse(reader[4].ToString());
                                int qteStock = int.Parse(reader[5].ToString());
                                int code = int.Parse(reader[6].ToString());
                                article = new Article(nom, refArticle, description, prixAchat, marge, code, qteStock, 0);
                            }
                            reader.Close();
                            this.CloseConnection();
                            return article;
                        }
                        else
                        {
                            Console.WriteLine("Article non trouvé\n");
                            Console.ReadLine();
                            reader.Close();
                            this.CloseConnection();
                            return article;
                        }
                    }
                }
            }
            return article;
        }

        private bool LigneExist(MySqlDataReader reader)
        {
            if (reader.HasRows)
            {
                reader.Close();
                this.CloseConnection();
                return true;
            }
            else
            {
                reader.Close();
                this.CloseConnection();
                return false;
            }
        }

        public DataSet SelectProduit()
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd;
                using (cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select * articles";
                    mySqlDataAdapter = new MySqlDataAdapter(cmd.CommandText, connection);
                    DataSet DS = new DataSet();
                    mySqlDataAdapter.Fill(DS);
                    //close connection
                    CloseConnection();
                    return DS;
                }
            }
            return null;
        }

        public decimal TotalCommande(List<Article> listArticle)
        {
            decimal totalCommande = 0;
            foreach (Article article in listArticle)
            {
                totalCommande += article.QuantiteCommande * (article.Prix_achat + article.Marge_benef);
            }
            return totalCommande;
        }

        public void InsertCommandeVente(List<Article> listArticle)
        {
            int idCommande = CreateIdCommande() + 1;

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO `commandesventes`(`Caisse_idCaisse`, `Clients_idClients`, `date_achat`, `TotalCommande`) VALUES (1, 1, NOW(), ?TotalCommande)";
                    cmd.Parameters.Add("?TotalCommande", MySqlDbType.Decimal).Value = TotalCommande(listArticle);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    InsertLigneCommandeVente(listArticle, idCommande);
                }
            }
            
        }

        public void InsertLigneCommandeVente(List<Article> listArticle, int idCommande)
        {
            if (this.OpenConnection() == true)
            {
                foreach (Article article in listArticle)
                {
                    using (MySqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO `lignecommandes`(`idCommande`, `article`, `poste`, `dateVente`, `typeCommande`, `quantite`, `prixttc`) VALUES (?idCommande, ?nomArticle, ?idCaisse, NOW(), 1, ?qte, ?TotalCommande)";
                        cmd.Parameters.Add("?idCommande", MySqlDbType.Int32).Value = idCommande;
                        cmd.Parameters.Add("?nomArticle", MySqlDbType.String).Value = article.Reference;
                        cmd.Parameters.Add("?idCaisse", MySqlDbType.Int32).Value = 1;
                        cmd.Parameters.Add("?qte", MySqlDbType.Int32).Value = article.QuantiteCommande;
                        cmd.Parameters.Add("?TotalCommande", MySqlDbType.Decimal).Value = TotalCommande(listArticle);
                        cmd.ExecuteNonQuery();
                    }
                }
                this.CloseConnection();
            }
        }

        public bool QuantiteStockDispo(Article article, int QteCommande)
        {
            int qteStockDispo = 0;
            if (this.OpenConnection() == true)
            {

                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT `qteStock` FROM `stock` WHERE idArticle = ?idArticle";
                    cmd.Parameters.Add("?idArticle", MySqlDbType.String).Value = article.Reference;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                qteStockDispo = int.Parse(reader[0].ToString());
                            }
                            reader.Close();
                            this.CloseConnection();
                            if (qteStockDispo >= QteCommande & QteCommande != 0)
                            {
                                return true;
                            } else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public void MouvementStockVente(List<Article> listArticle)
        {
            if (this.OpenConnection() == true)
            {
                foreach (Article article in listArticle)
                {
                    using (MySqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE `stock` SET `qteStock`= ?qteStock ,`date_modification`= NOW() WHERE `idArticle` = ?idArticle";
                        cmd.Parameters.Add("?idArticle", MySqlDbType.String).Value = article.Reference;
                        cmd.Parameters.Add("?qteStock", MySqlDbType.Int32).Value = article.QuantiteStock - article.QuantiteCommande;
                        cmd.ExecuteNonQuery();
                    }
                }
                this.CloseConnection();
            }
        }

        public int CreateIdCommande()
        {
            int nbCommandes = 0;
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT MAX(numeroCommande) FROM CommandesVentes";
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            nbCommandes = Convert.ToInt32(reader[0]);
                        }
                        reader.Close();
                    }
                    this.CloseConnection();
                    return nbCommandes;
                }
            }
            return nbCommandes;
        }

        public decimal SelectSoldeCaisse(int idCaisse)
        {
            decimal SoldeCaisse = 0;
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT `solde` FROM `caisse` WHERE `idCaisse` = ?idCaisse";
                    cmd.Parameters.Add("?idCaisse", MySqlDbType.Int32).Value = idCaisse;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            SoldeCaisse = Convert.ToDecimal(reader[0]);
                        }
                        reader.Close();
                    }
                }
                this.CloseConnection();
                return SoldeCaisse;
            }
            return SoldeCaisse;
        }
        public void UpdateCaisse(decimal Solde, int idCaisse)
        {
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE `caisse` SET `solde`= ?nouveauSolde WHERE `idCaisse` = ?idCaisse";
                    cmd.Parameters.Add("?nouveauSolde", MySqlDbType.Decimal).Value = Solde;
                    cmd.Parameters.Add("?idCaisse", MySqlDbType.Int32).Value = idCaisse;
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
            }
        }

        public void DeleteArticle(string referenceArticle)
        {
            if(SelectReferenceExist(referenceArticle) == true)
            {
                if (this.OpenConnection() == true)
                {
                    using (MySqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM `articles` WHERE `reference` = ?idArticle";
                        cmd.Parameters.Add("?idArticle", MySqlDbType.String).Value = referenceArticle;
                        cmd.ExecuteNonQuery();
                    }
                    this.CloseConnection();
                }
            }
            
        }
    }
}
