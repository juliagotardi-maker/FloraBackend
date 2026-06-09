using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Flora.Models
{
    public class Login
    {
        public string email { get; set; }
        public string senha { get; set; }
    }
}