using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot_pharmacie
{
    public class Caisse
    {
        public int somme = 1000;
        public string nom;
        Entrepot entrepot;

        public void ajouter_argent(int a)
        {
            somme = somme + a;
        }

        public void retirer_argent(int a)
        {
            somme = somme - a;
        }
    }
}