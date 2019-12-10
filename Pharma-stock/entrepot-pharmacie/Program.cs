using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrepot_pharmacie
{
    public class Program
    {
        static void Main(string[] args)
        {
            Caisse caisse = new Caisse();
            Entrepot entrepot = new Entrepot();
            Article article;
            List<Article> listArticle = new List<Article>();
            List<Article> listPanier = new List<Article>();
            Data.Database bdd;
            Data.Database database = new Data.Database();



            //caisse.ajouter_argent(1000);
            //Console.WriteLine(caisse.somme);
            Console.WriteLine("Articles en stock :\n");
            database.Select();
            Console.WriteLine("\n0) Quitter\n1) Voir solde\n2) Ajouter un produit\n3) Rechercher un produit avec son nom ou sa référence produit\n4) Acheter un produit\n5) Supprimer un produit du stock\n");
            int result = 0;
            String name = "";
            String reference = "";
            String description = "";
            Decimal prixHT = 0;
            int code = 0;
            Decimal marge = 0;
            Decimal prixTTC = 0;
            int quantiteDispo = 0;

            String choice = Console.ReadLine();
            result = Utilitaire.TestValeur(choice, true).Item1;

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
                    Console.WriteLine("Remplir les informations du nouveau produit : ");
                    Console.WriteLine("Nom du produit : ");
                    name = Console.ReadLine();

                    Console.WriteLine("Numero de référence du produit : ");
                    reference = Console.ReadLine();

                    Console.WriteLine("Description du produit : ");
                    description = Console.ReadLine();

                    Console.WriteLine("Prix HT du produit : ");
                    string prixIn = Console.ReadLine();
                    prixHT = Utilitaire.TestValeur(prixIn, false).Item2;

                    Console.WriteLine("Code fournisseur du produit : ");
                    string codeIn = Console.ReadLine();
                    code = Utilitaire.TestValeur(codeIn, true).Item1;

                    Console.WriteLine("Marge du produit : ");
                    String margeIn = Console.ReadLine();
                    marge = Utilitaire.TestValeur(margeIn, false).Item2;

                    prixTTC = prixHT + marge;

                    Console.WriteLine("Quantité à ajouter au stock : ");
                    String quantityIn = Console.ReadLine();
                    quantiteDispo = Utilitaire.TestValeur(quantityIn, true).Item1;

                    article = new Article(name, reference, description, prixHT, code, marge, quantiteDispo);
                    listArticle.Add(article);
                    database.Insert(reference, name, description, prixHT, code, marge, prixTTC, quantiteDispo);

                    result = 9;
                    Console.Clear();
                }
                // Rechercher un produit avec son nom ou sa référence produit
                else if (result == 3) {
                    int choix = 0;
                    string refProduit = "";
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
                        Console.WriteLine("Saisir un nom de produit\n");
                        refProduit = Console.ReadLine();
                        database.SelectArticleParNom(refProduit);
                    } else if (choix == 2)
                    {
                        Console.WriteLine("Saisir une référence de produit\n");
                        refProduit = Console.ReadLine();
                        database.SelectArticleParReference(refProduit);
                    }
                    result = 9;
                } 
                // Acheter un produit A FAIRE
                else if (result == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Saisissez la reference du produit\n");
                    String refProduit = Console.ReadLine();

                    Article articleReturn = Utilitaire.ArticleExiste(listArticle, refProduit);

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
                }
                Console.WriteLine("Articles en stock :\n");
                database.Select();
                Console.WriteLine("0) Quitter\n1) Voir solde\n2) Ajouter un produit\n3) Rechercher un produit avec son nom ou sa référence produit\n4) Acheter un produit\n5) Supprimer un produit du stock\n");

                choice = Console.ReadLine();
                result = Utilitaire.TestValeur(choice, true).Item1;
                
            }
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
