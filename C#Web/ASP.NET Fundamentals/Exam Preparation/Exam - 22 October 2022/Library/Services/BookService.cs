using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private LibraryDbContext dbContext;
        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Author= model.Author,
                ImageUrl = model.Url,
                Description= model.Description, 
                CategoryId = model.CategoryId,
                Rating = decimal.Parse(model.Rating),
            };
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool alreadyAdded = await dbContext.IdentityUsers
                .AnyAsync(ub => ub.CollectorId== userId && ub.BookId == book.Id);
            if (!alreadyAdded)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id,
                };

                await dbContext.IdentityUsers.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await dbContext
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MineBookViewModel>> GetMyBooksAsync(string userId)
        {
            return await dbContext.IdentityUsers
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new MineBookViewModel
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description= b.Book.Description,
                    Category = b.Book.Category.Name
                })
                .ToListAsync();
        }

        public async Task<AddBookViewModel> GetNewAddBookModelAsync()
        {
            var categoties = await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name 
                })
                .ToListAsync();

            var model = new AddBookViewModel
            {
                Categories = categoties
            };
            return model;
        }

        public async Task RemoveBookToCollectionAsync(string userId, BookViewModel book)
        {
            var userBook = await dbContext.IdentityUsers
                    .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (userBook != null)
            {
                dbContext.IdentityUsers.Remove(userBook);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
