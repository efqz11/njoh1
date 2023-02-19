using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Njoh.Data.Models
{
    public class Specification
    {
        public int Id { get; set; }

        public int ListingId { get; set; }
        public virtual Listing Listing { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
