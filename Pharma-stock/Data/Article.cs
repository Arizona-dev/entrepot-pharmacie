using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot_pharmacie
{
    public class Article
    {
        public string nom;
        public string reference;
        public string description;
        public double prix_achat;
        public int code_fournisseur;
        public double marge_benef;
        public int quantite_stock;
        public Entrepot entrepot;


        public Article(string Name, string Ref, string Desc, double prix_a, int code, double marge, int quantite)
        {
            nom = Name;
            reference = Ref;
            description = Desc;
            prix_achat = prix_a;
            code_fournisseur = code;
            marge_benef = marge;
            quantite_stock = quantite;

        }

        public void modifier_article(string nom, string reference, string description, double prix_a, int code, double marge, int quantite)
        {
            Article article = new Article(nom, reference, description, prix_a, code, marge, quantite);


        }

        public void supprimer_article()
        {
            throw new System.NotImplementedException();
        }



        public Fournisseur Fournisseur
        {
            get => default;
            set
            {
            }
        }
    }
}