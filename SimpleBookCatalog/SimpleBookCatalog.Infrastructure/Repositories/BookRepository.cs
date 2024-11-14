using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Application.Interfaces;
using SimpleBookCatalog.Domain.Entities;
using SimpleBookCatalog.Infrastructure.Context;

namespace SimpleBookCatalog.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SimpleBookCatalogDbContext context;

        public BookRepository(IDbContextFactory<SimpleBookCatalogDbContext> factory)
        {
            context = factory.CreateDbContext();
        }

        public async Task AddAsync(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
           var book = await GetByIdAsync(id);
            if (book is not null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        public Task<List<Book>> GetAllAsync()
        {
            var books = context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
