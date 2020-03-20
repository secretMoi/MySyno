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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuFlatButtonClose = new MySyno.Controls.Buttons.MenuFlatButton();
            this.panelSousMenuDisques = new System.Windows.Forms.Panel();
            this.menu_Disques_Repartition = new MySyno.Controls.Buttons.MenuFlatButton();
            this.menu_Disques_Utilisation = new MySyno.Controls.Buttons.MenuFlatButton();
            this.menu_Disques = new MySyno.Controls.Buttons.MenuFlatButton();
            this.menu_Accueil = new MySyno.Controls.Buttons.MenuFlatButton();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxReduce = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerMenuDeroulant = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxResize = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelSousMenuDisques.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReduce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResize)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(193)))));
            this.panelMenu.Controls.Add(this.menuFlatButtonClose);
            this.panelMenu.Controls.Add(this.panelSousMenuDisques);
            this.panelMenu.Controls.Add(this.menu_Disques);
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
            this.menuFlatButtonClose.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // panelSousMenuDisques
            // 
            this.panelSousMenuDisques.Controls.Add(this.menu_Disques_Repartition);
            this.panelSousMenuDisques.Controls.Add(this.menu_Disques_Utilisation);
            this.panelSousMenuDisques.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSousMenuDisques.Location = new System.Drawing.Point(0, 140);
            this.panelSousMenuDisques.MaximumSize = new System.Drawing.Size(275, 140);
            this.panelSousMenuDisques.Name = "panelSousMenuDisques";
            this.panelSousMenuDisques.Size = new System.Drawing.Size(275, 140);
            this.panelSousMenuDisques.TabIndex = 8;
            // 
            // menu_Disques_Repartition
            // 
            this.menu_Disques_Repartition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
            this.menu_Disques_Repartition.FlatAppearance.BorderSize = 0;
            this.menu_Disques_Repartition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_Disques_Repartition.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Disques_Repartition.ForeColor = System.Drawing.Color.White;
            this.menu_Disques_Repartition.Image = global::MySyno.Properties.Resources.pie_chart;
            this.menu_Disques_Repartition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_Disques_Repartition.Location = new System.Drawing.Point(0, 70);
            this.menu_Disques_Repartition.Name = "menu_Disques_Repartition";
            this.menu_Disques_Repartition.Size = new System.Drawing.Size(275, 70);
            this.menu_Disques_Repartition.TabIndex = 1;
            this.menu_Disques_Repartition.Text = "   Répartition";
            this.menu_Disques_Repartition.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_Disques_Repartition.UseVisualStyleBackColor = false;
            this.menu_Disques_Repartition.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menu_Disques_Utilisation
            // 
            this.menu_Disques_Utilisation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
            this.menu_Disques_Utilisation.FlatAppearance.BorderSize = 0;
            this.menu_Disques_Utilisation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_Disques_Utilisation.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Disques_Utilisation.ForeColor = System.Drawing.Color.White;
            this.menu_Disques_Utilisation.Image = ((System.Drawing.Image)(resources.GetObject("menu_Disques_Utilisation.Image")));
            this.menu_Disques_Utilisation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_Disques_Utilisation.Location = new System.Drawing.Point(0, 0);
            this.menu_Disques_Utilisation.Name = "menu_Disques_Utilisation";
            this.menu_Disques_Utilisation.Size = new System.Drawing.Size(275, 70);
            this.menu_Disques_Utilisation.TabIndex = 0;
            this.menu_Disques_Utilisation.Text = "   Utilisation des disques";
            this.menu_Disques_Utilisation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_Disques_Utilisation.UseVisualStyleBackColor = false;
            this.menu_Disques_Utilisation.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menu_Disques
            // 
            this.menu_Disques.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.menu_Disques.Dock = System.Windows.Forms.DockStyle.Top;
            this.menu_Disques.FlatAppearance.BorderSize = 0;
            this.menu_Disques.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_Disques.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Disques.ForeColor = System.Drawing.Color.White;
            this.menu_Disques.Image = ((System.Drawing.Image)(resources.GetObject("menu_Disques.Image")));
            this.menu_Disques.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_Disques.Location = new System.Drawing.Point(0, 70);
            this.menu_Disques.Name = "menu_Disques";
            this.menu_Disques.Size = new System.Drawing.Size(275, 70);
            this.menu_Disques.TabIndex = 6;
            this.menu_Disques.Text = "   Disques";
            this.menu_Disques.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_Disques.UseVisualStyleBackColor = false;
            this.menu_Disques.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menu_Accueil
            // 
            this.menu_Accueil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.menu_Accueil.Dock = System.Windows.Forms.DockStyle.Top;
            this.menu_Accueil.FlatAppearance.BorderSize = 0;
            this.menu_Accueil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_Accueil.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Accueil.ForeColor = System.Drawing.Color.White;
            this.menu_Accueil.Image = ((System.Drawing.Image)(resources.GetObject("menu_Accueil.Image")));
            this.menu_Accueil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_Accueil.Location = new System.Drawing.Point(0, 0);
            this.menu_Accueil.Name = "menu_Accueil";
            this.menu_Accueil.Size = new System.Drawing.Size(275, 70);
            this.menu_Accueil.TabIndex = 5;
            this.menu_Accueil.Text = "   Accueil";
            this.menu_Accueil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_Accueil.UseVisualStyleBackColor = false;
            this.menu_Accueil.Click += new System.EventHandler(this.Menu_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.pictureBoxReduce.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBoxReduce.Image = global::MySyno.Properties.Resources.minus;
            this.pictureBoxReduce.Location = new System.Drawing.Point(949, 30);
            this.pictureBoxReduce.Name = "pictureBoxReduce";
            this.pictureBoxReduce.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxReduce.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxReduce.TabIndex = 1;
            this.pictureBoxReduce.TabStop = false;
            this.pictureBoxReduce.Click += new System.EventHandler(this.pictureBoxReduce_Click);
            this.pictureBoxReduce.MouseEnter += new System.EventHandler(this.pictureBoxReduce_MouseEnter);
            this.pictureBoxReduce.MouseLeave += new System.EventHandler(this.pictureBoxReduce_MouseLeave);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBoxClose.Image = global::MySyno.Properties.Resources.close;
            this.pictureBoxClose.Location = new System.Drawing.Point(1011, 30);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 0;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.pictureBoxClose.MouseEnter += new System.EventHandler(this.pictureBoxClose_MouseEnter);
            this.pictureBoxClose.MouseLeave += new System.EventHandler(this.pictureBoxClose_MouseLeave);
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
            // timerMenuDeroulant
            // 
            this.timerMenuDeroulant.Interval = 15;
            this.timerMenuDeroulant.Tick += new System.EventHandler(this.timerMenuDeroulant_Tick);
            // 
            // pictureBoxResize
            // 
            this.pictureBoxResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxResize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pictureBoxResize.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxResize.Image")));
            this.pictureBoxResize.Location = new System.Drawing.Point(1046, 667);
            this.pictureBoxResize.Name = "pictureBoxResize";
            this.pictureBoxResize.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxResize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResize.TabIndex = 2;
            this.pictureBoxResize.TabStop = false;
            this.pictureBoxResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxResize_MouseDown);
            this.pictureBoxResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxResize_MouseMove);
            this.pictureBoxResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxResize_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1072, 693);
            this.Controls.Add(this.pictureBoxResize);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1072, 693);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MySyno";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panelMenu.ResumeLayout(false);
            this.panelSousMenuDisques.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReduce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelContainer;
        private Controls.Buttons.MenuFlatButton menu_Disques;
        private Controls.Buttons.MenuFlatButton menu_Accueil;
        private Controls.Buttons.MenuFlatButton menuFlatButtonClose;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxReduce;
        private System.Windows.Forms.Panel panelSousMenuDisques;
        private Controls.Buttons.MenuFlatButton menu_Disques_Repartition;
        private Controls.Buttons.MenuFlatButton menu_Disques_Utilisation;
        private System.Windows.Forms.PictureBox pictureBoxResize;
        private System.Windows.Forms.Timer timerMenuDeroulant;
    }
}

