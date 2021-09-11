
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace CommonLayer
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Required")]
        public string  Name { get; set; }

        [Required(ErrorMessage ="Required")]
        public string  ProfileImage { get; set; }

        [Required(ErrorMessage ="Required")]        
        public string  Gender { get; set; }

        [Required(ErrorMessage ="Required")]
        public int Salary { get; set; }

        [Required(ErrorMessage ="Required")]
        public DateTime  StartDate { get; set; }


        public string Description { get; set; }

        
        public string Department { get; set; }

        
    }
}
