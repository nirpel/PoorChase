using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoorChase.Site
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(500)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(4000)]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Required")]
        public decimal Price { get; set; }

        public IFormFile Picture1 { get; set; }

        public IFormFile Picture2 { get; set; }

        public IFormFile Picture3 { get; set; }
    }
}
