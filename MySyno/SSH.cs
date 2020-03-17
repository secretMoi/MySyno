using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace MySyno
{
    class SSH
    {
        private string user;
        private string password;
        private string host;
        private int port;

        private readonly SshClient client;
        private readonly Mutex verrouMutex;

        // Declare the event using EventHandler<T>
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;
        public event EventHandler<CustomEventArgs> CommandeEvent;


        public SSH(string host, string user, string password, int port = 22)
        {
            verrouMutex = new Mutex();

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
            verrouMutex.WaitOne();
            client.Connect();
            verrouMutex.ReleaseMutex();
        }

        public void Disconnect()
        {
            Thread threadClose = new Thread(Close);
            threadClose.Start();
        }

        public void SendCommand(string commande)
        {
            Thread t = new Thread(() => RunCommand(commande));
            t.Start();
        }

        private void RunCommand(string commande)
        {
            verrouMutex.WaitOne();

            if (client.IsConnected)
            {
                SshCommand sc = client.CreateCommand(commande);
                sc.Execute();
                string resultat = sc.Result;

                Commande_Event(new CustomEventArgs(resultat));
            }
            verrouMutex.ReleaseMutex();
        }

        private void Close()
        {
            verrouMutex.WaitOne();

            if (client.IsConnected)
                client.Disconnect();

            client.Dispose();

            verrouMutex.ReleaseMutex();
        }

        public void Test()
        {
            // Write some code that does something useful here
            // then raise the event. You can also raise an event
            // before you execute a block of code.
            OnRaiseCustomEvent(new CustomEventArgs("Did something"));
        }

        protected virtual void Commande_Event(CustomEventArgs e)
        {
            // fait un copie si un subscriber se désinscrit entre le if et le handler()
            EventHandler<CustomEventArgs> handler = CommandeEvent;

            // handler vaut null si il n'y a aucun subscriber
            if (handler != null)
            {
                // Use the () operator to raise the event.
                //form.BeginInvoke(handler(this, e));
                handler(this, e);
            }
        }

        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<CustomEventArgs> handler = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message += $" at {DateTime.Now}";

                // Use the () operator to raise the event.
                handler(this, e);

            }
        }
    }

    // Define a class to hold custom event info
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            Message = s;
        }

        public string Message { get; set; }
    }
}
