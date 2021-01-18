using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdodonetCoreMVC.Models
{
    [Table("Emp1")]
    public class Emp1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Empid { get; set; }
        public string Empname { get; set; }
        public string gender { get; set; }
    }
}
