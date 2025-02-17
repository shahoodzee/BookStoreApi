
using System.ComponentModel.DataAnnotations;

namespace DU.Common.Param.User
{
    public class UserLoginParam
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
