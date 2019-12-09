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
            try
            {
                result = Int32.Parse(choice);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Format incorrect '{choice}'");
                choice = Console.ReadLine();
            }

            while (result != 0) {
                // Afficher le solde de la Caisse
                if (result == 1)
                {
                    Console.Clear();
                    Console.WriteLine(caisse.soldeCaisse + "\n");
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

                    article = new Article(name, reference, description, prixHT, code, marge);
                    listArticle.Add(article);
                    database.Insert(reference, name, description, prixHT, code, marge, prixTTC, quantiteDispo);

                    result = 9;
                    Console.Clear();
                    database.Select();

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
                        database.SelectArticle(refProduit, false);
                    } else if (choix == 2)
                    {
                        Console.WriteLine("Saisir une référence de produit\n");
                        refProduit = Console.ReadLine();
                        database.SelectArticle(refProduit, true);
                    }
                    result = 9;
                } 
                // Acheter un produit
                else if (result == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Saisissez la reference du produit\n");
                    String refProduit = Console.ReadLine();

                    Article articleReturn = Utilitaire.ArticleExiste(listArticle, refProduit);

                    if (articleReturn != null)
                    {
                        Console.WriteLine($"\nProduit trouvé :\nArticle: {articleReturn.nom} Réference:{articleReturn.reference} Description:{articleReturn.description} Prix_HT:{articleReturn.prix_achat}  Marge:{articleReturn.marge_benef} Code:{articleReturn.code_fournisseur}\n");
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
                    
                } else if (result == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Entrer la reference du produit à supprimer :\n");
                    String refProduit = Console.ReadLine();
                    database.SelectArticle(refProduit, true);

                }

                    Console.WriteLine("0) Quitter\n1) Voir solde\n2) Ajouter un produit\n3) Rechercher un produit avec son nom ou sa référence produit\n4) Acheter un produit\n5) Supprimer un produit du stock\n");
                choice = Console.ReadLine();
                try
                {
                    result = Int32.Parse(choice);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Format incorrect '{choice}'");
                    choice = Console.ReadLine();
                }

            }
            Console.ReadKey();
        }

        private static void printInventory(List<Article> listArticle)
        {
            foreach (Article a in listArticle)
            {
                Console.WriteLine($"Article: {a.nom} Réference:{a.reference} Description:{a.description} Prix_HT:{a.prix_achat} Code:{a.code_fournisseur} Marge:{a.marge_benef}\n");
            }

        }
    }
}
