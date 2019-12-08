using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot_pharmacie
{
    public class Commande
    {
        Client client;
        private List<Article> list_articles;
        private int date_achat;
        private string numeroCommande;
        public string NumeroCommande
        {
            get { return numeroCommande; }
            set { numeroCommande = value; }
        }
        private int prix_total;
        private int prix_unitaire;

        public Commande(Client client, List<Article> list_articles, string date_achat, string NumeroCommande, decimal prix_unitaire, decimal prix_total)
        {
            
        }

        public Commande(List<Article> list_articles)
        {
            
        }



        public Article listeArticle
        {
            get => default;
            set
            {
            }
        }
    }
}