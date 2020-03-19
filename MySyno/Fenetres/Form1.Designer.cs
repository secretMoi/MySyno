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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuFlatButtonClose = new MySyno.Controls.Buttons.MenuFlatButton();
            this.menu_Disques_Utilisation = new MySyno.Controls.Buttons.MenuFlatButton();
            this.menu_Accueil = new MySyno.Controls.Buttons.MenuFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxReduce = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReduce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(193)))));
            this.panelMenu.Controls.Add(this.menuFlatButtonClose);
            this.panelMenu.Controls.Add(this.menu_Disques_Utilisation);
            this.panelMenu.Controls.Add(this.menu_Accueil);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 94);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(275, 599);
            this.panelMenu.TabIndex = 3;
            // 
            // menuFlatButtonClose
            // 
            this.menuFlatButtonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.menuFlatButtonClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuFlatButtonClose.FlatAppearance.BorderSize = 0;
            this.menuFlatButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuFlatButtonClose.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuFlatButtonClose.ForeColor = System.Drawing.Color.White;
            this.menuFlatButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("menuFlatButtonClose.Image")));
            this.menuFlatButtonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuFlatButtonClose.Location = new System.Drawing.Point(0, 529);
            this.menuFlatButtonClose.Name = "menuFlatButtonClose";
            this.menuFlatButtonClose.Size = new System.Drawing.Size(275, 70);
            this.menuFlatButtonClose.TabIndex = 7;
            this.menuFlatButtonClose.Text = "   Quitter";
            this.menuFlatButtonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuFlatButtonClose.UseVisualStyleBackColor = false;
            this.menuFlatButtonClose.Click += new System.EventHandler(this.buttonClose_Click);
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
            this.menu_Disques_Utilisation.Location = new System.Drawing.Point(0, 70);
            this.menu_Disques_Utilisation.Name = "menu_Disques_Utilisation";
            this.menu_Disques_Utilisation.Size = new System.Drawing.Size(275, 70);
            this.menu_Disques_Utilisation.TabIndex = 6;
            this.menu_Disques_Utilisation.Text = "   Utilisation des disques";
            this.menu_Disques_Utilisation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_Disques_Utilisation.UseVisualStyleBackColor = false;
            this.menu_Disques_Utilisation.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menu_Accueil
            // 
            this.menu_Accueil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.menu_Accueil.FlatAppearance.BorderSize = 0;
            this.menu_Accueil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_Accueil.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Accueil.ForeColor = System.Drawing.Color.White;
            this.menu_Accueil.Image = ((System.Drawing.Image)(resources.GetObject("menu_Accueil.Image")));
            this.menu_Accueil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_Accueil.Location = new System.Drawing.Point(-3, 0);
            this.menu_Accueil.Name = "menu_Accueil";
            this.menu_Accueil.Size = new System.Drawing.Size(275, 70);
            this.menu_Accueil.TabIndex = 5;
            this.menu_Accueil.Text = "   Accueil";
            this.menu_Accueil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_Accueil.UseVisualStyleBackColor = false;
            this.menu_Accueil.Click += new System.EventHandler(this.Menu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(49, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelContainer
            // 
            this.panelContainer.Location = new System.Drawing.Point(272, 93);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 600);
            this.panelContainer.TabIndex = 4;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(193)))));
            this.panelHeader.Controls.Add(this.pictureBoxReduce);
            this.panelHeader.Controls.Add(this.pictureBoxClose);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1072, 94);
            this.panelHeader.TabIndex = 5;
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            // 
            // pictureBoxReduce
            // 
            this.pictureBoxReduce.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxReduce.Image")));
            this.pictureBoxReduce.Location = new System.Drawing.Point(942, 23);
            this.pictureBoxReduce.Name = "pictureBoxReduce";
            this.pictureBoxReduce.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxReduce.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxReduce.TabIndex = 1;
            this.pictureBoxReduce.TabStop = false;
            this.pictureBoxReduce.Click += new System.EventHandler(this.pictureBoxReduce_Click);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(1012, 23);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 0;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1072, 693);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelContainer);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReduce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelContainer;
        private Controls.Buttons.MenuFlatButton menu_Disques_Utilisation;
        private Controls.Buttons.MenuFlatButton menu_Accueil;
        private Controls.Buttons.MenuFlatButton menuFlatButtonClose;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxReduce;
    }
}

