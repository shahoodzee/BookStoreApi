using BookStore.Common.Dto;
using BookStore.Common.Dto.BookDtos;
using BookStore.Common.Response;

namespace BookStore.BAL.Services.Book;

public interface IBookService
{
    Task<ServiceResponse<bool>> CreateBook(CreateBookDto param);
    Task<ServiceResponse<bool>> UpdateBook(UpdateBookDto param);
    Task<ServiceResponse<bool>> DeleteBook(long id);
    Task<ServiceResponse<List<FetchBookDto>>> FetchBooks();
    Task<ServiceResponse<FetchBookDto>> FetchBookById(long id);

}
