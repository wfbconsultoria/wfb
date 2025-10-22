using System.ComponentModel.DataAnnotations;

namespace wfb.Models
{
    public class ClsUsers
    {
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        
    }
 
}
