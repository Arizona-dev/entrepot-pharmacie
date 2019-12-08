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
        public int quantite;


        public Article(string Name, string Ref, string Desc, double prix_a, int code, double marge, int Qte)
        {
            nom = Name;
            reference = Ref;
            description = Desc;
            prix_achat = prix_a;
            code_fournisseur = code;
            marge_benef = marge;
            quantite = Qte;

        }

        public static void Modifier_article(string nom, string reference, string description, double prix_a, int code, double marge, int Qte)
        {
           
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