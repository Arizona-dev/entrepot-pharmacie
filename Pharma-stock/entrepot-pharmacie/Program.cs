using Data;
using System;
using System.Collections.Generic;

namespace entrepot_pharmacie
{
    public class Program
    {
        private static readonly int idCaisse = 1;
        static string name = "";
        static string reference = "";
        static string description = "";
        static decimal prixHT = 0;
        static int code = 0;
        static decimal marge = 0;
        static int quantiteDispo = 0;
        static int idEntrepot = 0;
        static int qteCommande = 0;
        
        static Article article;
        static void Main(string[] args)
        {
            List<Article> ListeArticle = new List<Article>();
            List<Article> ListePanier = new List<Article>();
            Data.Database database = new Data.Database();
            Caisse.GetSolde(database.SelectSoldeCaisse(idCaisse));
            ListMenu(ListePanier);
        }

        public static void ListMenu(List<Article> ListePanier)
        {
            Console.Clear();
            Data.Database database = new Data.Database();
            int result = 0;
            bool exit = false;
            Console.WriteLine("Solde de la Caisse : " + Caisse.soldeCaisse + " euros\n");
            Console.WriteLine("Contenu du panier :\n");
            printInventory(ListePanier);
            Console.WriteLine("1 - Vendre des articles\n2 - Gérer les articles\n3 - Gérer les clients\n4 - Gérer les fournisseurs et entrepôts\n5 - Gérer la Caisse\n");
            string choice = Console.ReadLine();
            result = Utilitaire.TestValeur(choice, true).Item1;
            while (!exit)
            {
                switch (result)
                {
                    case 1: // Vendre des articles
                        AchatArticle(ListePanier, database);
                        break;
                    case 2: // Gérer les articles dans le stock
                        GererArticles(ListePanier, database);
                        break;
                    case 3: // Gérer les clients
                        GererLesClients(ListePanier, database);
                        break;
                    case 4: // Gérer les fournisseurs et entrepôts
                        Console.Clear();
                        break;
                    case 5: // Gérer la caisse
                        SetSoldeCaisse();
                        ListMenu(ListePanier);
                        break;
                    default:
                        break;
                }
            }
        }
        public static void AchatArticle(List<Article> ListePanier, Database db)
        {
            Data.Database database = new Data.Database();
            Caisse caisse = new Caisse();
            Console.Clear();
            Console.WriteLine("1 - Afficher le panier\n2 - Rechercher un article par nom\n3 - Rechercher un article par référence\n0 - Retour");
            string choice1 = Console.ReadLine();
            int result1 = Utilitaire.TestValeur(choice1, true).Item1;
            switch (result1)
            {
                case 1: // afficher le panier OK
                    Console.Clear();
                    Console.WriteLine("Solde de la Caisse : " + Caisse.soldeCaisse + " euros\n");
                    Console.WriteLine("Contenu du panier :\n");
                    printInventory(ListePanier);
                    Console.WriteLine("1 - Valider la commande\n2 - Retirer un article du panier\n3 - Vider le panier\n0 - Retour");
                    string choice = Console.ReadLine();
                    int choix = Utilitaire.TestValeur(choice, true).Item1;
                    if (choix == 1) // Valider commande OK
                    {
                        printInventory(ListePanier);
                        Console.WriteLine("Souhaitez vous vraiment valider le Panier ?");
                        string valider = Console.ReadLine();
                        int Valider = Utilitaire.TestValeur(valider, true).Item1;
                        if (Valider == 1)
                        {
                        db.InsertCommandeVente(ListePanier);
                        db.MouvementStockVente(ListePanier);
                        decimal TotalCommande = db.TotalCommandeVente(ListePanier);
                        Caisse.AjouterArgent(TotalCommande, idCaisse);
                        ListePanier.Clear();
                        Console.WriteLine("Commande passé merci");
                        Console.ReadLine();
                        }
                    }
                    else if (choix == 2) // Retirer un article du panier
                    {
                        Console.Clear();
                        Console.WriteLine("Entrer la référence de l'article à supprimer\n");
                        string inputReference = Console.ReadLine();
                        if(Utilitaire.RefArticleExisteDansList(ListePanier, inputReference))
                        {
                            Article article = Utilitaire.ArticleExiste(ListePanier, inputReference);
                            ListePanier.Remove(article);
                            Console.WriteLine("Produit retiré du Panier\n");
                            Console.ReadLine();
                        } else
                        {
                            Console.WriteLine("Ce Produit ne se trouve pas dans le Panier\n");
                            Console.ReadLine();
                        }
                    }
                    else if (choix == 3) // Vider le panier
                    {
                        ListePanier.Clear();
                    }
                    else if (choix == 0) // Retour menu principal
                    {
                        AchatArticle(ListePanier, db);
                    }

                    break;
                case 2: //Rechercher un article par nom
                    Console.Clear();
                    Console.WriteLine("Entrer le nom de l'article\n");
                    string inputNom = Console.ReadLine();
                    Article a = database.SelectArticleParNom(inputNom);
                    if (a != null)
                    {
                        Console.Clear();
                        Console.WriteLine($"Article trouvé, Nom: {a.Nom} Réference:{a.Reference} Description:{a.Description} Prix_HT:{a.Prix_achat} Code:{a.Code_fournisseur} Marge:{a.Marge_benef} QuantitéDispo{a.QuantiteStock}\n");
                        QuantiteAjoutPanier(a, ListePanier);
                    }
                    break;
                case 3: //Rechercher un article par référence
                    Console.Clear();
                    Console.WriteLine("Entrer la référence de l'article\n");
                    string inputRef = Console.ReadLine();
                    Article b = database.SelectArticleParReference(inputRef);
                    if (b != null)
                    {
                        Console.Clear();
                        Console.WriteLine($"Article trouvé, Nom: {b.Nom} Réference:{b.Reference} Description:{b.Description} Prix_HT:{b.Prix_achat} Code:{b.Code_fournisseur} Marge:{b.Marge_benef} QuantitéDispo{b.QuantiteStock}\n");
                        QuantiteAjoutPanier(b, ListePanier);
                    }
                    break;
                case 0: //Retour menu principal
                    Console.Clear();
                    ListMenu(ListePanier);
                    break;
                default:
                    break;
            }
        }
        
