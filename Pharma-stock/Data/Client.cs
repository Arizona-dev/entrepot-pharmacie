using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot_pharmacie
{
    public class Client
    {
        private string nom;
        private string prenom;
        private string adresse;
        private int telephone;
        private string email;
        private int date_naissance;

        public Commande listeCommande
        {
            get => default;
            set
            {
            }
        }

        public void entrepot()
        {
            throw new System.NotImplementedException();
        }
    }
}