﻿namespace MySyno.Controls
{
    partial class FlatListBox
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelTitre = new System.Windows.Forms.Label();
            this.panelTitre = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelCorps = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelTitre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.ForeColor = System.Drawing.Color.White;
            this.labelTitre.Location = new System.Drawing.Point(3, 11);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(52, 21);
            this.labelTitre.TabIndex = 0;
            this.labelTitre.Text = "label1";
            this.labelTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitre_MouseDown);
            // 
            // panelTitre
            // 
            this.panelTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.panelTitre.Controls.Add(this.pictureBox);
            this.panelTitre.Controls.Add(this.labelTitre);
            this.panelTitre.Location = new System.Drawing.Point(0, 0);
            this.panelTitre.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitre.Name = "panelTitre";
            this.panelTitre.Size = new System.Drawing.Size(150, 40);
            this.panelTitre.TabIndex = 1;
            this.panelTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitre_MouseDown);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::MySyno.Properties.Resources.down_arrow;
            this.pictureBox.Location = new System.Drawing.Point(123, 8);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(24, 24);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitre_MouseDown);
            // 
            // panelCorps
            // 
            this.panelCorps.Location = new System.Drawing.Point(0, 40);
            this.panelCorps.Margin = new System.Windows.Forms.Padding(0);
            this.panelCorps.Name = "panelCorps";
            this.panelCorps.Size = new System.Drawing.Size(150, 0);
            this.panelCorps.TabIndex = 2;
            // 
            // timer
            // 
            this.timer.Interval = 15;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FlatListBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.panelTitre);
            this.Controls.Add(this.panelCorps);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(150, 40);
            this.MinimumSize = new System.Drawing.Size(150, 40);
            this.Name = "FlatListBox";
            this.Size = new System.Drawing.Size(150, 40);
            this.panelTitre.ResumeLayout(false);
            this.panelTitre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.Panel panelTitre;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panelCorps;
        private System.Windows.Forms.Timer timer;
    }
}
