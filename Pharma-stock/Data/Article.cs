using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot_pharmacie
{
    public class Article
    {
        string nom;
        string reference;
        string description;
        decimal prix_achat;
        int code_fournisseur;
        decimal marge_benef;
        int quantiteStock;
        int quantiteCommande;

        public string Nom { get => nom; set => nom = value; }
        public string Reference { get => reference; set => reference = value; }
        public string Description { get => description; set => description = value; }
        public decimal Prix_achat { get => prix_achat; set => prix_achat = value; }
        public int Code_fournisseur { get => code_fournisseur; set => code_fournisseur = value; }
        public decimal Marge_benef { get => marge_benef; set => marge_benef = value; }
        public int QuantiteStock { get => quantiteStock; set => quantiteStock = value; }
        public int QuantiteCommande { get => quantiteCommande; set => quantiteCommande = value; }

        public Article(string Name, string Ref, string Desc, decimal prix_a, decimal marge, int code, int qteStock, int qteCommande)
        {
            Nom = Name;
            Reference = Ref;
            Description = Desc;
            Prix_achat = prix_a;
            Code_fournisseur = code;
            Marge_benef = marge;
            QuantiteStock = qteStock;
            QuantiteCommande = qteCommande;
        }
        
    }
}