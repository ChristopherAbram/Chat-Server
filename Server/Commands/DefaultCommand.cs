using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class DefaultCommand : Command
    {

        public DefaultCommand() : base()
        {

        }

        override protected int _execute(Communicate request)
        {
            // Perform default task:


            return Command.OK;
        }

    }
}
