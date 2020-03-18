using System;
using System.Threading;
using Renci.SshNet;

namespace MySyno
{
    public class SSH
    {
        private string user;
        private string password;
        private string host;
        private int port;

        private readonly SshClient client;
        private static readonly Mutex VerrouMutex = new Mutex();

        // Declare the event using EventHandler<T>
        public event EventHandler<CommandEventArgs> CommandeEvent;


        public SSH(string host, string user, string password, int port = 22)
        {
            this.user = user;
            this.password = password;
            this.host = host;
            this.port = port;

            client = new SshClient(host, port, user, password);
        }

        public void Connect()
        {
            Thread threadConnect = new Thread(ThreadConnect);
            threadConnect.Start();
        }

        private void ThreadConnect()
        {
            if (client.IsConnected) return;

            VerrouMutex.WaitOne();

            client.Connect();

            VerrouMutex.ReleaseMutex();
        }

        public void Disconnect()
        {
            Thread threadClose = new Thread(Close);
            threadClose.Start();
        }

        public void SendCommand(string commande, EventHandler<CommandEventArgs> resultat = null)
        {
            if(resultat != null)
                CommandeEvent += resultat;

            Thread t = new Thread(() => RunCommand(commande));
            t.Start();
        }

        private void RunCommand(string commande)
        {
            VerrouMutex.WaitOne();

            if (client != null)
            {
                if (client.IsConnected)
                {
                    SshCommand sc = client.CreateCommand(commande);
                    sc.Execute();
                    string resultat = sc.Result;

                    Commande_Event(new CommandEventArgs(resultat));
                }
            }
            
            VerrouMutex.ReleaseMutex();
        }

        private void Close()
        {
            VerrouMutex.WaitOne();

            if (client.IsConnected)
                client.Disconnect();

            client.Dispose();

            VerrouMutex.ReleaseMutex();
        }

        private void Commande_Event(CommandEventArgs e)
        {
            // invoke la fonction de retour
            CommandeEvent?.Invoke(this, e);
        }
    }

    // class qui permet de transmettre les arguments
    public class CommandEventArgs : EventArgs
    {
        public CommandEventArgs(string s)
        {
            Message = s;
        }

        public string Message { get; set; }
    }
}
