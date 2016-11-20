using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Close : Command
    {

        public Close() : base()
        {

        }

        override protected int _execute(Communicate request)
        {
            // Ending session:
            Session session = Session.getInstance();
            session.Destroy(request.sessID);

            // Setting response:
            _response.header = "closed";
            _response.message = new Message { content = "Correctly log out" };

            return Command.OK;
        }

    }
}
