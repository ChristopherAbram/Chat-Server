using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Received : Command
    {

        public Received() : base()
        {

        }

        override protected int _execute(Communicate request)
        {
            // Perform task:


            return Command.OK;
        }

    }
}
