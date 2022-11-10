using System;

namespace AuthorProblem
{
    public class StartUp
    {
        [Author("Marina")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }

        [Author("Vanya")]
        public void BlahBlah()
        {

        }
        [Author("Ivalina")]
        public static void Something()
        {

        }
    }
}
