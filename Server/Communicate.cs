using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Server
{
    public class Communicate : Serialisation.CustomSerialization
    {
        /*
        1) User Registration:
           header = register
           receiver = given
           sender = given
           sessID = "" - empty
           user = { username, password }
           message = { "" }

        2) [RESPONSE] User Registered:
           header = registered
           receiver = given
           sender = given
           sessID = "" - empty
           user = null
           message = { "message" }
            


        3) Open user session:
           header = authorize
           receiver = given
           sender = given
           sessID = "" - empty
           user = { username, password } - user data to check
           message = { "" } - empty message

        4) [RESPONSE] Authorized confirmation:
           header = authorized
           receiver = given
           sender = given
           sessID = "identifier" - new session id for user
           user = { ... }  - concreate user
           message = { "Corretly logged user" }

        

        5) Logged user list request:
           header = getuserlist
           receiver = given
           sender = given
           sessID = "identifier" - new session id for user
           user = { ... }  - concreate user
           message = { "" } 


        6) [RESPONSE] Logged user list response:
           header = userlist
           receiver = given
           sender = given
           sessID = "identifier" - new session id for user
           user = { ... }  - concreate user
           message = { "<userlist>" } 
           
        ///////////////////////////////////////////

        7) Sending message:
           header = sending
           receiver = given
           sender = given
           sessID = "identifier"
           user = { ... }  - concreate user
           message = { "message content" }

        8) [RESPONSE] Message sent:
           header = sent
           receiver = given
           sender = given
           sessID = "identifier"
           user = { ... }  - concreate user
           message = { "Message has been sent" }


        9) [RESPONSE] Receive message:
           header = received
           receiver = given
           sender = given
           sessID = "identifier"
           user = { ... }  - concreate user
           message = { "message content" }
           
        ////////////////////////////////////////////

        10) Closing session:
           header = close
           receiver = given
           sender = given
           sessID = "identifier"
           user = { ... }  - concreate user
           message = { "" }

        11) [RESPONSE] Exit confirmation:
           header = closed
           receiver = given
           sender = given
           sessID = "identifier"
           user = { ... }  - concreate user
           message = { "Correctly closed user session" }
            */

        public String header = "";

        public IPAddress receiver = null;   // IP address of receiver host,
        public IPAddress sender = null;     // IP address of sender host

        public String sessID = "";

        public User user = null;
        public Message message = null;

        public Communicate()
        {
            user = new User();
            message = new Message();
            //receiver = IPAddress.Parse("127.0.0.1");
            //sender = IPAddress.Parse("127.0.0.1");
        }

        public Communicate(Communicate ob)
        {
            header = ob.header;
            receiver = ob.receiver;
            sender = ob.sender;
            sessID = ob.sessID;
            user = ob.user;
            message = ob.message;
        }

    }
}
