using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
	public class PostController : Controller
	{
		public readonly ForumAppDbContext _data;

		public PostController(ForumAppDbContext data)
		{
			_data = data;
		}
		public async Task<IActionResult> All()
		{
			var posts = await _data
				.Posts
				.Select(p => new PostViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					Content = p.Content,
				})
				.ToListAsync();

			return View(posts);
		}

		public async Task<IActionResult> Add()
			=> View();

		[HttpPost]
		public async Task<IActionResult> Add(PostFormModel model)
		{
			var post = new Post()
			{
				Title = model.Title,
				Content = model.Content,
			};

			await _data.Posts.AddAsync(post);
			await _data.SaveChangesAsync();

			return RedirectToAction("All");
		}
	}
}
