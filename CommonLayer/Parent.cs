using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class Parent
    {
        //public Employee Employee { get; set; }

        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ProfileImage { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Required")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Required")]
        public DateTime StartDate { get; set; }


        public string Description { get; set; }


        public string Department { get; set; }



        //public Departments Departments { get; set; }


        [Display(Name = "Hr")]
        public bool isHr { get; set; }

        [Display(Name = "Finance")]

        public bool isFinance { get; set; }

        [Display(Name = "Sales")]

        public bool isSales { get; set; }

        [Display(Name = "Others")]

        public bool isOthers { get; set; }
    }
}
