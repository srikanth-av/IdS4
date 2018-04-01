using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthServer.Model
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
    }
}
