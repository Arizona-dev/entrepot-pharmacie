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

            Console.WriteLine("0) Quitter\n1) Voir solde\n2) Ajouter un produit\n3) Voir les produits disponibles\n4) Acheter un produit\n");
            int result = 0;
            int resc = 0;
            int resq = 0;
            Double resp = 0;
            Double resm = 0;
            

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
                if (result == 1)
                {
                    Console.Clear();
                    Console.WriteLine(caisse.somme + "\n");
                    result = 9;
                    
                }
                else if (result == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Remplir les informations du nouveau produit : ");
                    Console.WriteLine("Nom du produit : ");
                    String name = Console.ReadLine();

                    Console.WriteLine("Numero de référence du produit : ");
                    String reference = Console.ReadLine();

                    Console.WriteLine("Description du produit : ");
                    String description = Console.ReadLine();

                    Console.WriteLine("Prix HT du produit : ");
                    String prix = Console.ReadLine();
                    try
                    {
                        resp = Convert.ToDouble(prix);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Format incorrect '{prix}'");
                        prix = Console.ReadLine();
                    }

                    Console.WriteLine("Code fournisseur du produit : ");
                    String code = Console.ReadLine();
                    try
                    {
                        resc = Int32.Parse(code);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Format incorrect '{code}'");
                        code = Console.ReadLine();
                    }

                    Console.WriteLine("Marge du produit : ");
                    String marge = Console.ReadLine();
                    try
                    {
                        resm = Convert.ToDouble(marge);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Format incorrect '{marge}'");
                        marge = Console.ReadLine();
                    }

                    Console.WriteLine("Quantité disponible du produit : ");
                    String quantity = Console.ReadLine();
                    try
                    {
                        resq = Int32.Parse(quantity);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Format incorrect" +
                            $"23 '{quantity}'");
                        quantity = Console.ReadLine();
                    }


                    article = new Article(name, reference, description, resp, resc, resm, resq);
                    listArticle.Add(article);
                    result = 9;
                    Console.Clear();
                    printInventory(listArticle);

                } else if (result == 3) {
                    Console.Clear();
                    printInventory(listArticle);
                    result = 9;
                } else if (result == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Saisissez la reference du produit\n");
                    String refProduit = Console.ReadLine();

                    Article articleReturn = Utilitaire.ArticleExiste(listArticle, refProduit);

                    if (articleReturn != null)
                    {
                        Console.WriteLine($"\nProduit trouvé :\nArticle: {articleReturn.nom} Réference:{articleReturn.reference} Description:{articleReturn.description} Prix_HT:{articleReturn.prix_achat} Code:{articleReturn.code_fournisseur} Marge:{articleReturn.marge_benef} Quantité:{articleReturn.quantite}\n");
                        Console.WriteLine("Saisissez la quantitée :\n");
                        String innbProduit = Console.ReadLine();
                        int nbProduit = 0;
                        try
                        {
                            nbProduit = Int32.Parse(innbProduit);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Format incorrect '{choice}'");
                            innbProduit = Console.ReadLine();
                        }
                        
                        if(articleReturn.quantite >= nbProduit)
                        {
                            //articleReturn.Qte = nbProduit;
                            listPanier.Add(articleReturn);
                            Commande commande = new Commande(listPanier);
                        } else
                        {
                            Console.WriteLine($"Quantité souhaité non disponible, quantité restante : '{articleReturn.quantite}'");
                        }

                        
                    } else {
                        Console.Clear();
                        Console.WriteLine("Reference de produit incorrect\n");
                    }
                    
                } else if (result == 5)
                {
                    Console.WriteLine("Test de la bdd\n");

                    database.Insert();
                }

                    Console.WriteLine("0) Quitter\n1) Voir solde\n2) Ajouter un produit\n3) Voir les produits disponibles\n4) Acheter un produit\n");
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
                Console.WriteLine($"Article: {a.nom} Réference:{a.reference} Description:{a.description} Prix_HT:{a.prix_achat} Code:{a.code_fournisseur} Marge:{a.marge_benef} Quantité:{a.quantite}\n");
            }

        }
    }
}
