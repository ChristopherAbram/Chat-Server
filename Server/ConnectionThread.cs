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
    

    public class ConnectionThread
    {
        TcpClient client;
        NetworkStream stream;

        public ConnectionThread(TcpClient client)
        {
            this.client = client;
            stream = client.GetStream();
        }

        public void connectionHandling()
        {
            Console.WriteLine("Tworzę wątek dla połączenia!");
            NetworkStream stream = client.GetStream();
            int max = 65565;
            Byte[] bytes = new Byte[max];
            Byte[] respon = new Byte[max];
            int i;

            RequestResolver resolver = new RequestResolver();

            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                Communicate communicate = new Communicate();
                try
                {
                    if (communicate.fromByteArray(bytes))
                    {
                        Communicate response = resolver.handle(communicate);

                        // Try to send response from server:
                        respon = response.toByteArray();
                        stream.Write(respon, 0, respon.Length);
                        stream.Flush();
                    }
                } catch(Exception e)
                {

                }
            }
        }
    }
}
