using System;

namespace task02_Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Article article = new Article(input[0], input[1], input[2]);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(": ");
                if (input[0] == "Edit")
                {
                    article.content = input[1];
                }
                else if (input[0] == "ChangeAuthor")
                {
                    article.author = input[1];
                }
                else if (input[0] == "Rename")
                {
                    article.title = input[1];
                }
            }
            Console.WriteLine($"{article.title} - {article.content}: {article.author}");
        }
    }
    class Article
    {
        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }
        public Article(string _titile, string _content,string _author)
        {
            title = _titile;
            content = _content;
            author = _author;
        }
    }
}
