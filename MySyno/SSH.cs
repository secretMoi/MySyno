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

        private bool _disposed;

        private readonly SshClient client;
        private static readonly Mutex VerrouMutex = new Mutex();

        // Declare the event using EventHandler<T>
        public event EventHandler<CommandEventArgs> CommandeEvent;
        public event EventHandler<CommandEventArgs> ConnectEvent;
        public event EventHandler<CommandEventArgs> DisconnectEvent;

        public SSH(string host, string user, string password, int port = 22)
        {
            this.user = user;
            this.password = password;
            this.host = host;
            this.port = port;

            client = new SshClient(host, port, user, password);

            _disposed = false;
        }

        public void Connect(EventHandler<CommandEventArgs> resultat = null)
        {
            if (resultat != null)
                ConnectEvent += resultat;

            Thread threadConnect = new Thread(ThreadConnect);
            threadConnect.Start();
        }

        private void ThreadConnect()
        {
            if(!_disposed)
                if (client.IsConnected) return;

            VerrouMutex.WaitOne();

            try
            {
                client.Connect();
                Connect_Event(new CommandEventArgs(null));
            }
            catch
            {
            }

            VerrouMutex.ReleaseMutex();
        }

        public void Disconnect(EventHandler<CommandEventArgs> resultat = null)
        {
            if (resultat != null)
                DisconnectEvent += resultat;

            Thread threadClose = new Thread(Close);
            threadClose.Start();
        }

        public void SendCommand(string commande, EventHandler<CommandEventArgs> resultat = null, int id = 0)
        {
            if(resultat != null)
                CommandeEvent += resultat;

            Thread t = new Thread(() => RunCommand(commande, id));
            t.Start();
        }

        private void RunCommand(string commande, int id)
        {
            VerrouMutex.WaitOne();

            if (client != null && !_disposed)
            {
                if (client.IsConnected)
                {
                    SshCommand sc = client.CreateCommand(commande);
                    sc.Execute();
                    string resultat = sc.Result;

                    Commande_Event(new CommandEventArgs(resultat, id));
                }
            }
            
            VerrouMutex.ReleaseMutex();
        }

        private void Close()
        {
            VerrouMutex.WaitOne();

            if (!_disposed && client.IsConnected)
                client.Disconnect();

            Disconnect_Event(new CommandEventArgs(null));

            VerrouMutex.ReleaseMutex();
        }

        public void Dispose()
        {
            client.Dispose();

            _disposed = true;
        }

        private void Commande_Event(CommandEventArgs e)
        {
            // invoke la fonction de retour
            CommandeEvent?.Invoke(this, e);
        }

        private void Connect_Event(CommandEventArgs e)
        {
            // invoke la fonction de retour
            ConnectEvent?.Invoke(this, e);
        }

        private void Disconnect_Event(CommandEventArgs e)
        {
            // invoke la fonction de retour
            DisconnectEvent?.Invoke(this, e);
        }

        public bool IsConnected => !_disposed && client.IsConnected;
    }

    // class qui permet de transmettre les arguments
    public class CommandEventArgs : EventArgs
    {
        public CommandEventArgs(string s, int id = 0)
        {
            Message = s;
            Id = id;
        }

        public int Id { get; set; }

        public string Message { get; set; }
    }
}
