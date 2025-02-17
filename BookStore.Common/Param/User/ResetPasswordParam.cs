

namespace DU.Common.Param.User
{
    public class ResetPasswordParam
    {
        public long userId { get; set; }
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
    }
}
