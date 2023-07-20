using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRest.Shared
{
    public class StudientDTO
    {
        public int IdStudent { get; set; }

        [Required(ErrorMessage = "The {0} field must be filled")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "The {0} must be filled")]
        public string? LastName { get; set; }

        public DateTime? AdmissionDate { get; set; }

        [Required(ErrorMessage = "The {0} field must be filled")]
        public string? Career { get; set; }

        public DateTime? RegisterDate { get; set; }

    }
}
