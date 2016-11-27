using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class RequestResolver : IController
    {

        protected ApplicationController _controller = null;
        protected TcpClient _client = null;

        public RequestResolver(TcpClient client) {
            _client = client;
            _controller = new ApplicationController();
        }

        public Communicate handle(Communicate communicate)
        {
            // Perform initialization:
            _init(communicate);

            try
            {
                // Find appropriate command:
                Command command = _controller.getCommand(communicate);

                // Execute found command:
                command.execute(communicate);

                // Get response:
                Communicate response = command.Response;
                response.sessID = communicate.sessID;

                // Set sender and receiver:
                //response.sender = ...
                response.receiver = communicate.sender;

                return response;
            }
            catch (Exception e) { }

            // Create error communicate (response):
            Communicate error = new Communicate(communicate);
            error.header = "error";
            Message m = new Message();
            m.content = "Server has encountered a problem. Try to send request again.";
            error.message = new Message();

            return error; // error communicate
        }

        protected void _init(Communicate c)
        {
            Session session = Session.getInstance();
            ClientsInfo clients = ClientsInfo.getInstance();
            
            if (session.Status(c.sessID) == Session.SESSION_NONE)
            {
                c.sessID = session.Start(c.sessID);
                clients.AddClient(c.sessID, _client);
            }
            else
            {
                c.sessID = session.Start(c.sessID);
            } 

        }

    }
}
