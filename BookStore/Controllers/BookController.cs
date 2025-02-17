using Microsoft.AspNetCore.Mvc;
using BookStore.Common.Dto.BookDtos;
using BookStore.BAL.Services.Book;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBookService bookService;
        private List<BookDto> bookList;

        public BookController(IBookService _bookService)
        {
            bookService = _bookService;
            bookList = new List<BookDto>
            {
                new BookDto
                {
                    Id = 1,
                    title = "The Great Gatsby",
                    author = "F. Scott Fitzgerald",
                    price = 10.99,
                    publishDate = new DateTime(1925, 4, 10),
                    ISBN = "9780743273565"
                },
                new BookDto
                {
                    Id = 2,
                    title = "To Kill a Mockingbird",
                    author = "Harper Lee",
                    price = 7.99,
                    publishDate = new DateTime(1960, 7, 11),
                    ISBN = "9780061120084"
                },
                new BookDto
                {
                    Id = 3,
                    title = "1984",
                    author = "George Orwell",
                    price = 8.99,
                    publishDate = new DateTime(1949, 6, 8),
                    ISBN = "9780451524935"
                },
                new BookDto
                {
                    Id = 4,
                    title = "Moby Dick",
                    author = "Herman Melville",
                    price = 9.99,
                    publishDate = new DateTime(1851, 11, 14),
                    ISBN = "9781503280786"
                },
                new BookDto
                {
                    Id = 5,
                    title = "Pride and Prejudice",
                    author = "Jane Austen",
                    price = 6.99,
                    publishDate = new DateTime(1813, 1, 28),
                    ISBN = "9780141439518"
                }
            };
        }

        public async Task<IActionResult> Index()
        {
            List<BookDto> bookInfo = new();
            var response = await bookService.FetchBooks();

            if (response == null)
            {
                TempData["Message"] = "Error OCcured While Fetching Books";
                TempData["MessageType"] = "success";
            }

            var books = response.Data;
            bookInfo = books.Select(book => new BookDto
            {
                Id = book.Id,
                title = book.title,
                author = book.author,
                price = book.price,
                publishDate = book.publishDate,
                ISBN = book.ISBN
            }).ToList();

            return View(bookInfo);
        }

        public async Task<IActionResult> Details(long id)
        {
            var response = await bookService.FetchBookById(id);
            if (response.Succeeded == true)
            {
                FetchBookDto bookDto = new FetchBookDto
                {
                    Id = response.Data.Id,
                    title = response.Data.title, 
                    author = response.Data.author,
                    price = response.Data.price,
                    publishDate = response.Data.publishDate,
                    ISBN = response.Data.ISBN
                };
                return View(bookDto);
            }
            else
            {

                TempData["Message"] = response.Message;
                TempData["MessageType"] = "fail";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookDto book)
        {
            if (ModelState.IsValid)
            {
                var newBook = new BookDto
                {
                    Id = bookList.Max(b => b.Id) + 1,
                    title = book.title,
                    author = book.author,
                    price = book.price,
                    publishDate = book.publishDate,
                    ISBN = book.ISBN
                };
                bookList.Add(newBook);
                var result = await bookService.CreateBook(book);

                TempData["Message"] = result.Message;
                TempData["MessageType"] = "success";

                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var response = await bookService.FetchBookById(id);
            if (response.Succeeded == false)
            {
                return NotFound();
            }

            var updateBook = new UpdateBookDto
            {
                id = response.Data.Id,
                title = response.Data.title,
                author = response.Data.author,
                price = response.Data.price,
                publishDate = response.Data.publishDate,
                ISBN = response.Data.ISBN
            };
            return View(updateBook);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, UpdateBookDto book)
        {
            if (ModelState.IsValid)
            {
                var response = await bookService.UpdateBook(book);

                if (response.Succeeded != true)
                {
                    TempData["Message"] = response.Message;
                    TempData["MessageType"] = "fail";
                }
                TempData["Message"] = response.Message;
                TempData["MessageType"] = "success";

                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await bookService.FetchBookById(id);
            if (response.Succeeded == false)
            {
                TempData["Message"] = response.Message;
                TempData["MessageType"] = "fail";

                return RedirectToAction(nameof(Index));
            }
            DeleteBookDto deleteBook = new DeleteBookDto
            {
                Id = response.Data.Id,
                title = response.Data.title
            };
            return View(deleteBook);
        }

        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBook(long id)
        {
            var response = await bookService.DeleteBook(id);
            if (response.Succeeded != true)
            {
                TempData["Message"] = response.Message;
                TempData["MessageType"] = "fail";
            }
            TempData["Message"] = response.Message;
            TempData["MessageType"] = "success";
            return RedirectToAction(nameof(Index));
        }
    }
}
