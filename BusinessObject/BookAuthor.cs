using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BookAuthor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookAuthorId { get; set; } // Adding primary key for BookAuthor

        [ForeignKey("Book")]
        public int BookId { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public int AuthorOrder { get; set; }

        public double RoyalityPercentage { get; set; }

        public Book Book { get; set; }

        public Author Author { get; set; }
    }
}
