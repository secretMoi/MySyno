namespace MySyno.Pages.Disques
{
    partial class Repartition
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
            this.graphicRepartition = new MySyno.Controls.GraphicRepartition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundedCheckbox1 = new MySyno.Controls.Checkbox.RoundedCheckbox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphicRepartition
            // 
            this.graphicRepartition.BackColor = System.Drawing.Color.White;
            this.graphicRepartition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicRepartition.Location = new System.Drawing.Point(0, 0);
            this.graphicRepartition.Name = "graphicRepartition";
            this.graphicRepartition.Size = new System.Drawing.Size(3776, 1753);
            this.graphicRepartition.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
            this.panel1.Controls.Add(this.roundedCheckbox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3776, 220);
            this.panel1.TabIndex = 1;
            // 
            // roundedCheckbox1
            // 
            this.roundedCheckbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(245)))));
            this.roundedCheckbox1.Location = new System.Drawing.Point(20, 17);
            this.roundedCheckbox1.Name = "roundedCheckbox1";
            this.roundedCheckbox1.Size = new System.Drawing.Size(100, 50);
            this.roundedCheckbox1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.graphicRepartition);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 220);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3776, 1753);
            this.panel2.TabIndex = 2;
            // 
            // Repartition
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Repartition";
            this.Size = new System.Drawing.Size(3776, 1973);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.GraphicRepartition graphicRepartition;
        private System.Windows.Forms.Panel panel1;
        private Controls.Checkbox.RoundedCheckbox roundedCheckbox1;
        private System.Windows.Forms.Panel panel2;
    }
}
