using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot_pharmacie
{
    public class Caisse
    {
        static decimal SoldeCaisse = 1000m;
        static int idCaisse = 1;
        public static decimal soldeCaisse {
            get { return SoldeCaisse; }
            set { SoldeCaisse = value; }
        }
        public static int IdCaisse {
            get { return idCaisse; }
            set { idCaisse = value; }
        }
        
        public static void GetSolde(decimal Solde)
        {
            soldeCaisse = Solde;
        }

        public static void AjouterArgent(decimal Solde, int idCaisse)
        {
            Data.Database database = new Data.Database();
            soldeCaisse = soldeCaisse + Solde;
            database.UpdateCaisse(soldeCaisse, idCaisse);
        }

        public static void RetirerArgent(decimal Solde, int idCaisse)
        {
            Data.Database database = new Data.Database();
            soldeCaisse = soldeCaisse - Solde;
            database.UpdateCaisse(soldeCaisse, idCaisse);
        }
    }
}