using BookStore.Common.Dto.BookDtos;
using BookStore.Common.Response;
using BookStore.DAL.Repositories.BookRepository;
using System.Net.Sockets;

namespace BookStore.BAL.Services.Book;

public class BookService : IBookService
{
    private readonly IBookRepo bookRepo;
    public BookService(IBookRepo _deviceRepo)
    {
        bookRepo = _deviceRepo;
    }

    public async Task<ServiceResponse<bool>> CreateBook(CreateBookDto param)
    {
        var response = new ServiceResponse<bool>();
        try
		{
            //var obj = mapper.Map<CreateDeviceParam,CreateDeviceDto>(param);
            var result = await bookRepo.CreateBookDAL(param);
            if(result == false)
            {
                response.Succeeded = false;
                response.Data = false;
                response.Message = "Unable to create Book";
                return response;
            }
            response.Succeeded = true;
            response.Data = true;
            response.Message = "Book Created successfully !";
            return response;
        }
		catch (Exception ex)
		{
            response.Succeeded = false;
            response.Data = false;
            response.Message = ex.ToString();
            return response;
		}
    }

    public async Task<ServiceResponse<bool>> UpdateBook(UpdateBookDto param)
    {
        var response = new ServiceResponse<bool>();
        try
        {
            var obj = await bookRepo.UpdateBookDAL(param);
            if (obj == false)
            {
                response.Succeeded = false;
                response.Data = false;
                response.Message = "Unable to update device";
                return response;
            }

            response.Succeeded = true;
            response.Data = true;
            response.Message = "Device update successfully !";
            return response;
        }
        catch (Exception ex)
        {
            response.Succeeded = false;
            response.Data = false;
            response.Message = ex.ToString();
            return response;
        }
    }

    public async Task<ServiceResponse<bool>> DeleteBook(long id)
    {
        var response = new ServiceResponse<bool>();
        try
        {
            var result = await bookRepo.DeleteBookDAL(id);
            if (!result)
            {
                response.Succeeded = false;
                response.Data = false;
                response.Message = "Unable to remove Book";
                return response;
            }
            response.Succeeded = true;
            response.Data = true;
            response.Message = "Book removed successfully !";
            return response;
        }
        catch (Exception ex)
        {
            response.Succeeded = false;
            response.Data = false;
            response.Message = "Unable to remove device";
            return response;
        }
    }

    public async Task<ServiceResponse<List<FetchBookDto>>> FetchBooks()
    {
        var response = new ServiceResponse<List<FetchBookDto>>();
        List<FetchBookDto> lst = new();
        try
        {
            var result = await bookRepo.FetchBooksDAL();
            if(result == null)
            {
                response.Succeeded = false;
                response.Message = "Unable to fetch devices";
                response.Data = lst;
                return response;
            }
            response.Succeeded = true;
            response.Message = "";
            response.Data = result;
            return response;
        }
        catch(Exception ex) 
        {
            response.Message = ex.ToString();
            response.Succeeded =false;
            response.Data = lst;
            return response;
        }
    }

    public async Task<ServiceResponse<FetchBookDto>> FetchBookById(long id) {
        ServiceResponse<FetchBookDto> response = new ();
        try
        {
            var bookInfo = await bookRepo.FetchBookByIdDAL(id);
            if (bookInfo == null)
            {
                response.Succeeded = false;
                response.Message = "Book Not found";
                response.Data = null;
                return response;
            }
            FetchBookDto bookDto = new FetchBookDto
            {
                Id = id,
                author = bookInfo.author,
                title = bookInfo.title,
                price = bookInfo.price,
                publishDate = bookInfo.publishDate,
                ISBN = bookInfo.ISBN
            };

            response.Succeeded = true;
            response.Message = "Details Fetched Successfully";
            response.Data = bookDto;
            return response;

        }
        catch(Exception ex){
            response.Succeeded = false;
            response.Message = "Details Fetched Successfully";
            response.Data = null;
            return response;
        }
    }

}
