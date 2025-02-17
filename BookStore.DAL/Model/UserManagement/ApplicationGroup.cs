using System.ComponentModel.DataAnnotations;

namespace BookStore.DAL.Model.UserManagement;

public class ApplicationGroup 
{
    [Key]
    public int Id { get; set; }
    public string GroupName { get; set; } 
    public string Description { get; set; }
    public bool isActive { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifyDate { get; set; } = null!;
    public long iCreatedBy { get; set; }
    public long? iModifyBy { get; set; } = null!;
}
