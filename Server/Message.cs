using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serialisation;

namespace Server
{
    public class Message :  Entity
    {
        protected String _content = "";

        public String content {
            get { return _content; }
            set { _content = value; }
        }

    }
}
