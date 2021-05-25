using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PoorChase.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }
        public User Owner { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }

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
        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public string PicturePath1 { get; set; }

        public string PicturePath2 { get; set; }

        public string PicturePath3 { get; set; }

        public ProductState State { get; set; }
    }
}
