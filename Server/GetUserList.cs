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


            return Command.OK;
        }
    }
}