using System;
using System.Threading;
using Renci.SshNet;

namespace MySyno
{
    public class SSH
    {
        private string _user;
        private string _password;
        private string _host;
        private int _port;

        private bool _disposed;

        private readonly SshClient client;
        private static readonly Mutex VerrouMutex = new Mutex();

        // Declare the event using EventHandler<T>
        public event EventHandler<CommandEventArgs> CommandeEvent;
        public event EventHandler<CommandEventArgs> ConnectEvent;
        public event EventHandler<CommandEventArgs> DisconnectEvent;

        private EventHandler<CommandEventArgs> LaunchCommandeEvent;

        public SSH(string host, string user, string password, int port = 22)
        {
            this._user = user;
            this._password = password;
            this._host = host;
            this._port = port;

            client = new SshClient(host, port, user, password);

            _disposed = false;

            LaunchCommandeEvent = CommandeEvent;
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
                //Connect_Event(new CommandEventArgs());
                LaunchEvent(new CommandEventArgs(), ConnectEvent);
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

        public void SendCommand(string commande, EventHandler<CommandEventArgs> resultat, int id, bool keepSubscriber)
        {
            if(resultat != null)
                CommandeEvent += resultat;

            Thread t = new Thread(() => RunCommand(resultat, commande, id, keepSubscriber));
            t.Start();
        }

        public void SendCommand(string commande, EventHandler<CommandEventArgs> resultat, bool keepSubscriber)
        {
            SendCommand(commande, resultat, 0, keepSubscriber);
        }

        public void SendCommand(string commande, EventHandler<CommandEventArgs> resultat, int id)
        {
            SendCommand(commande, resultat, id, false);
        }

        public void SendCommand(string commande, EventHandler<CommandEventArgs> resultat)
        {
            SendCommand(commande, resultat, 0, false);
        }

        // todo uliser mutex différent pour avoir plusieurs commandes en même temps
        private void RunCommand(EventHandler<CommandEventArgs> fonctionRetour, string commande, int id, bool keepSubsciber)
        {
            VerrouMutex.WaitOne();

            if (client != null && !_disposed)
            {
                if (client.IsConnected)
                {
                    SshCommand sc = client.CreateCommand(commande);
                    sc.Execute();
                    string resultat = sc.Result;

                    //Commande_Event(new CommandEventArgs(resultat, id, keepSubsciber));
                    LaunchEvent(new CommandEventArgs(resultat, id, keepSubsciber), CommandeEvent);

                    if (!keepSubsciber)
                        CommandeEvent -= fonctionRetour;
                }
            }
            
            VerrouMutex.ReleaseMutex();
        }

        private void Close()
        {
            VerrouMutex.WaitOne();

            if (!_disposed && client.IsConnected)
                client.Disconnect();

            //Disconnect_Event(new CommandEventArgs());
            LaunchEvent(new CommandEventArgs(), DisconnectEvent);

            VerrouMutex.ReleaseMutex();
        }

        public void Dispose()
        {
            client.Dispose();

            _disposed = true;
        }

        private void LaunchEvent(CommandEventArgs e, EventHandler<CommandEventArgs> handler)
        {
            handler?.Invoke(this, e);
        }

        /*private void Commande_Event(CommandEventArgs e)
        {
            // fait une copie temporaire si un subsciber quitte avant d'avoir reçu sa réponse
            EventHandler<CommandEventArgs> handler = CommandeEvent;

            // invoke la fonction de retour
            handler?.Invoke(this, e);
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
        }*/

        public bool IsConnected => !_disposed && client.IsConnected;

        public void ClearEvents()
        {
            ConnectEvent = null;
            CommandeEvent = null;
            DisconnectEvent = null;
        }
    }

    // class qui permet de transmettre les arguments
    public class CommandEventArgs : EventArgs
    {
        public CommandEventArgs(string s, int id, bool keepSubsciber)
        {
            Message = s;
            Id = id;
            KeepSubsciber = keepSubsciber;
        }

        public CommandEventArgs()
        {
        }

        public int Id { get; set; }

        public string Message { get; set; }

        public bool KeepSubsciber { get; set; }
    }
}
