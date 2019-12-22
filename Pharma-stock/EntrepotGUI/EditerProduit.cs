using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntrepotGUI
{
    public partial class EditerProduit : Form
    {
        //Code de https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public EditerProduit()
        {
            InitializeComponent();
        }

        private void btnAnnulerAjout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Data.Database database = new Data.Database();

            string reference = refProduitTextbox.Text;
            if (reference == "")
            {
                string text = "Un référence de produit est nécessaire.";
                MessageBox.Show(text);
                return;
            }

            if (database.SelectReferenceExist(reference))
            {
                string text = "Un produit existe déja sous cette référence, Utilisez une autre référence.";
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

            string description = descriptionTextbox.Text;

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

            database.UpdateListProduit(reference, nom, description, prixHT, marge);
            string end = "Article edité avec succès";
            MessageBox.Show(end);
            this.Close();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
