using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrepot_pharmacie
{
    class Utilitaire
    {
       


        internal static Article ArticleExiste(List<Article> listArticle, String refProduit)
        {
            foreach (Article a in listArticle)
            {
                if (a.reference == refProduit)
                {
                    return a;
                }
            }
            return null;
        }


    }
}
