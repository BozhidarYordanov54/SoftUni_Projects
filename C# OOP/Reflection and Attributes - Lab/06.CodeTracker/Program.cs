using _05.CreateAttribute;
using _06.CodeTracker;

namespace AuthorProblem
{
    [Author("Viktor")]
    public class StartUp
    {
        [Author("George")]
        public static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}