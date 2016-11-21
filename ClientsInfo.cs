using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace TO
{
    public class ClientsInfo
    {
        private static ClientsInfo __instance = new ClientsInfo();
        
        public static ClientsInfo getInstance()
        {
            if (__instance == null)
            {
                __instance = new ClientsInfo();
            }
            return __instance;
        }

        private ClientsInfo()
        {}

        private Dictionary<string, TcpClient> clients;

        public void AddClient(string username, TcpClient client)
        {
            clients.Add(username, client);
        }

        public TcpClient GetClients(string sessionId)
        {
            //TODO: 
        }
    }
}
