using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot_pharmacie
{
    public class Article
    {
        private int nom;
        private int reference;
        private int description;
        private int prix_achat;
        private int code_fournisseur;
        private int marge_benef;
        private int quantite_stock;

        public Fournisseur Fournisseur
        {
            get => default;
            set
            {
            }
        }
    }
}