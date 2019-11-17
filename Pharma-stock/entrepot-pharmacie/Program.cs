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

            caisse.ajouter_argent(1000);
            Console.WriteLine(caisse.somme);

            entrepot.creer_article("Boulon de 10/60", "boulon10/60b50", "Boulon de 10/60 boîte de 50", 15.5, 10, 5, 50);
            


            foreach (Article z in entrepot.listArticle)
            {
                Console.WriteLine(z);

            }

            Console.ReadKey();




        }
    }
}
