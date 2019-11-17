using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot_pharmacie
{
    public class Entrepot
    {
        Caisse caisse;
        Article article;

        public List<Article> listArticle = new List<Article>();

        public Fournisseur listeFournisseur
        {
            get => default;
            set
            {
            }
        }

        public Client listeClient
        {
            get => default;
            set
            {
            }
        }

        public Caisse nomCaisse
        {
            get => default;
            set
            {
            }
        }

        public void creer_fournisseur()
        {
            throw new System.NotImplementedException();
        }

        public void modifier_fournisseur()
        {
            throw new System.NotImplementedException();
        }

        public void supprimer_fournisseur()
        {
            throw new System.NotImplementedException();
        }

        public void creer_article(string nom, string reference, string description, double prix_a, int code, double marge, int quantite)
        {
            Article article = new Article();

            article.nom = nom;
            article.reference = reference;
            article.description = description;
            article.prix_achat = prix_a;
            article.code_fournisseur = code;
            article.marge_benef = marge;
            article.quantite_stock = quantite;
            listArticle.Add(article);

        }

        public void modifier_article()
        {
            throw new System.NotImplementedException();
        }

        public void supprimer_article()
        {
            throw new System.NotImplementedException();
        }

        public void achat_article()
        {
            throw new System.NotImplementedException();
        }

        public void vente_article()
        {
            throw new System.NotImplementedException();
        }
    }
}