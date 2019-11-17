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







        public Fournisseur Fournisseur
        {
            get => default;
            set
            {
            }
        }
    }
}