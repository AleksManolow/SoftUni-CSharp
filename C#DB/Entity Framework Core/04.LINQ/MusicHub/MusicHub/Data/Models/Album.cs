using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(ValidationConstants.AlbumNameMinLength)]
        public string Name { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        [NotMapped]
        public decimal Price => 
            Songs.Sum(s =>  s.Price);
        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }
        public virtual Producer? Producer { get; set; } 

        public virtual ICollection<Song> Songs { get; set; } 
    }
}
