using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrepot_pharmacie
{
    public class Program
    {
        static string name = "";
        static string reference = "";
        static string description = "";
        static decimal prixHT = 0;
        static int code = 0;
        static decimal marge = 0;
        static int quantiteDispo = 0;
        static int idEntrepot = 0;
        
        static Article article;
        static void Main(string[] args)
        {
            Caisse caisse = new Caisse();
            Entrepot entrepot = new Entrepot();
            List<Article> ListeArticle = new List<Article>();
            List<Article> ListePanier = new List<Article>();
            Data.Database database = new Data.Database();
            int result = 0;
            bool exit = false;

            Console.WriteLine("1 - Acheter des articles\n2 - Afficher tout les articles\n3 - Gérer les clients\n4 - Gérer les fournisseurs et entrepôts\n");
            string choice = Console.ReadLine();
            result = Utilitaire.TestValeur(choice, true).Item1;
            while (!exit) { 
                switch (result)
                {
                    case 1:
                        AchatArticle(ListePanier);
                        
                        break;
                    case 2:
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        break;

                    default:
                    
                        break;
                }

            }

            while (result != 0) {
                // Afficher le solde de la Caisse
                if (result == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Solde de la Caisse : " + caisse.soldeCaisse + " euros\n");
                    result = 9;
                }
                // Ajouter un produit en stock
                else if (result == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Remplir les informations du nouveau produit à ajouter au stock : ");
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

                    Console.WriteLine("\nPrix HT du produit : ");
                    string prixIn = Console.ReadLine();
                    prixHT = Utilitaire.TestValeur(prixIn, false).Item2;

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

                    Console.WriteLine("\nMarge du produit : ");
                    string margeIn = Console.ReadLine();
                    marge = Utilitaire.TestValeur(margeIn, false).Item2;

                    Console.WriteLine("\nQuantité à ajouter au stock : ");
                    string quantityIn = Console.ReadLine();
                    quantiteDispo = Utilitaire.TestValeur(quantityIn, true).Item1;

                    Console.WriteLine("\nNumero d'Entrepot ou sera stocké le produit : ");
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

                    article = new Article(name, reference, description, prixHT, marge, code, quantiteDispo);
                    ListeArticle.Add(article);

                    database.CreerArticle(article, idEntrepot);

                    result = 9;
                    Console.Clear();
                }
                // Rechercher un produit avec son nom ou sa référence produit
                else if (result == 3) {
                    int choix = 0;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1) Recherche par nom de produit\n2) Recherche par référence de produit\n");
                        String choixIn = Console.ReadLine();
                        choix = Utilitaire.TestValeur(choixIn, true).Item1;
                    } while (choix != 1 && choix != 2);
                    Console.Clear();
                    if (choix == 1)
                    {
                        Console.WriteLine("Saisir le nom du produit\n");
                        string nomProduit = Console.ReadLine();
                        Article a = database.SelectArticleParNom(nomProduit);
                            if (a != null)
                            {
                                Console.Clear();
                                Console.WriteLine(a.Nom + " " + a.Prix_achat + "\n");
                            }
                        } else if (choix == 2)
                    {
                        Console.WriteLine("Saisir la référence du produit\n");
                        string refProduit = Console.ReadLine();
                        Article a = database.SelectArticleParReference(refProduit);
                        if (a != null)
                        {
                            Console.Clear();
                            Console.WriteLine(a.Nom + a.Prix_achat + "\n");
                        }
                    }
                    result = 9;
                } 
                // Acheter un produit A FAIRE
                else if (result == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Saisissez la reference du produit\n");
                    String refProduit = Console.ReadLine();

                    Article articleReturn = Utilitaire.ArticleExiste(ListeArticle, refProduit);

                    if (articleReturn != null)
                    {
                        Console.WriteLine($"\nProduit trouvé :\nArticle: {articleReturn.Nom} Réference:{articleReturn.Reference} Description:{articleReturn.Description} Prix_HT:{articleReturn.Prix_achat}  Marge:{articleReturn.Marge_benef} Code:{articleReturn.Code_fournisseur}\n");
                        Console.WriteLine("Saisissez la quantitée :\n");
                        String inNbProduit = Console.ReadLine();
                        int nbProduit = 0;
                        nbProduit = Utilitaire.TestValeur(inNbProduit, true).Item1;
                        
                        /*
                        if(articleReturn.quantite >= nbProduit)
                        {
                            //articleReturn.Qte = nbProduit;
                            listPanier.Add(articleReturn);
                            Commande commande = new Commande(listPanier);
                        } else
                        {
                            Console.WriteLine($"Quantité souhaité non disponible, quantité restante : '{articleReturn.quantite}'");
                        }*/

                        
                    } else {
                        Console.Clear();
                        Console.WriteLine("Reference de produit incorrect\n");
                    }
                    
                } 
                // Supprimer un produit à l'aide de sa référence produit
                else if (result == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Entrer la reference exacte du produit à supprimer :\n");
                    String refProduit = Console.ReadLine();
                    database.Delete(refProduit);
                } else if (result == 6)
                {
                    Console.Clear();
                    Console.WriteLine("Entrer la reference du produit a trouver :\n");
                    string refProduit = Console.ReadLine();
                    Article a = database.SelectArticleParReference(refProduit);
                    if (a != null)
                    {
                        Console.WriteLine($"Article: {a.Nom} Réference:{a.Reference} Description:{a.Description} Prix_HT:{a.Prix_achat} Code:{a.Code_fournisseur} Marge:{a.Marge_benef}\n");
                    }
                    
                }


            }
        }

        private static bool AchatArticle(List<Article> ListePanier)
        {
            Console.Clear();
            Console.WriteLine("1 - Afficher le panier\n2 - Rechercher un article par nom\n3 - Rechercher un article par référence\n4 - Ajouter un article à l'aide de sa référence dans le Panier\n");
            string choice1 = Console.ReadLine();
            int result1 = Utilitaire.TestValeur(choice1, true).Item1;
            switch (result1)
            {
                case 1: // afficher le panier
                    Console.WriteLine("Contenu du panier :\n");
                    printInventory(ListePanier);
                    bool exit = false;
                        Console.Clear();
                        Console.WriteLine("1 - Valider la commande\n2 - Retirer un article du panier\n3 - Vider le panier\n0 - Retour");
                        string choice = Console.ReadLine();
                        int choix = Utilitaire.TestValeur(choice, true).Item1;
                        if (choix == 1)
                        {
                            // Valider commande
                        }
                        else if (choix == 2)
                        {
                            // Retirer un article du panier
                            //ListePanier.Remove(article);
                        }
                        else if (choix == 3)
                        {
                            // Vider le panier
                        }
                        else
                        {
                            AchatArticle(ListePanier);
                        }

                    break;
                case 2:
                    //Rechercher un article par nom
                    Data.Database database = new Data.Database();
                    Console.Clear();
                    Console.WriteLine("Entrer le nom de l'article\n");
                    string inputNom = Console.ReadLine();
                    Article article = database.SelectArticleParNom(inputNom);

                    break;
                case 3:
                    break;

                default:
                    break;
            }
            return true;
        }
        private static bool AfficherLesArticles()
        {
            int a = 0;
            switch (a)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            return true;
        }
        private static bool GererLesClients()
        {
            Console.WriteLine("1 - Ajouter un client\n2 - Modifier un client\n3 - Supprimer un client\n");
            string choice = Console.ReadLine();
            int result = Utilitaire.TestValeur(choice, true).Item1;

            switch (result)
            {
                case 1: // Ajouter un client

                    break;
                case 2: // Modifier un client

                    break;
                case 3: // Supprimer un client

                    break;
                default:

                    break;
            }
            return true;
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
                Console.WriteLine($"Article: {a.Nom} Réference:{a.Reference} Description:{a.Description} Prix_HT:{a.Prix_achat} Code:{a.Code_fournisseur} Marge:{a.Marge_benef}\n");
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
 * Ajouter Article
 * Modifier Article
 * Supprimer Article
 * Acheter Article
 * 
 * Ajouter Client
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
