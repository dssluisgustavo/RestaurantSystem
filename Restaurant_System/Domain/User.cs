using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Users", Schema = "public")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double CPF { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection <UserRoles> UserRoles { get; } = new List<UserRoles> ();
    }
}