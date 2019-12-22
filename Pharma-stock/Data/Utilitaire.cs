using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrepot_pharmacie
{
    public class Utilitaire
    {
        //Database database;
        public static (int, decimal) TestValeur(string inputString, bool isInt)
        {
            Boolean estValide = false;
            Decimal outputDecimal = 0m;
            int outputInt = 0;
            if (isInt == true)
            {
                do
                {
                    estValide = true;
                    try
                    {
                        outputInt = Convert.ToInt32(inputString);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Format incorrect '{inputString}'");
                        inputString = Console.ReadLine();
                        estValide = false;
                    }
                    
                } while (!estValide);
            } else
            {
                do
                {
                    estValide = true;
                    try
                    {
                        outputDecimal = Convert.ToDecimal(inputString);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Format incorrect '{inputString}'");
                        inputString = Console.ReadLine();
                        estValide = false;
                    }
                } while (!estValide);
            }

            return (outputInt, outputDecimal);
        }

        public static Article ArticleExiste(List<Article> listArticle, string refProduit)
        {
            foreach (Article a in listArticle)
            {
                if (a.Reference == refProduit)
                {
                    return a;
                }
            }
            return null;
        }

        public static bool RefArticleExisteDansList(List<Article> listArticle, string refProduit)
        {
            foreach (Article a in listArticle)
            {
                if (a.Reference == refProduit)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
