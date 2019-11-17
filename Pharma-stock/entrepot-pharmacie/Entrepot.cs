using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot_pharmacie
{
    public class Entrepot
    {
        Caisse caisse;
        public static void Main()
        {

            Caisse caisse = new Caisse();
            caisse.ajouter_argent(1000);
            Console.WriteLine(caisse.somme);

        }

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

        public void creer_article()
        {
            throw new System.NotImplementedException();
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