using Microsoft.AspNetCore.Identity;

namespace BookStore.DAL.Model.UserManagement;
public class ApplicationRole : IdentityRole<long>
{
    public ApplicationRole()
    {

    }

    public ApplicationRole(string RoleName) : base(RoleName)
    {

    }

}
