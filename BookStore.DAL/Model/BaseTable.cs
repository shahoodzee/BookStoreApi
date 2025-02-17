namespace BookStore.DAL.Model;
public class BaseTable
{
    public long iCreatedBy { get; set; }
    public bool isActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public long? iModifiedBy { get; set; }
    public DateTime? ModifyDate { get; set; }
}
