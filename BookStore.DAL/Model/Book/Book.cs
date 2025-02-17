using System.ComponentModel.DataAnnotations;

namespace BookStore.DAL.Model.Book;

public class Book : BaseTable
{
    [Key]
    public long Id { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public double price { get; set; }
    public DateTime publishDate { get; set; }
    public string ISBN { get; set; }

}
