using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.DataConstants.Post;

namespace ForumApp.Models
{
	public class PostFormModel
	{
		[Required]
		[StringLength(50, MinimumLength = TitleMinLength)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(1500, MinimumLength = ContentMinLength)]
		public string Content { get; set; } = null!;
	}
}
