using Microsoft.AspNetCore.Mvc;
using BookStore.Common.Dto.BookDtos;

namespace BookStore.DAL.Repositories.BookRepository;

public interface IBookRepo
{
    Task<bool> CreateBookDAL(CreateBookDto param);
    Task<bool> UpdateBookDAL(UpdateBookDto param);
    Task<bool> DeleteBookDAL(long bookId);
    Task<FetchBookDto> FetchBookByIdDAL(long bookId);
    Task<List<FetchBookDto>> FetchBooksDAL();

}
