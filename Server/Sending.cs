using System;
using System.Collections.Generic;
using System.Linq;
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
            // Perform task:
            _response.header = "sent";
            _response.message.content = "Message has been sent";

            // TODO: send message to user
            Communicate user_message_response = new Communicate();
            user_message_response.header = "received";
            user_message_response.message.content = request.message.content;

            // ...

            return Command.OK;
        }

    }
}