        private static void GererLesClients(List<Article> ListePanier, Database db)
        {
            Console.Clear();
            Data.Database database = new Data.Database();
            Console.WriteLine("1 - Ajouter un client\n2 - Modifier un client\n3 - Supprimer un client\n0 - Retour");
            string choice = Console.ReadLine();
            int result = Utilitaire.TestValeur(choice, true).Item1;

            switch (result)
            {
                case 1: // Ajouter un client
                    Console.Clear();
                    Console.WriteLine("Nom du client\n");
                    string nom = Console.ReadLine();
                    Console.WriteLine("Prenom du client\n");
                    string prenom = Console.ReadLine();
                    Console.WriteLine("Adresse du client\n");
                    string adresse = Console.ReadLine();
                    Console.WriteLine("Numéro de téléphone du client\n");
                    string numero = Console.ReadLine();
                    Console.WriteLine("Adresse Email du client\n");
                    string email = Console.ReadLine();
                    Console.WriteLine("Date de naissance du client\n");
                    string birthdate = Console.ReadLine();
                    DateTime bdate = Convert.ToDateTime(birthdate); // Ajouter un check de la date

                    db.InsertClient(nom, prenom, adresse, numero, email, bdate.Date);
                    break;
                case 2: // Modifier un client

                    break;
                case 3: // Supprimer un client

                    break;
                case 0: // Retour
                    ListMenu(ListePanier);
                    break;
                default:

                    break;
            }
        }
        private static bool GererLesFournisseurEtEntrepots()
        {
            Console.WriteLine("1 - Ajouter un fournisseur\n2 - Modifier un fournisseur\n3 - Supprimer un fournisseur - ! Attention cela entrainera la suppression de tout les articles liée à ce fournisseur\n4 - Ajouter un entrepôt\n5 - Modifier un entrepôt\n6- Supprimer un entrepôt - ! Attention cela entrainera la suppression de tout les articles stocké dans cet entrepôt\n");
            string choice = Console.ReadLine();
            int result = Utilitaire.TestValeur(choice, true).Item1;

            switch (result)
            {
                case 1: //Ajouter un fournisseur

                    break;
                case 2: //Modifier un fournisseur

                    break;
                case 3: //Supprimer un fournisseur

                    break;
                case 4: //Ajouter un entrepôt

                    break;
                case 5: //Modifier un entrepôt

                    break;
                case 6: //Supprimer un entrepôt

                    break;
                default:

                    break;
            }
            return true;
        }

        private static void printInventory(List<Article> listArticle)
        {
            foreach (Article a in listArticle)
            {
                Console.WriteLine($"Nom: {a.Nom} Réference:{a.Reference} CodeFournisseur:{a.Code_fournisseur} Prix_HT:{a.Prix_achat}  Marge:{a.Marge_benef} QuantitéPanier:{a.QuantiteCommande}\n");
            }

        }

