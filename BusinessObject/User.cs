using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public string Source { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [ForeignKey("Publisher")]
        public int PubId { get; set; }

        public DateTime HireDate { get; set; }

        public Role Role { get; set; }

        public Publisher Publisher { get; set; }
    }
}
