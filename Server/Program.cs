using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Program
    {
        static TcpListener server = null;

        static void Main(string[] args)
        {

            /*Command reg = new Registration();

            Communicate request = new Communicate { user = new User { username = "user02", password = "password", age = 23 } };

            reg.execute(request);
            Communicate response = reg.Response;

            Console.WriteLine("Status: " + reg.Status);
            Console.WriteLine(response.message.content);

            return;*/

            try
            {
                Int32 port = 13000;
                IPAddress local = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(local, port);

                server.Start();
                Console.WriteLine("Oczekiwanie na nadchodzące połączenia...");
                Console.WriteLine("");
                while (true)
                {
                    ConnectionThread t = new ConnectionThread(server.AcceptTcpClient());
                    Thread oThread = new Thread(new ThreadStart(t.connectionHandling));

                    oThread.Start();
                    oThread.Join();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Błąd gniazda: {0}", e);
            }
            catch(Exception e)
            {
                Console.WriteLine("Błąd", e);
            }
            finally
            {
                server.Stop();
            }


        }
    }
}
