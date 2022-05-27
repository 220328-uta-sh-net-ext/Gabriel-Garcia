using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
    public class User
    {
        
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Id { get; set; }
        public int Zone { get; set; }
    }
}