        private static void QuantiteAjoutPanier(Article article, List<Article> ListePanier)
        {
            Data.Database database = new Data.Database();
            int AjouterPanier;
            do
            {
                Console.WriteLine("Voulez-vous ajouter cet article dans le panier?\n1 pour ajouter dans le panier OU 2 pour effectuer une autre recherche");
                string ajouterPanier = Console.ReadLine();
                AjouterPanier = Utilitaire.TestValeur(ajouterPanier, true).Item1;
            } while (AjouterPanier != 1 && AjouterPanier != 2);
            if (AjouterPanier == 1)
            {
                Console.Clear();
                int QteAjout = 0;
                do
                {
                    Console.WriteLine("Saisissez la quantité à ajouter dans le panier :");
                    string qteAjout = Console.ReadLine();
                    QteAjout = Utilitaire.TestValeur(qteAjout, true).Item1;
                    if (database.QuantiteStockDispo(article, QteAjout) == true)
                    {
                        article.QuantiteCommande = QteAjout;
                        ListePanier.Add(article);
                        Console.WriteLine("Contenu du panier :\n");
                        printInventory(ListePanier);
                        Console.WriteLine("Article ajouté dans le panier");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Quantité non disponible, veuillez saisir une quantité inferieure à : " + article.QuantiteStock);
                    }
                } while (database.QuantiteStockDispo(article, QteAjout) == false);
            }
        }

        private static void AjouterArticleStock(Database database)
        {
            Console.Clear();
            Console.WriteLine("Remplir les informations du nouveau produit à ajouter dans le stock : ");
            Console.WriteLine("Nom du produit : ");
            name = Console.ReadLine();

            Console.WriteLine("\nNumero de référence du produit : ");
            reference = Console.ReadLine();
            if (database.SelectReferenceExist(reference))
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("\nUn produit existe déja sous cette référence, Utilisez une autre référence :\n");
                    reference = Console.ReadLine();
                } while (database.SelectReferenceExist(reference));
            }

            Console.WriteLine("\nDescription du produit : ");
            description = Console.ReadLine();

            Console.WriteLine("\nCode fournisseur du produit : ");
            string codeIn = Console.ReadLine();
            code = Utilitaire.TestValeur(codeIn, true).Item1;

            if (database.SelectFournisseurExist(code) == false)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("\nCe Fournisseur n'existe pas, Utilisez un autre code fournisseur :\n");
                    codeIn = Console.ReadLine();
                    code = Utilitaire.TestValeur(codeIn, true).Item1;
                } while (database.SelectFournisseurExist(code) == false);
            }

            Console.WriteLine("\nPrix HT du produit : ");
            string prixIn = Console.ReadLine();
            prixHT = Utilitaire.TestValeur(prixIn, false).Item2;

            Console.WriteLine("\nMarge du produit : ");
            string margeIn = Console.ReadLine();
            marge = Utilitaire.TestValeur(margeIn, false).Item2;

            Console.WriteLine("\nQuantité à acheter : ");
            string quantityIn = Console.ReadLine();
            quantiteDispo = Utilitaire.TestValeur(quantityIn, true).Item1;

            Console.WriteLine("\nNumero d'Entrepot où sera stocké le produit : ");
            string idEntrepotIn = Console.ReadLine();
            idEntrepot = Utilitaire.TestValeur(idEntrepotIn, true).Item1;

            if (database.SelectEntrepotExist(idEntrepot) == false)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("\nCet Entrepot n'existe pas, Utilisez un autre code Entrepot :\n");
                    idEntrepotIn = Console.ReadLine();
                    idEntrepot = Utilitaire.TestValeur(idEntrepotIn, true).Item1;
                } while (database.SelectEntrepotExist(idEntrepot) == false);
            }

            article = new Article(name, reference, description, prixHT, marge, code, quantiteDispo, qteCommande);

            database.CreerArticle(article, idEntrepot);
            decimal TotalCommande = database.TotalCommandeAchat(prixHT, quantiteDispo);
            Caisse.RetirerArgent(TotalCommande, idCaisse);
        }

        private static void GererArticles(List<Article> ListePanier, Database database)
        {
            Console.Clear();
            Console.WriteLine("Solde de la Caisse : " + Caisse.soldeCaisse + " euros\n");
            Console.WriteLine("1 - Ajouter un article\n2 - Modifier un article\n3 - Supprimer un article\n4 - Afficher tout les articles du stock\n0 - Retour");
            string gererArticle = Console.ReadLine();
            int GererArticle = Utilitaire.TestValeur(gererArticle, true).Item1;
            if (GererArticle == 1) // Ajouter un article dans le stock
            {
                AjouterArticleStock(database);
            }
            else if (GererArticle == 2) // Modifier un article dans le stock
            {
                Console.Clear();
                Console.WriteLine("Entrer la référence du produit : ");
                string reference = Console.ReadLine();
                Console.WriteLine("Nouveau nom du produit : ");
                string nom = Console.ReadLine();

                Console.WriteLine("Nouvelle description du produit : ");
                string description = Console.ReadLine();

                Console.WriteLine("Nouvelle marge du produit : ");
                string marge = Console.ReadLine();
                decimal Marge = Utilitaire.TestValeur(marge, false).Item2;
                database.UpdateArticle(reference, nom, description, Marge);
            }
            else if (GererArticle == 3) // Supprimer un produit à l'aide de sa référence produit
            {
                Console.Clear();
                Console.WriteLine("Entrer la reference exacte du produit à supprimer :\n");
                String refProduit = Console.ReadLine();
                database.DeleteArticle(refProduit);
                Console.WriteLine("Article supprimé\n");
                Console.ReadLine();
            }
            else if (GererArticle == 4) // Afficher tout les articles du stock
            {
                database.Select();
            }
            else if (GererArticle == 0) // Retour menu
            {
                ListMenu(ListePanier);
            }
            GererArticles(ListePanier, database);
        }

        private static void SetSoldeCaisse()
        {
            Console.Clear();
            Console.WriteLine("Solde de la Caisse : " + Caisse.soldeCaisse + " euros\n");
            Console.WriteLine("1 - Ajouter de l'argent dans la caisse\n2 - Retirer de l'argent de la caisse\n0 - Retour");
            string gererCaisse = Console.ReadLine();
            int GererCaisse = Utilitaire.TestValeur(gererCaisse, true).Item1;
            if (GererCaisse == 1)
            {
                Console.Clear();
                Console.WriteLine("Solde de la Caisse : " + Caisse.soldeCaisse + " euros\n");
                Console.WriteLine("Entrer le montant à ajouter dans la caisse : \n");
                string setSolde = Console.ReadLine();
                decimal SetSolde = Utilitaire.TestValeur(setSolde, false).Item2;
                Caisse.AjouterArgent(SetSolde, idCaisse);
            }
            else if (GererCaisse == 2)
            {
                Console.Clear();
                Console.WriteLine("Solde de la Caisse : " + Caisse.soldeCaisse + " euros\n");
                Console.WriteLine("Entrer le montant à retirer de la caisse : \n");
                string setSolde = Console.ReadLine();
                decimal SetSolde = Utilitaire.TestValeur(setSolde, false).Item2;
                Caisse.RetirerArgent(SetSolde, idCaisse);
            }
            else if (GererCaisse == 0)
            {

            }


            
        }

    }
}

