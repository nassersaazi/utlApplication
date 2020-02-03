using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace utlAPI.Models
{
    public class Admins
    {
        
        public int AdminId { get; set; }

        [DisplayName("Administrator Name")]
        [Required(ErrorMessage ="This field is required!")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }

    }
}