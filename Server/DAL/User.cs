using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serialisation;

namespace Server
{
    public class User : Serialisation.CustomSerialization, Entity
    {
        protected String _username = "";

        protected String _password = "";

        protected int _age = 0;

        public int UserId { get; set; }

        public String username {
            get { return _username; }
            set { _username = value; }
        }

        public String password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int age
        {
            get { return _age; }
            set { _age = value; }
        }

    }
}
