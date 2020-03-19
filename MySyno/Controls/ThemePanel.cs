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

        public static void SetConnection(SSH ssh)
        {
            Ssh = ssh;
        }
    }
}
