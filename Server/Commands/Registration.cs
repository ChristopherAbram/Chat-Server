using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Registration : Command
    {

        public Registration() : base()
        {

        }

        override protected int _execute(Communicate request)
        {
            using (var db = new UserContext())
            {
                // Create and save a new User:
                User user = request.user;
                if(user != null)
                {
                    var name = user.username;
                    var pass = user.password;
                    var a = user.age;

                    var u = new User { username = name, password = pass, age = a};

                    // Count users with given username:
                    int count = __count_user_with_username(u.username);

                    // If there are no user with given username:
                    if(count == 0)
                    {
                        // Add new user:
                        db.Users.Add(u);
                        if (db.SaveChanges() > 0)
                        {
                            // Set appropriate header and message:
                            _response.header = "registered";
                            _response.message = new Message { content = "Correctly registered new user" };
                            return Command.OK;
                        }
                    }
                    // If there is such a user:
                    else
                    {
                        _response.header = "error";
                        _response.message = new Message { content = "User with given username already exists" };
                        return Command.ERROR;
                    }
                }
            }
            // Communicate error occurrance:
            _response.header = "error";
            _response.message = new Message { content = "A proplem occurred while register new user" };
            return Command.ERROR;
        }

        private int __count_user_with_username(string username)
        {
            int count = 0;

            using (var db = new UserContext())
            {
                count = (from b in db.Users
                         orderby b.username
                         where b.username == username
                         select b).Count();

            }

            return count;
        }

    }
}
