using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Authorize : Command
    {

        public Authorize() : base()
        {

        }

        override protected int _execute(Communicate request)
        {
            using (var db = new UserContext())
            {
                User user = request.user;
                if (user != null)
                {
                    string username = user.username;
                    string password = user.password;
                    
                    var items = (from b in db.Users
                                 orderby b.username
                                 where b.username == username
                                 where b.password == password
                                 select b);

                    int count = items.Count();

                    // If there is such user:
                    if (count == 1)
                    {
                        // Set session variable:
                        Session session = Session.getInstance();
                        session.set(request.sessID, "user", "1");

                        session.set(request.sessID, "username", items.FirstOrDefault().username);

                        if(request.sender != null)
                            session.set(request.sessID, "ip", request.sender.ToString());

                        // Setting response:
                        _response.header = "authorized";
                        _response.message = new Message { content = "Corretly logged user" };
                        return Command.OK;
                    }
                    else
                    {
                        _response.header = "error";
                        _response.message = new Message { content = "There is no such a user. Your username or password is wrong" };
                        return Command.ERROR;
                    }

                }
            }
            // Communicate error occurrance:
            _response.header = "error";
            _response.message = new Message { content = "A proplem occurred while perform authorization" };
            return Command.ERROR;
        }

    }
}
