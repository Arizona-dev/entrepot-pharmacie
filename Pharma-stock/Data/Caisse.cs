using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot_pharmacie
{
    public class Caisse
    {
        Entrepot entrepot;
        private decimal SoldeCaisse = 1000m;
        public decimal soldeCaisse {
            get { return SoldeCaisse; }
            set { SoldeCaisse = value; }
        }
        private string nomCaisse;
        

        public void AjouterArgent(int a)
        {
            soldeCaisse = soldeCaisse + a;
        }

        public void RetierArgent(int a)
        {
            soldeCaisse = soldeCaisse - a;
        }
    }
}