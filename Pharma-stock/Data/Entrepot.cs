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
        private static int idEntrepot = 1;
        public static int IdEntrepot
        {
            get { return idEntrepot; }
            set { idEntrepot = value; }
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

        

        public void achat_article()
        {
            
        }

        public void vente_article()
        {
            throw new System.NotImplementedException();
        }
    }
}