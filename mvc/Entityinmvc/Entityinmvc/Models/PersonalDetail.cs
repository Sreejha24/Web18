using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entityinmvc.Models
{
    [Table("Person18")]
    public class PersonalDetail
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please write your LastName")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter valid EmailId")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please check number")]
        public long Mobile { get; set; }
    }
}