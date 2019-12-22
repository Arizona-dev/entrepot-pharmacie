using Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EntrepotGUI
{
    public partial class produits : Form
    {

        public produits()
        {
            InitializeComponent();
        }
        
        public void produits_Load(object sender, EventArgs e)
        {
            ReloadGrid();
        }

        public static void ReloadGrid()
        {
            Database database = new Database();
            listeProduits.DataSource = database.SelectProduit();
        }

        private void BtnEditProduit_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<EditerProduit>().Count() == 1)
                Application.OpenForms.OfType<EditerProduit>().First().Close();
            EditerProduit EditerProduitframe = new EditerProduit();
            EditerProduitframe.Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AjouterProduit>().Count() == 1)
                Application.OpenForms.OfType<AjouterProduit>().First().Close();
            AjouterProduit AjouterProduitFrame = new AjouterProduit();
            AjouterProduitFrame.Show();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            if (MessageBox.Show("Voulez vous vraiment supprimer cet article ?","SUPPRESSION D'UN ARTICLE", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                //string selectedRow = listeProduits.Rows[0].Cells[0].Value.ToString();
                //MessageBox.Show(selectedRow);
                
                foreach (DataGridViewRow row in listeProduits.Rows)
                {
                    if (row.Selected == true)
                    {
                        int index = row.Index;
                        MessageBox.Show(Convert.ToString(index));
                    }
                }

                string reference = "";
                MessageBox.Show(reference);
                //database.DeleteArticle(reference);
                listeProduits.DataSource = database.SelectProduit();
            }

            
        }
    }
}
