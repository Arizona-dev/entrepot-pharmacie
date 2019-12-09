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
        public decimal prix_achat;
        public int code_fournisseur;
        public decimal marge_benef;
        public int quantite;


        public Article(string Name, string Ref, string Desc, decimal prix_a, int code, decimal marge, int Qte)
        {
            nom = Name;
            reference = Ref;
            description = Desc;
            prix_achat = prix_a;
            code_fournisseur = code;
            marge_benef = marge;
            quantite = Qte;

        }

        public void Modifier_article(string Name, string Ref, string Desc, decimal prix_a, int code, decimal marge, int Qte)
        {
            nom = Name;
            reference = Ref;
            description = Desc;
            prix_achat = prix_a;
            code_fournisseur = code;
            marge_benef = marge;
            quantite = Qte;
        }

        public void supprimer_article()
        {
            throw new System.NotImplementedException();
        }



        static Fournisseur Fournisseur
        {
            get => default;
            set
            {
            }
        }
    }
}