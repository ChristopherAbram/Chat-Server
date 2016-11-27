namespace Server
{
    public class GetUserList : Command
    {
        public GetUserList() : base()
        {

        }

        override protected int _execute(Communicate request)
        {
            // Perform task:

            var tmpArr = Session.getInstance().GetLoginUsernames.ToArray();

            string msg = string.Join(",", tmpArr);

            _response.header = "userlist";
            _response.message = new Message() { content = msg };
            
            return Command.OK;
        }
    }
}