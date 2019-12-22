namespace EntrepotGUI
{
    partial class AjouterProduit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjouterProduit));
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnAnnulerAjout = new System.Windows.Forms.Button();
            this.TitreAjouterProduit = new System.Windows.Forms.Label();
            this.refProduitTextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.quantiteAchatArticle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.codeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMarge = new System.Windows.Forms.Label();
            this.margeTextbox = new System.Windows.Forms.TextBox();
            this.prixHtLabel = new System.Windows.Forms.Label();
            this.prixhtTextbox = new System.Windows.Forms.TextBox();
            this.descLabel = new System.Windows.Forms.Label();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.NomProduitLabel = new System.Windows.Forms.Label();
            this.nomProduitTextbox = new System.Windows.Forms.TextBox();
            this.refArticleLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.Transparent;
            this.btnAddProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProduct.Image")));
            this.btnAddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduct.Location = new System.Drawing.Point(401, 259);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddProduct.Size = new System.Drawing.Size(121, 40);
            this.btnAddProduct.TabIndex = 8;
            this.btnAddProduct.Tag = "";
            this.btnAddProduct.Text = "Ajouter";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnAnnulerAjout
            // 
            this.btnAnnulerAjout.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnulerAjout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAnnulerAjout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnnulerAjout.FlatAppearance.BorderSize = 0;
            this.btnAnnulerAjout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnAnnulerAjout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnulerAjout.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulerAjout.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnAnnulerAjout.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnulerAjout.Image")));
            this.btnAnnulerAjout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnnulerAjout.Location = new System.Drawing.Point(12, 259);
            this.btnAnnulerAjout.Name = "btnAnnulerAjout";
            this.btnAnnulerAjout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAnnulerAjout.Size = new System.Drawing.Size(121, 40);
            this.btnAnnulerAjout.TabIndex = 9;
            this.btnAnnulerAjout.Tag = "";
            this.btnAnnulerAjout.Text = "Annuler";
            this.btnAnnulerAjout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnnulerAjout.UseVisualStyleBackColor = false;
            this.btnAnnulerAjout.Click += new System.EventHandler(this.btnAnnulerAjout_Click);
            // 
            // TitreAjouterProduit
            // 
            this.TitreAjouterProduit.AutoSize = true;
            this.TitreAjouterProduit.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitreAjouterProduit.ForeColor = System.Drawing.SystemColors.Window;
            this.TitreAjouterProduit.Location = new System.Drawing.Point(9, 3);
            this.TitreAjouterProduit.Name = "TitreAjouterProduit";
            this.TitreAjouterProduit.Size = new System.Drawing.Size(158, 23);
            this.TitreAjouterProduit.TabIndex = 8;
            this.TitreAjouterProduit.Text = "Ajouter un produit";
            // 
            // refProduitTextbox
            // 
            this.refProduitTextbox.Location = new System.Drawing.Point(100, 17);
            this.refProduitTextbox.MaxLength = 45;
            this.refProduitTextbox.Name = "refProduitTextbox";
            this.refProduitTextbox.Size = new System.Drawing.Size(137, 20);
            this.refProduitTextbox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.quantiteAchatArticle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.codeComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelMarge);
            this.panel1.Controls.Add(this.margeTextbox);
            this.panel1.Controls.Add(this.prixHtLabel);
            this.panel1.Controls.Add(this.prixhtTextbox);
            this.panel1.Controls.Add(this.descLabel);
            this.panel1.Controls.Add(this.descriptionTextbox);
            this.panel1.Controls.Add(this.NomProduitLabel);
            this.panel1.Controls.Add(this.nomProduitTextbox);
            this.panel1.Controls.Add(this.refArticleLabel);
            this.panel1.Controls.Add(this.refProduitTextbox);
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 204);
            this.panel1.TabIndex = 10;
            // 
            // quantiteAchatArticle
            // 
            this.quantiteAchatArticle.FormattingEnabled = true;
            this.quantiteAchatArticle.Items.AddRange(new object[] {
            "1",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "2",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "3",
            "30",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.quantiteAchatArticle.Location = new System.Drawing.Point(361, 88);
            this.quantiteAchatArticle.Name = "quantiteAchatArticle";
            this.quantiteAchatArticle.Size = new System.Drawing.Size(137, 21);
            this.quantiteAchatArticle.Sorted = true;
            this.quantiteAchatArticle.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(254, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Quantité à acheter";
            // 
            // codeComboBox
            // 
            this.codeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codeComboBox.FormattingEnabled = true;
            this.codeComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.codeComboBox.Location = new System.Drawing.Point(100, 126);
            this.codeComboBox.Name = "codeComboBox";
            this.codeComboBox.Size = new System.Drawing.Size(137, 21);
            this.codeComboBox.Sorted = true;
            this.codeComboBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Code Fournisseur";
            // 
            // labelMarge
            // 
            this.labelMarge.AutoSize = true;
            this.labelMarge.Location = new System.Drawing.Point(312, 56);
            this.labelMarge.Name = "labelMarge";
            this.labelMarge.Size = new System.Drawing.Size(37, 13);
            this.labelMarge.TabIndex = 18;
            this.labelMarge.Text = "Marge";
            // 
            // margeTextbox
            // 
            this.margeTextbox.Location = new System.Drawing.Point(361, 53);
            this.margeTextbox.MaxLength = 100;
            this.margeTextbox.Name = "margeTextbox";
            this.margeTextbox.Size = new System.Drawing.Size(137, 20);
            this.margeTextbox.TabIndex = 6;
            // 
            // prixHtLabel
            // 
            this.prixHtLabel.AutoSize = true;
            this.prixHtLabel.Location = new System.Drawing.Point(307, 20);
            this.prixHtLabel.Name = "prixHtLabel";
            this.prixHtLabel.Size = new System.Drawing.Size(42, 13);
            this.prixHtLabel.TabIndex = 16;
            this.prixHtLabel.Text = "Prix HT";
            // 
            // prixhtTextbox
            // 
            this.prixhtTextbox.Location = new System.Drawing.Point(361, 17);
            this.prixhtTextbox.MaxLength = 100;
            this.prixhtTextbox.Name = "prixhtTextbox";
            this.prixhtTextbox.Size = new System.Drawing.Size(137, 20);
            this.prixhtTextbox.TabIndex = 5;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(9, 92);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(60, 13);
            this.descLabel.TabIndex = 14;
            this.descLabel.Text = "Description";
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Location = new System.Drawing.Point(100, 89);
            this.descriptionTextbox.MaxLength = 100;
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(137, 20);
            this.descriptionTextbox.TabIndex = 3;
            // 
            // NomProduitLabel
            // 
            this.NomProduitLabel.AutoSize = true;
            this.NomProduitLabel.Location = new System.Drawing.Point(9, 55);
            this.NomProduitLabel.Name = "NomProduitLabel";
            this.NomProduitLabel.Size = new System.Drawing.Size(79, 13);
            this.NomProduitLabel.TabIndex = 12;
            this.NomProduitLabel.Text = "Nom du produit";
            // 
            // nomProduitTextbox
            // 
            this.nomProduitTextbox.Location = new System.Drawing.Point(100, 52);
            this.nomProduitTextbox.MaxLength = 45;
            this.nomProduitTextbox.Name = "nomProduitTextbox";
            this.nomProduitTextbox.Size = new System.Drawing.Size(137, 20);
            this.nomProduitTextbox.TabIndex = 2;
            // 
            // refArticleLabel
            // 
            this.refArticleLabel.AutoSize = true;
            this.refArticleLabel.Location = new System.Drawing.Point(9, 20);
            this.refArticleLabel.Name = "refArticleLabel";
            this.refArticleLabel.Size = new System.Drawing.Size(82, 13);
            this.refArticleLabel.TabIndex = 10;
            this.refArticleLabel.Text = "N° de référence";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Controls.Add(this.TitreAjouterProduit);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 30);
            this.panel2.TabIndex = 12;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Prix de vente";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(361, 126);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 25;
            // 
            // AjouterProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnAnnulerAjout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AjouterProduit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AjouterProduit";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Label TitreAjouterProduit;
        private System.Windows.Forms.TextBox refProduitTextbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAnnulerAjout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label refArticleLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.Label NomProduitLabel;
        private System.Windows.Forms.TextBox nomProduitTextbox;
        private System.Windows.Forms.Label prixHtLabel;
        private System.Windows.Forms.TextBox prixhtTextbox;
        private System.Windows.Forms.Label labelMarge;
        private System.Windows.Forms.TextBox margeTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox codeComboBox;
        private System.Windows.Forms.ComboBox quantiteAchatArticle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}