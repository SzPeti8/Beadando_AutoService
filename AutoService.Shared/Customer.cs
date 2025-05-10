using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Shared
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [RegularExpression(@"\S.*", ErrorMessage = "Name cannot be only whitespaces.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"\S.*", ErrorMessage = "Address cannot be only whitespaces.")]
        public string Adress { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"\S.*", ErrorMessage = "Email cannot be only whitespaces.")]
        public string Email { get; set; }
    }
}
