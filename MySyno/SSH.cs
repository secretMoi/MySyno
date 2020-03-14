using System.Threading;
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

        private static SshClient client;
        private static object output;

        private Thread thread;
        private static bool threadFini;

        public SSH(string host, string user, string password, int port = 22)
        {
            this.user = user;
            this.password = password;
            this.host = host;
            this.port = port;
        }

        public void Connect()
        {
            client = new SshClient(host, port, user, password);
            Thread threadConnect = new Thread(ThreadConnect);
            threadConnect.Start();
            /*client.Connect();
            output = client.RunCommand("echo test").Result;*/
        }

        private static void ThreadConnect()
        {
            client.Connect();
            output = client.RunCommand("echo test").Result;
            threadFini = true;
        }

        public void Disconnect()
        {
            client.Disconnect();
            client.Dispose();
        }

        public static string test()
        {
            while (threadFini == false) { }

            return output.ToString();
        }

        public static object Output => output;
    }
}
