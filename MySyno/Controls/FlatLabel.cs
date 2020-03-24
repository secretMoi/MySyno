using System.Windows.Forms;

namespace MySyno.Controls
{
    public partial class FlatLabel : Label
    {
        public FlatLabel()
        {
            InitializeComponent();

            ForeColor = Theme.Texte;
            Font = Theme.Font;
        }
    }
}
