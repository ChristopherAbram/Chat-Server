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

        public String header {
            get { return _header; }
            set { _header = value; }
        }

        public IPAddress receiver {
            get { return _receiver; }
            set { _receiver = value; }
        }   // IP address of receiver host,
        public IPAddress sender {
            get { return _sender; }
            set { _sender = value; }
        }     // IP address of sender host

        public String sessID
        {
            get { return _sessID; }
            set { _sessID = value; }
        }

        public User user
        {
            get { return _user; }
            set { _user = value; }
        }
        public Message message
        {
            get { return _message; }
            set { _message = value; }
        }





        private String _header = "";
        private IPAddress _receiver = null;
        private IPAddress _sender = null;
        private String _sessID = "";
        private User _user = null;
        private Message _message = null;

        public Communicate()
        {
            _user = new User();
            _message = new Message();
            //receiver = IPAddress.Parse("127.0.0.1");
            //sender = IPAddress.Parse("127.0.0.1");
        }

        public Communicate(Communicate ob)
        {
            _header = ob.header;
            _receiver = ob.receiver;
            _sender = ob.sender;
            _sessID = ob.sessID;
            _user = ob.user;
            _message = ob.message;
        }

    }
}
