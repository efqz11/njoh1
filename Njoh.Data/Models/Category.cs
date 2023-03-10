using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Njoh.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }



        // Reference Foreign Key
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
    }
}
