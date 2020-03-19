using System.Drawing;
using System.Windows.Forms;

namespace MySyno.Controls.Buttons
{
    public partial class MenuFlatButton : FlatButton
    {
        public MenuFlatButton()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(25, 118, 211);
            ImageAlign = ContentAlignment.MiddleLeft;
            Size = new Size(275, 70);
            TextImageRelation = TextImageRelation.ImageBeforeText;
        }
    }
}
