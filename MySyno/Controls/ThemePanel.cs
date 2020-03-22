using System;
using System.Windows.Forms;

namespace MySyno.Controls
{
    public partial class ThemePanel : UserControl
    {
        protected static SSH Ssh;
        public ThemePanel()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }

        protected void Invoque(EventHandler<CommandEventArgs> listePartitions, object sender, CommandEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                listePartitions(sender, e);
            });
        }

        public static void SetConnection(SSH ssh)
        {
            Ssh = ssh;
        }
    }
}
