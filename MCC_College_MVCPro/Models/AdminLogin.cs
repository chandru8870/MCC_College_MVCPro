using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCC_College_MVCPro.Models
{
    public class AdminLogin
    {
        public int id { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}