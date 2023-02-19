using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Njoh.Data.Models
{
    public class Listing
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }


        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public virtual List<Specification> Spectifications { get; set; }

        public Listing()
        {
            Spectifications = new List<Specification>();
        }
    }
}
