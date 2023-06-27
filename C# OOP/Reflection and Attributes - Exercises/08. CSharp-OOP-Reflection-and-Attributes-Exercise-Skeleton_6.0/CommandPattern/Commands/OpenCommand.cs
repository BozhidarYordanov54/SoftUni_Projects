namespace CommandPattern.Commands
{
    public class OpenCommand
    {
        public string Execute(string[] args)
        {
            string path = args[0];

            return "Started successfully!";
        }
    }
}
