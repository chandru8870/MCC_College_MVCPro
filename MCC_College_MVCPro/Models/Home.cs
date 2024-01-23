using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCC_College_MVCPro.Models
{
    public class Home
    {
        [Key]
        public string id { get; set; }

        [Required(ErrorMessage ="Enter Your name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter Your Gmail Id")]
        [DataType(DataType.EmailAddress,ErrorMessage ="E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter subject")]
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}