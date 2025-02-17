using System.ComponentModel.DataAnnotations;

namespace BookStore.DAL.Model.UserManagement;

public class ApplicationUserGroup
{
    [Key]
    public int Id { get; set; }
    public long ApplicationUserId { get; set; }
    public int ApplicationGroupId { get; set; }
}
