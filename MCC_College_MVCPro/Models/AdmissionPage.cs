using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace MCC_College_MVCPro.Models
{
    public class AdmissionPage
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Please enter your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Name")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Please enter your Father Name")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }
            
      
        [Required(ErrorMessage ="Please select Your department")]
        public string JoiningDepartment { get; set; }

    }
  


}