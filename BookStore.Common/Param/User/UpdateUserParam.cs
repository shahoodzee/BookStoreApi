using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DU.Common.Param.User;

public class UpdateUserParam
{
    public long id { get; set; }
    public string name { get; set; }
    //public string username { get; set; }
    public string? location { get; set; }
    public int iStateId { get; set; }
    public int iUserRole { get; set; }
    public string email { get; set; }
    public string phonenumber { get; set; }
    public string profileimage { get; set; }
    public long imodifiedbyuserid { get; set; }
}
