using System;
using System.Collections.Generic;

namespace task03_Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = Convert.ToInt32(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] currentCommands = Console.ReadLine().Split(", ");
                Article currentArticle = new Article(currentCommands[0], currentCommands[1], currentCommands[2]);
                articles.Add(currentArticle);
            }

            foreach (var article in articles)
            {
                Console.WriteLine($"{article.title} - {article.content}: {article.author}");
            }
        }
    }
    class Article
    {
        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }
        public Article(string _titile, string _content, string _author)
        {
            this.title = _titile;
            this.content = _content;
            this.author = _author;
        }
    }
}
