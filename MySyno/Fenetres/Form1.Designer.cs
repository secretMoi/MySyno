namespace MySyno.Fenetres
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuApplications_UtilisationDisque = new System.Windows.Forms.ToolStripMenuItem();
            this.menuApplications_RepartitionGourmande = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menu_Disques_Utilisation = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1072, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuApplications_UtilisationDisque,
            this.menuApplications_RepartitionGourmande});
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // menuApplications_UtilisationDisque
            // 
            this.menuApplications_UtilisationDisque.Name = "menuApplications_UtilisationDisque";
            this.menuApplications_UtilisationDisque.Size = new System.Drawing.Size(209, 22);
            this.menuApplications_UtilisationDisque.Text = "Utilisation des disques";
            this.menuApplications_UtilisationDisque.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuApplications_RepartitionGourmande
            // 
            this.menuApplications_RepartitionGourmande.Name = "menuApplications_RepartitionGourmande";
            this.menuApplications_RepartitionGourmande.Size = new System.Drawing.Size(209, 22);
            this.menuApplications_RepartitionGourmande.Text = "Répartition espace disque";
            this.menuApplications_RepartitionGourmande.Click += new System.EventHandler(this.Menu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(193)))));
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.menu_Disques_Utilisation);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 600);
            this.panel1.TabIndex = 3;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
            this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClose.Location = new System.Drawing.Point(0, 525);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(275, 75);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "   Quitter";
            this.buttonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(275, 66);
            this.button2.TabIndex = 2;
            this.button2.Text = "   Répartition espace disque";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // menu_Disques_Utilisation
            // 
            this.menu_Disques_Utilisation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.menu_Disques_Utilisation.FlatAppearance.BorderSize = 0;
            this.menu_Disques_Utilisation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_Disques_Utilisation.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Disques_Utilisation.ForeColor = System.Drawing.Color.White;
            this.menu_Disques_Utilisation.Image = ((System.Drawing.Image)(resources.GetObject("menu_Disques_Utilisation.Image")));
            this.menu_Disques_Utilisation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_Disques_Utilisation.Location = new System.Drawing.Point(0, 136);
            this.menu_Disques_Utilisation.Name = "menu_Disques_Utilisation";
            this.menu_Disques_Utilisation.Size = new System.Drawing.Size(275, 66);
            this.menu_Disques_Utilisation.TabIndex = 1;
            this.menu_Disques_Utilisation.Text = "   Utilisation des disques";
            this.menu_Disques_Utilisation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_Disques_Utilisation.UseVisualStyleBackColor = false;
            this.menu_Disques_Utilisation.Click += new System.EventHandler(this.Menu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(47, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelContainer
            // 
            this.panelContainer.Location = new System.Drawing.Point(272, 24);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 600);
            this.panelContainer.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1072, 624);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuApplications_UtilisationDisque;
        private System.Windows.Forms.ToolStripMenuItem menuApplications_RepartitionGourmande;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button menu_Disques_Utilisation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button buttonClose;
    }
}

