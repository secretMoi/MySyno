using System.Drawing;
using System.Windows.Forms;

namespace MySyno.Controls.Buttons
{
    public partial class FlatButton : Button
    {
        public FlatButton()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(33, 150, 245);
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            UseVisualStyleBackColor = false;
        }

        protected override bool ShowFocusCues => false;
    }
}
