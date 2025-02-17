namespace DU.Common.Param.User;

public class AddUserParam
{
    public string name { get; set; } 
    //public string username { get; set; }
    public string? location { get; set; }
    public int iStateId { get; set; }
    public string password { get; set; }
    //public string confirmpassword { get; set; }
    public string email { get; set; }
    public string phonenumber { get; set; }
    public string profileimage { get; set; }
    public int iUserRole { get; set; } // 1 = admin, 2 = channel_ops user, else field_engineer
    public long icreatedbyuserid { get; set; }
    public long imodifiedbyuserid { get; set; }
    //public string ogranizationname { get; set; }
    //public string designation { get; set; }
    //public string address { get; set; }
}
