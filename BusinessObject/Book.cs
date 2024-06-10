using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Type { get; set; }

        [ForeignKey("Publisher")]
        public int PubId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal Advance { get; set; }

        public int Royalty { get; set; }

        public int YtdSales { get; set; }

        public string Notes { get; set; }

        public DateTime PublishedDate { get; set; }

        public Publisher Publisher { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
