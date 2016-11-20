using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Server
{
    public class ApplicationController : IController
    {
        public ApplicationController()
        {

        }

        public Command getCommand(Communicate communicate)
        {
            if (_is_user_authorized(communicate))
            {
                switch (communicate.header)
                {
                    case "getuserlist":
                        return new GetUserList();
                        break;
                    case "sending":
                        return new Sending();
                        break;
                    case "close":
                        return new Close();
                        break;
                }
            }
            else
            {
                switch (communicate.header)
                {
                    case "authorize":
                        return new Authorize();
                        break;
                    case "register":
                        return new Registration();
                        break;
                }
            }
            
            return new DefaultCommand();
        }

        protected bool _is_user_authorized(Communicate c)
        {
            Session session = Session.getInstance();
            int status = session.Status(c.sessID);

            if(status == Session.SESSION_ACTIVE)
            {
                if(session.get(c.sessID, "user") == "1")
                {
                    return true;
                }
            }
            return false;
        }

    }
}
