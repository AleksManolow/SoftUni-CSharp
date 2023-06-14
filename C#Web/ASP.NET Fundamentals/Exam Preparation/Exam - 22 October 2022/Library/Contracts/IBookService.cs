using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task AddBookToCollectionAsync(string userId, BookViewModel book);
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task<IEnumerable<MineBookViewModel>> GetMyBooksAsync(string userId);
        Task RemoveBookToCollectionAsync(string userId, BookViewModel book);
    }
}
