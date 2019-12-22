using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace EntrepotGUI
{
    public partial class produits : Form
    {

        public produits()
        {
            InitializeComponent();
            Data.Database database = new Data.Database();
            //DataSet DS = db.SelectProduit();
            //listeProduits.DataSource = DS.Tables[0];
        }
        
        private void produits_Load(object sender, EventArgs e)
        {

            
        }

        private void BtnEditProduit_Click(object sender, EventArgs e)
        {
            EditerProduit frm = new EditerProduit();
            frm.Show();

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
