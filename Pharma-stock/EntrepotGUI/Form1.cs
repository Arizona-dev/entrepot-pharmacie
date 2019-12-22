using entrepot_pharmacie;
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
using Data;

namespace EntrepotGUI
{
    public partial class Form1 : Form
    {
        //Code de https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public int idCaisse
        {
            get { return Caisse.IdCaisse; }
            set { Caisse.IdCaisse = value; }
        }

        public Form1()
        {
            InitializeComponent();
            
        }

        public void LoadForm()
        {
            Data.Database database = new Data.Database();
            Caisse.GetSolde(database.SelectSoldeCaisse(idCaisse));
            UpdateCaisse();
            SoldeRefresh.Enabled = true;
            SoldeRefresh.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        public void UpdateCaisse()
        {
            soldeLabel.Text = "Solde : " + Caisse.soldeCaisse + " €";
            soldeLabel.Refresh();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 180)
            {
                panelMenu.Width = 55;
            } else
            {
                panelMenu.Width = 180;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormDansPanel(object Form1)
        {
            if (this.panelContent.Controls.Count > 0)
                this.panelContent.Controls.RemoveAt(0);
            Form fh = Form1 as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(fh);
            this.panelContent.Tag = fh;
            fh.Show();
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {
            FormDansPanel(new produits());
        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SoldeRefresh_Tick(object sender, EventArgs e)
        {
            UpdateCaisse();
        }

        private void btnVentes_Click(object sender, EventArgs e)
        {
            OpenXmlDocument xml = new OpenXmlDocument();
            xml.CreerFacture();
        }
    }
}
