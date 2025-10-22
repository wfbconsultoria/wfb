using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wfb.Models
{
    public class Users
    {
        //Id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        //Email
        [Required]
        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public required  string Email { get; set; }
        
        //Username
        [Required]
        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string? Username { get; set; }

        //Password
        [Required]
        [Column(TypeName = "varchar(64)")]
        [MaxLength(64)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        //Phone
        [Column(TypeName = "varchar(64)")]
        [MaxLength(64)]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneMobile { get; set; }


        //Insert
        [Column(TypeName = "datetime")]
        public DateTime InsertDate { get; set; } = DateTime.Now;

    }
}
