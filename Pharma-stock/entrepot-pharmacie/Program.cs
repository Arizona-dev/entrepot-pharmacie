using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrepot_pharmacie
{
    class Program
    {
        static void Main(string[] args)
        {

            Caisse caisse = new Caisse();
            Entrepot entrepot = new Entrepot();
            Article article;
            List<Article> listArticle = new List<Article>();



            //caisse.ajouter_argent(1000);
            //Console.WriteLine(caisse.somme);

            Console.WriteLine("1) Voir solde\n2) Ajouter un produit\n3) Voir les produits disponibles\n4) Quitter\n");
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

            while(result != 0) {
                if (result == 1)
                {
                    Console.WriteLine(caisse.somme);
                    result = 9;
                }
                else if (result == 2)
                {
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
                    //Console.WriteLine($"article: {Article.nom} Réference:{Article.reference} Description:{Article.description} Prix_HT:{Article.prix_achat} Code:{Article.code_fournisseur} Marge:{Article.marge_benef} Quantité:{Article.quantite_stock}");

                    Article newArticle = new Article("Boulon de 10/60", "boulon10/60b50", "Boulon de 10/60 boîte de 50", 15.5, 10, 5, 50);
                    //Console.WriteLine($"article: {Article.nom} Réference:{Article.reference} Description:{Article.description} Prix_HT:{Article.prix_achat} Code:{Article.code_fournisseur} Marge:{Article.marge_benef} Quantité:{Article.quantite_stock}");

                } else if (result == 3) {

                    printInventory(listArticle);

                    
                    result = 9;
                }

                Console.WriteLine("1) Voir solde\n2) Ajouter un produit\n3) Voir les produits disponibles\n4) Quitter\n");
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
                Console.WriteLine($"article: {a.nom} Réference:{a.reference} Description:{a.description} Prix_HT:{a.prix_achat} Code:{a.code_fournisseur} Marge:{a.marge_benef} Quantité:{a.quantite_stock}");
            }

        }
    }
}
