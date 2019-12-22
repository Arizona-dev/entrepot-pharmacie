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

        public void ReloadGrid()
        {
            Database database = new Database();
            listeProduits.DataSource = database.SelectProduit();
        }

        private void BtnEditProduit_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<EditerProduit>().Count() == 1)
                Application.OpenForms.OfType<EditerProduit>().First().Close();
            EditerProduit EditerProduitframe = new EditerProduit(this);
            EditerProduitframe.Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AjouterProduit>().Count() == 1)
                Application.OpenForms.OfType<AjouterProduit>().First().Close();
            AjouterProduit AjouterProduitFrame = new AjouterProduit(this);
            AjouterProduitFrame.Show();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            if (MessageBox.Show("Voulez vous vraiment supprimer cet article ?","SUPPRESSION D'UN ARTICLE", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                int index = 0;
                foreach (DataGridViewRow row in listeProduits.Rows)
                {
                    if (row.Selected == true)
                    {
                        index = row.Index;
                    }
                }
                string reference = listeProduits.Rows[index].Cells[0].Value.ToString();
                database.DeleteArticle(Convert.ToString(reference));
                listeProduits.DataSource = database.SelectProduit();
                MessageBox.Show("Article supprimé avec succès");
                
            }

            
        }
    }
}