// A FAIRE
/* Ajouter Entrepot
 * Modifier Entrepot
 * Supprimer Entrepot
 * 
 * Ajouter Fournisseur
 * Modifier Fournisseur
 * Supprimer Fournisseur
 * 
 * Modifier Client
 * Supprimer Client
 * 
 * Crée Commande lors d'un achat
 * Console.WriteLine("1 - Achet
 * 
 */
/*
Boucle Principale 
    Console.WriteLine("1 - Acheter des articles\n2 - Afficher tout les articles\n3 - Gérer les clients\n4 - Gérer les fournisseurs et entrepôts\n");
Boucle 1 -
    Console.WriteLine("1 - Afficher le panier\n2 - Rechercher un article par nom\n3 - Rechercher un article par référence\n4 - Ajouter un article à l'aide de sa référence dans le Panier\n");
Boucle 2 -
    Console.WriteLine("1 - Ajouter un article dans le stock\n2 - Modifier un article du stock\n3 - Supprimer un article du stock\n");
Boucle 3 -
    Console.WriteLine("1 - Ajouter un client\n2 - Modifier un client\n3 - Supprimer un client\n");
Boucle 4 -
    Console.WriteLine("1 - Ajouter un fournisseur\n2 - Modifier un fournisseur\n3 - Supprimer un fournisseur /!\ Attention cela entrainera la suppression de tout les articles liée à ce fournisseur\n4 - Ajouter un entrepôt\n5 - Modifier un entrepôt\n6- Supprimer un entrepôt /!\ Attention cela entrainera la suppression de tout les articles stocké dans cet entrepôt\n");
    */
/*
1- Acheter des articles
    1- Afficher le panier
        // Liste Panier
        1- Valider la commande
        2- Retirer un article du panier
        3- Vider le panier
    2- Rechercher un article par nom
    3- Rechercher un article par référence
    4- Ajouter un article à l'aide de sa référence dans le Panier

2- Afficher tout les articles
    1- Ajouter un article dans le stock
    2- Modifier un article du stock
    // Liste Articles
    3- Supprimer un article du stock

3- Gérer les clients
    1- Ajouter un client
    // Liste clients
    2- Modifier un client
    3- Supprimer un client

4- Gérer les fournisseurs et entrepôts
    
    1- Ajouter un fournisseur
    2- Modifier un fournisseur
    // Liste fournisseurs
    3- Supprimer un fournisseur /!\ Attention cela entrainera la suppression de tout les articles liée à ce fournisseur
    
    4- Ajouter un entrepôt
    5- Modifier un entrepôt
    // Liste entrepôts
    6- Supprimer un entrepôt /!\ Attention cela entrainera la suppression de tout les articles stocké dans cet entrepôt
 */
