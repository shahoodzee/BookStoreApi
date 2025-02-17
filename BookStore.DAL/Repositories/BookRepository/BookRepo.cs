using BookStore.DAL.Data;
using Microsoft.EntityFrameworkCore;
using BookStore.DAL.Model.Book;
using BookStore.Common.Dto.BookDtos;

namespace BookStore.DAL.Repositories.BookRepository;

public class BookRepo : IBookRepo
{
    private readonly ApplicationDbContext context;
    public BookRepo(ApplicationDbContext _context)
    {
        context = _context;
    }
    public async Task<bool> CreateBookDAL(CreateBookDto param)
    {
        try
        {
            Book obj = new Book { 
                title = param.title,
                author = param.author,
                ISBN = param.ISBN,
                publishDate = DateTime.Now,
                price = param.price,
                CreatedDate = DateTime.Now,
                isActive = false,
            };
            await context.Books.AddAsync(obj);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> UpdateBookDAL(UpdateBookDto param)
    {
        try
        {
            var bookObj = await context.Books.FindAsync(param.id);

            if (bookObj == null)
            {
                return false;
            }

            bookObj.title = param.title;
            bookObj.author = param.author;
            bookObj.price = param.price;
            bookObj.publishDate = param.publishDate;
            bookObj.ISBN = param.ISBN;

            await context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            // Handle exception (you can log it as needed)
            return false;
        }
    }

    public async Task<bool> DeleteBookDAL(long id)
    {
        try
        {
            var bookObj = await context.Books.FindAsync(id);
            if (bookObj == null)
            {
                return false;
            }
            context.Books.Remove(bookObj);
            await context.SaveChangesAsync();

            return true;    
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<List<FetchBookDto>> FetchBooksDAL()
    {
        List<FetchBookDto> bookList = new();
        try
        {
            
           //var result = await context.Set<FetchBookDto>().FromSqlRaw("EXECUTE sp_GetAllBooks").ToListAsync();
           var result = await context.Books.ToListAsync();
           if(result == null)
           {
                return bookList;
           }
            bookList = result.Select(book => new FetchBookDto
            {
                Id = book.Id,
                title = book.title,
                author = book.author,
                price = book.price,
                publishDate = book.publishDate,
                ISBN = book.ISBN
            }).ToList();

            return bookList;
        }
        catch (Exception ex)
        {

            return null;
        }
    }

    public async Task<FetchBookDto> FetchBookByIdDAL(long id)
    {
        try
        {
            var bookObj = await context.Books.FindAsync(id);
            if (bookObj == null)
            {
                return null;
            }
            FetchBookDto dto = new FetchBookDto { 
                Id = bookObj.Id,
                title=bookObj.title,
                author = bookObj.author,
                price = bookObj.price,
                publishDate = bookObj.publishDate,
                ISBN = bookObj.ISBN
            };
            return dto;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


}
