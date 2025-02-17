using System.ComponentModel.DataAnnotations;

namespace BookStore.Common.Dto.BookDtos;

public class CreateBookDto
{
    [Required(ErrorMessage = "Title is required.")]
    public string title { get; set; }

    [Required(ErrorMessage = "Author is required.")]
    public string author { get; set; }

    [Required(ErrorMessage = "ISBN is required.")]
    public string ISBN { get; set; }

    [Range(0.01, 999.99, ErrorMessage = "Price must be between 0.01 and 999.99.")]
    public double price { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Publish Date is required.")]
    [Display(Name = "Publish Date")]
    [CustomValidation(typeof(CreateBookDto), nameof(ValidatePublishDate))]
    public DateTime publishDate { get; set; }

    public static ValidationResult ValidatePublishDate(DateTime date, ValidationContext context)
    {
        if (date > DateTime.Now)
        {
            return new ValidationResult("Publish Date must be in the past.");
        }
        return ValidationResult.Success;
    }
}

public class UpdateBookDto
{
    public long id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string title { get; set; }

    [Required(ErrorMessage = "Author is required.")]
    public string author { get; set; }

    [Required(ErrorMessage = "ISBN is required.")]
    public string ISBN { get; set; }

    [Range(0.01, 999.99, ErrorMessage = "Price must be between 0.01 and 999.99.")]
    public double price { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Publish Date is required.")]
    [Display(Name = "Publish Date")]
    [CustomValidation(typeof(CreateBookDto), nameof(ValidatePublishDate))]
    public DateTime publishDate { get; set; }

    public static ValidationResult ValidatePublishDate(DateTime date, ValidationContext context)
    {
        if (date > DateTime.Now)
        {
            return new ValidationResult("Publish Date must be in the past.");
        }
        return ValidationResult.Success;
    }
}
public class BookDto
{
    public long Id { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public double price { get; set; }
    public DateTime publishDate { get; set; }
    public string ISBN { get; set; }

}

public class DeleteBookDto
{
    public long Id { get; set; }
    public string title { get; set; }
}
public class FetchBookDto
{
    public long Id { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public double price { get; set; }
    public DateTime publishDate { get; set; }
    public string ISBN { get; set; }

}
public class FetchBookInfoDto
{
}