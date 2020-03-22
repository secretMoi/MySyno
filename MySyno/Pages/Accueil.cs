using MySyno.Controls;

namespace MySyno.Pages
{
    public partial class Accueil : ThemePanel
    {
        public Accueil()
        {
            InitializeComponent();

            ChangeEtatConnection(null, null);

            Ssh.ConnectEvent += ChangeEtatConnection;
            Ssh.DisconnectEvent += ChangeEtatConnection;
        }

        public void ChangeEtatConnection(object sender, CommandEventArgs e)
        {
            if (InvokeRequired) // permet de lancer cette méthode via un autre thread
            {
                Invoque(ChangeEtatConnection, sender, e);
                return;
            }

            if (Ssh.IsConnected)
            {
                labelConnexion.Text = @"Connexion établie";
                buttonConnexion.Text = @"Se déconnecter";
            }
            else
            {
                labelConnexion.Text = @"Non connecté";
                buttonConnexion.Text = @"Se connecter";
            }
        }

        private void buttonConnexion_Click(object sender, System.EventArgs e)
        {
            if (Ssh.IsConnected)
                Ssh.Disconnect();
            else
                Ssh.Connect();
        }
    }
}
