using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Sending : Command
    {

        public Sending() : base()
        {

        }

        override protected int _execute(Communicate request)
        {
            // TODO: send message to user
            Session session = Session.getInstance();
            User sender = new User { username = session.get(request.sessID, "username") };

            User receiver = request.user;
            if(receiver != null)
            {
                string sid = session.getSessionIdByUsername(receiver.username);

                if (sid != null)
                {
                    ClientsInfo clients = ClientsInfo.getInstance();
                    TcpClient client = clients.GetClient(sid);

                    if(client != null)
                    {
                        NetworkStream stream = client.GetStream();
                        int max = 65565;
                        Byte[] bytes = new Byte[max];
                        int i;
                        
                        Communicate user_message_response = new Communicate();
                        user_message_response.header = "received";
                        user_message_response.sessID = sid;
                        user_message_response.user = sender;
                        user_message_response.message.content = request.message != null ? request.message.content : "";
                        
                        try
                        {
                            // Try to send response from server:
                            bytes = user_message_response.toByteArray();
                            stream.Write(bytes, 0, bytes.Length);
                            stream.Flush();

                            _response.header = "sent";
                            _response.message.content = "Message has been sent";

                            return Command.OK;
                        }
                        catch (Exception e){}
                    }
                }

            }
            
            _response.header = "error";
            _response.message.content = "Unknown receiver user";

            return Command.ERROR;
        }

    }
}
