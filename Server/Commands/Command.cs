using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public abstract class Command
    {

        protected int _status = 0;
        protected Communicate _response = null;

        // Statuses:
        public const int DEFAULT = 0;
        public const int OK = 1;
        public const int ERROR = 2;






        public Command()
        {
            _response = new Communicate();
            
        }

        public void execute(Communicate request)
        {
            _status = _execute(request);
        }

        public int Status
        {
            get { return _status; }
        }

        public Communicate Response
        {
            get{ return _response; }
        }

        protected abstract int _execute(Communicate request);

    }
}
