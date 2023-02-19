using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Njoh.Data.ViewModels
{
    public class ListingVm
    {

        [StringLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }


        public int CategoryId { get; set; }


        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public virtual Dictionary<string, string> Spectifications { get; set; }

        public ListingVm()
        {
            Spectifications = new Dictionary<string, string>();
        }
    }
}
