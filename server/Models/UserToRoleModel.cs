using System;
namespace server.Models
{
    public class UserToRole
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}