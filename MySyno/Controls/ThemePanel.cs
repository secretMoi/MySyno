using System.Windows.Forms;

namespace MySyno.Controls
{
    public partial class ThemePanel : UserControl
    {
        protected static SSH Ssh;
        public ThemePanel()
        {
            InitializeComponent();
        }

        public void SetConnection(SSH ssh)
        {
            Ssh = ssh;
        }
    }
}
