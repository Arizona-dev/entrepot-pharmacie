namespace EntrepotGUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.soldeLabel = new System.Windows.Forms.Label();
            this.btnMore = new System.Windows.Forms.Button();
            this.btnEntrepot = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnVentes = new System.Windows.Forms.Button();
            this.btnProduits = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.SoldeRefresh = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelMenu.Controls.Add(this.btnMore);
            this.panelMenu.Controls.Add(this.btnEntrepot);
            this.panelMenu.Controls.Add(this.btnClients);
            this.panelMenu.Controls.Add(this.btnVentes);
            this.panelMenu.Controls.Add(this.btnProduits);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(180, 461);
            this.panelMenu.TabIndex = 0;
            // 
            // soldeLabel
            // 
            this.soldeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.soldeLabel.AutoSize = true;
            this.soldeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.soldeLabel.ForeColor = System.Drawing.Color.Black;
            this.soldeLabel.Location = new System.Drawing.Point(487, 9);
            this.soldeLabel.Name = "soldeLabel";
            this.soldeLabel.Size = new System.Drawing.Size(99, 19);
            this.soldeLabel.TabIndex = 6;
            this.soldeLabel.Text = "Solde : 0,00 €";
            // 
            // btnMore
            // 
            this.btnMore.BackColor = System.Drawing.Color.Transparent;
            this.btnMore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMore.FlatAppearance.BorderSize = 0;
            this.btnMore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMore.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMore.Image = ((System.Drawing.Image)(resources.GetObject("btnMore.Image")));
            this.btnMore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMore.Location = new System.Drawing.Point(0, 300);
            this.btnMore.Name = "btnMore";
            this.btnMore.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMore.Size = new System.Drawing.Size(180, 40);
            this.btnMore.TabIndex = 5;
            this.btnMore.Tag = "";
            this.btnMore.Text = "Caisse";
            this.btnMore.UseVisualStyleBackColor = false;
            // 
            // btnEntrepot
            // 
            this.btnEntrepot.BackColor = System.Drawing.Color.Transparent;
            this.btnEntrepot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEntrepot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrepot.FlatAppearance.BorderSize = 0;
            this.btnEntrepot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnEntrepot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrepot.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrepot.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEntrepot.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrepot.Image")));
            this.btnEntrepot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntrepot.Location = new System.Drawing.Point(0, 250);
            this.btnEntrepot.Name = "btnEntrepot";
            this.btnEntrepot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEntrepot.Size = new System.Drawing.Size(180, 40);
            this.btnEntrepot.TabIndex = 4;
            this.btnEntrepot.Tag = "";
            this.btnEntrepot.Text = "Entrepot";
            this.btnEntrepot.UseVisualStyleBackColor = false;
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.Transparent;
            this.btnClients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClients.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClients.Image = ((System.Drawing.Image)(resources.GetObject("btnClients.Image")));
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.Location = new System.Drawing.Point(0, 200);
            this.btnClients.Name = "btnClients";
            this.btnClients.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClients.Size = new System.Drawing.Size(180, 40);
            this.btnClients.TabIndex = 3;
            this.btnClients.Tag = "";
            this.btnClients.Text = "Clients";
            this.btnClients.UseVisualStyleBackColor = false;
            // 
            // btnVentes
            // 
            this.btnVentes.BackColor = System.Drawing.Color.Transparent;
            this.btnVentes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnVentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentes.FlatAppearance.BorderSize = 0;
            this.btnVentes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnVentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentes.ForeColor = System.Drawing.SystemColors.Control;
            this.btnVentes.Image = ((System.Drawing.Image)(resources.GetObject("btnVentes.Image")));
            this.btnVentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentes.Location = new System.Drawing.Point(0, 150);
            this.btnVentes.Name = "btnVentes";
            this.btnVentes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnVentes.Size = new System.Drawing.Size(180, 40);
            this.btnVentes.TabIndex = 2;
            this.btnVentes.Tag = "";
            this.btnVentes.Text = "Ventes";
            this.btnVentes.UseVisualStyleBackColor = false;
            this.btnVentes.Click += new System.EventHandler(this.btnVentes_Click);
            // 
            // btnProduits
            // 
            this.btnProduits.BackColor = System.Drawing.Color.Transparent;
            this.btnProduits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProduits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduits.FlatAppearance.BorderSize = 0;
            this.btnProduits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnProduits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduits.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduits.ForeColor = System.Drawing.SystemColors.Control;
            this.btnProduits.Image = ((System.Drawing.Image)(resources.GetObject("btnProduits.Image")));
            this.btnProduits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduits.Location = new System.Drawing.Point(0, 100);
            this.btnProduits.Name = "btnProduits";
            this.btnProduits.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnProduits.Size = new System.Drawing.Size(180, 40);
            this.btnProduits.TabIndex = 1;
            this.btnProduits.Tag = "";
            this.btnProduits.Text = "Produits";
            this.btnProduits.UseVisualStyleBackColor = false;
            this.btnProduits.Click += new System.EventHandler(this.btnProduits_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 57);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gestion de stock\r\nPharmacie\r\nDemo\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EntrepotGUI.Properties.Resources.medicine;
            this.pictureBox1.Location = new System.Drawing.Point(2, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTitle.Controls.Add(this.soldeLabel);
            this.panelTitle.Controls.Add(this.buttonMinimize);
            this.panelTitle.Controls.Add(this.button1);
            this.panelTitle.Controls.Add(this.buttonClose);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(180, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(704, 40);
            this.panelTitle.TabIndex = 1;
            this.panelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitle_Paint);
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimize.BackgroundImage = global::EntrepotGUI.Properties.Resources.minimize;
            this.buttonMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Font = new System.Drawing.Font("Calibri", 10F);
            this.buttonMinimize.Location = new System.Drawing.Point(646, 8);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(20, 20);
            this.buttonMinimize.TabIndex = 11;
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackgroundImage = global::EntrepotGUI.Properties.Resources.close__3_;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Calibri", 10F);
            this.buttonClose.Location = new System.Drawing.Point(672, 8);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(20, 20);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Tag = "";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.button_close_Click);
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.Location = new System.Drawing.Point(180, 40);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(704, 421);
            this.panelContent.TabIndex = 2;
            // 
            // SoldeRefresh
            // 
            this.SoldeRefresh.Interval = 1000;
            this.SoldeRefresh.Tick += new System.EventHandler(this.SoldeRefresh_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de stock pour Pharmacie - Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button btnProduits;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Button btnEntrepot;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnVentes;
        internal System.Windows.Forms.Label soldeLabel;
        private System.Windows.Forms.Timer SoldeRefresh;
    }
}

