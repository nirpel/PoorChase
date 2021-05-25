using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PoorChase.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
