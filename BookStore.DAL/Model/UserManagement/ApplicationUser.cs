using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DAL.Model.UserManagement;

public class ApplicationUser : IdentityUser<long>
{
    [Key]
    public long Id {  get; set; }
    public string? Name { get; set; }
    //public string? LastName { get; set; }
    public string? ProfileImage { get; set; }
    public string? Location { get; set; }
    public int iStateId { get; set; }
    public bool isActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifyDate { get; set; }
    public long iCreatedBy { get; set; } = -1;
    public long iModifyBy { get; set; } = -1;

    //[NotMapped]
    //public override string SecurityStamp { get; set; }

}
