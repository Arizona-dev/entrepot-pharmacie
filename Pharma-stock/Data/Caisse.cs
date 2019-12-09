using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot_pharmacie
{
    public class Caisse
    {
        Entrepot entrepot;
        private int SoldeCaisse = 1000;
        public int soldeCaisse {
            get { return SoldeCaisse; }
            set { SoldeCaisse = value; }
        }
        private string nomCaisse;
        

        public void ajouter_argent(int a)
        {
            soldeCaisse = soldeCaisse + a;
        }

        public void retirer_argent(int a)
        {
            soldeCaisse = soldeCaisse - a;
        }
    }
}