﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntrepotGUI
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public void AddProduit()
        {
            Data.Database database = new Data.Database();

            string reference = refProduitTextbox.Text;
            if (reference == "")
            {
                string text = "Un référence de produit est nécessaire.";
                MessageBox.Show(text);
                return;
            }
            string nom = nomProduitTextbox.Text;
            if (nom == "")
            {
                string text = "Un nom de produit est nécessaire.";
                MessageBox.Show(text);
                return;
            }

            if (database.SelectReferenceExist(reference))
            {
                string text = "Un produit existe déja sous cette référence, Utilisez une autre référence.";
                MessageBox.Show(text);
                return;
            }
            string description = descriptionTextbox.Text;
            int code;
            try
            {
                string codeIn = codeComboBox.SelectedItem.ToString();
                code = Convert.ToInt32(codeIn);
            }
            catch (Exception)
            {
                string text = "Veuillez selectionner un code de Fournisseur.";
                MessageBox.Show(text);
                return;
                throw;
            }
            decimal prixHT = 0;
            try
            {
                string prixIn = prixhtTextbox.Text;
                if (prixIn == "")
                {
                    string text = "Entrez un prix HT";
                    MessageBox.Show(text);
                    return;
                }
                prixHT = Convert.ToDecimal(prixIn);
            }
            catch (Exception)
            {
                string text = "Format d'entrée incorrect, utilisez des virgules et non des points.";
                MessageBox.Show(text);
                return;
                throw;
            }

            decimal marge = 0;
            try
            {
                string margeIn = margeTextbox.Text;
                if (margeIn == "")
                {
                    string text = "Entrez une marge";
                    MessageBox.Show(text);
                    return;
                }
                marge = Convert.ToDecimal(margeIn);
            }
            catch (Exception)
            {
                string text = "Format d'entrée incorrect, utilisez des virgules et non des points.";
                MessageBox.Show(text);
                return;
                throw;
            }
            int quantiteDispo;
            try
            {
                string quantityIn = quantiteAchatArticle.Text;
                quantiteDispo = Convert.ToInt32(quantityIn);
            }
            catch (Exception)
            {
                string text = "Entrez une quantité d'article à acheter";
                MessageBox.Show(text);
                return;
                throw;
            }
            Article article = new Article(nom, reference, description, prixHT, marge, code, quantiteDispo, 0);

            database.CreerArticle(article, idEntrepot);
            decimal TotalCommande = database.TotalCommandeAchat(prixHT, quantiteDispo);
            Caisse.RetirerArgent(TotalCommande, idCaisse);

            produits.ReloadGrid();

            string end = "Article ajouté avec succès";
            MessageBox.Show(end);
            this.Close();
        }

       
    }
}
