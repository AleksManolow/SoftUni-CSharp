namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            /*string result = ExportAlbumsInfo(context, 9);
            Console.WriteLine(result);*/

            string result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albumsInfo = context
                .Albums
                .Where(a => a.ProducerId.HasValue
                            && a.ProducerId.Value == producerId)
                .ToArray()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("f2"),
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToArray(),
                    AlbumPrice = a.Price.ToString("f2")
                })
                .ToArray();

            foreach (var album in albumsInfo)
            {
                sb
                    .AppendLine(($"-AlbumName: {album.Name}"))
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                int songCounter = 1;

                foreach (var s in album.Songs)
                {
                    sb
                        .AppendLine($"---#{songCounter}")
                        .AppendLine($"---SongName: {s.SongName}")
                        .AppendLine($"---Price: {s.Price}")
                        .AppendLine($"---Writer: {s.Writer}");

                    songCounter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songsInfo = context.Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    Performers = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .OrderBy(p => p)
                        .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToArray();


            int songCnt = 1;
            foreach (var s in songsInfo)
            {
                sb
                    .AppendLine($"-Song #{songCnt}")
                    .AppendLine($"---SongName: {s.Name}")
                    .AppendLine($"---Writer: {s.WriterName}");

                foreach (var p in s.Performers)
                {
                    sb
                        .AppendLine($"---Performer: {p}");
                }

                sb
                    .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                    .AppendLine($"---Duration: {s.Duration}");

                songCnt++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
