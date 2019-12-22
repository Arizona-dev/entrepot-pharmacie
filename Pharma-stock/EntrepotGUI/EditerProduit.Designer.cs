namespace EntrepotGUI
{
    partial class EditerProduit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditerProduit));
            this.panel2 = new System.Windows.Forms.Panel();
            this.TitreAjouterProduit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelMarge = new System.Windows.Forms.Label();
            this.margeTextbox = new System.Windows.Forms.TextBox();
            this.prixHtLabel = new System.Windows.Forms.Label();
            this.prixhtTextbox = new System.Windows.Forms.TextBox();
            this.descLabel = new System.Windows.Forms.Label();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.NomProduitLabel = new System.Windows.Forms.Label();
            this.nomProduitTextbox = new System.Windows.Forms.TextBox();
            this.refArticleLabel = new System.Windows.Forms.Label();
            this.refProduitTextbox = new System.Windows.Forms.TextBox();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnAnnulerEditer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Controls.Add(this.TitreAjouterProduit);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 30);
            this.panel2.TabIndex = 16;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // TitreAjouterProduit
            // 
            this.TitreAjouterProduit.AutoSize = true;
            this.TitreAjouterProduit.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitreAjouterProduit.ForeColor = System.Drawing.SystemColors.Window;
            this.TitreAjouterProduit.Location = new System.Drawing.Point(9, 3);
            this.TitreAjouterProduit.Name = "TitreAjouterProduit";
            this.TitreAjouterProduit.Size = new System.Drawing.Size(145, 23);
            this.TitreAjouterProduit.TabIndex = 8;
            this.TitreAjouterProduit.Text = "Editer un produit";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
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
            this.panel1.TabIndex = 15;
            // 
            // labelMarge
            // 
            this.labelMarge.AutoSize = true;
            this.labelMarge.Location = new System.Drawing.Point(309, 56);
            this.labelMarge.Name = "labelMarge";
            this.labelMarge.Size = new System.Drawing.Size(37, 13);
            this.labelMarge.TabIndex = 18;
            this.labelMarge.Text = "Marge";
            // 
            // margeTextbox
            // 
            this.margeTextbox.Location = new System.Drawing.Point(358, 53);
            this.margeTextbox.MaxLength = 100;
            this.margeTextbox.Name = "margeTextbox";
            this.margeTextbox.Size = new System.Drawing.Size(137, 20);
            this.margeTextbox.TabIndex = 6;
            // 
            // prixHtLabel
            // 
            this.prixHtLabel.AutoSize = true;
            this.prixHtLabel.Location = new System.Drawing.Point(304, 20);
            this.prixHtLabel.Name = "prixHtLabel";
            this.prixHtLabel.Size = new System.Drawing.Size(42, 13);
            this.prixHtLabel.TabIndex = 16;
            this.prixHtLabel.Text = "Prix HT";
            // 
            // prixhtTextbox
            // 
            this.prixhtTextbox.Location = new System.Drawing.Point(358, 17);
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
            // refProduitTextbox
            // 
            this.refProduitTextbox.Location = new System.Drawing.Point(100, 17);
            this.refProduitTextbox.MaxLength = 45;
            this.refProduitTextbox.Name = "refProduitTextbox";
            this.refProduitTextbox.Size = new System.Drawing.Size(137, 20);
            this.refProduitTextbox.TabIndex = 1;
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.BackColor = System.Drawing.Color.Transparent;
            this.btnEditProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEditProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditProduct.FlatAppearance.BorderSize = 0;
            this.btnEditProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnEditProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProduct.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProduct.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnEditProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnEditProduct.Image")));
            this.btnEditProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditProduct.Location = new System.Drawing.Point(401, 259);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEditProduct.Size = new System.Drawing.Size(121, 40);
            this.btnEditProduct.TabIndex = 13;
            this.btnEditProduct.Tag = "";
            this.btnEditProduct.Text = "Editer";
            this.btnEditProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditProduct.UseVisualStyleBackColor = false;
            this.btnEditProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnAnnulerEditer
            // 
            this.btnAnnulerEditer.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnulerEditer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAnnulerEditer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnnulerEditer.FlatAppearance.BorderSize = 0;
            this.btnAnnulerEditer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnAnnulerEditer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnulerEditer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulerEditer.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnAnnulerEditer.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnulerEditer.Image")));
            this.btnAnnulerEditer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnnulerEditer.Location = new System.Drawing.Point(12, 259);
            this.btnAnnulerEditer.Name = "btnAnnulerEditer";
            this.btnAnnulerEditer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAnnulerEditer.Size = new System.Drawing.Size(121, 40);
            this.btnAnnulerEditer.TabIndex = 14;
            this.btnAnnulerEditer.Tag = "";
            this.btnAnnulerEditer.Text = "Annuler";
            this.btnAnnulerEditer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnnulerEditer.UseVisualStyleBackColor = false;
            this.btnAnnulerEditer.Click += new System.EventHandler(this.btnAnnulerAjout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Prix de vente";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(358, 89);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 19;
            // 
            // EditerProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEditProduct);
            this.Controls.Add(this.btnAnnulerEditer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditerProduit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditerProduit";
            this.TopMost = true;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TitreAjouterProduit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelMarge;
        private System.Windows.Forms.TextBox margeTextbox;
        private System.Windows.Forms.Label prixHtLabel;
        private System.Windows.Forms.TextBox prixhtTextbox;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.Label NomProduitLabel;
        private System.Windows.Forms.TextBox nomProduitTextbox;
        private System.Windows.Forms.Label refArticleLabel;
        private System.Windows.Forms.TextBox refProduitTextbox;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnAnnulerEditer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}