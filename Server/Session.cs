using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Session
    {

        private Dictionary<String, Dictionary<String, String>> __array = null;
        private static Session __instance = null;

        public const int SESSION_ACTIVE = 1;
        public const int SESSION_NONE = 0;

        public static Session getInstance()
        {
            if(__instance == null)
            {
                __instance = new Session();
            }
            return __instance;
        }

        public string Start(string sessid)
        {
            if(Status(sessid) == SESSION_ACTIVE)
            {
                // Session already run:

                return sessid;
            }
            else
            {
                // Start new session:
                string sid = generate_session_id();

                lock (__array)
                {
                    __array.Add(sid, new Dictionary<string, string>());
                }
                return sid;
            }
        }

        public int Status(string sessid)
        {
            int status = SESSION_NONE;
            lock (__array)
            {
                try
                {
                    if (__array.ContainsKey(sessid))
                    {
                        status = SESSION_ACTIVE;
                    }
                }
                catch (Exception e) { }
            }
            return status;
        }

        public void Destroy(string sessid)
        {
            if (Status(sessid) == SESSION_ACTIVE)
            {
                lock (__array)
                {
                    try {
                        if (__array.ContainsKey(sessid))
                        {
                            __array.Remove(sessid);
                        }
                    } catch (Exception e) { }
                }
            }
            return;
        }

        public String get(string sessid, string index)
        {
            string value = "";
            lock (__array)
            {
                try
                {
                    if (__array.ContainsKey(sessid))
                    {
                        Dictionary<String, String> s = __array[sessid];
                        if (s.ContainsKey(index))
                        {
                            value = s[index];
                        }
                    }
                }
                catch (Exception e) { }
            }
            return value;
        }

        public void set(string sessid, string index, string value)
        {
            lock (__array)
            {
                try
                {
                    if (__array.ContainsKey(sessid))
                    {
                        if (__array[sessid].ContainsKey(index))
                        {
                            __array[sessid][index] = value;
                        }
                        else
                        {
                            __array[sessid].Add(index, value);
                        }
                    }
                }
                catch (Exception e) { }
            }
            return;
        }

        private String generate_session_id()
        {
            String sessid = "";

            // Time with microseconds:
            String now = DateTime.Now.ToString("HH:mm:ss.ffffff");

            // Random number:
            Random r = new Random();
            int rnd = r.Next(-10000, 10000);

            // Generating hash:
            sessid = md5(now + rnd);
            return sessid;
        }

        private string md5(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        
        private Session()
        {
            __array = new Dictionary<String, Dictionary<String, String>>();
        }
    }
}
