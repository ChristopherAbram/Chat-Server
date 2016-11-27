using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class ClientsInfo
    {
        private static ClientsInfo __instance = new ClientsInfo();
        protected Dictionary<string, TcpClient> clients = null;

        public static ClientsInfo getInstance()
        {
            if (__instance == null)
            {
                __instance = new ClientsInfo();
            }
            return __instance;
        }

        private ClientsInfo(){
            clients = new Dictionary<string, TcpClient>();
        }
        
        public void AddClient(string sid, TcpClient client)
        {
            if (clients != null)
            {
                clients.Add(sid, client);
            }
        }

        public TcpClient GetClient(string sid)
        {
            try
            {
                if (clients != null && clients.ContainsKey(sid))
                {
                    return clients[sid];
                }
            }
            catch (Exception e) { }
            //TODO: 
            return null;
        }
    }
}
