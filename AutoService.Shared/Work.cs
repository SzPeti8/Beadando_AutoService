using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Shared
{
    public class Work
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{3}-\d{3}$", ErrorMessage = "RegPlate must be in the format XXX-YYY (X: uppercase letters, Y: numbers).")]
        public string RegPlate { get; set; }

        [Required]
        [Range(typeof(DateOnly), "1900-01-01", "9999-12-31", ErrorMessage = "DateOfMake cannot be older than January 1, 1900.")]
        public DateOnly DateOfMake { get; set; }

        [Required]
        [RegularExpression(@"^(Karosszeria|Motor|Futomu|Fekberendezes)$", ErrorMessage = "WorkType must be one of the following: Karosszeria, Motor, Futomu, Fekberendezes.")]
        public WorkTypeEnum WorkType { get; set; }

        
        [Required(AllowEmptyStrings = false)]
        public string FaultDescription { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "FaultSeverity must be a number between 1 and 10.")]
        public int FaultSeverity { get; set; }


        [Required]
        [EnumDataType(typeof(WorkStatusEnum))]
        public WorkStatusEnum WorkStatus { get; set; }
  
    }

    public enum WorkTypeEnum
    {
        Karosszeria = 0,
        Motor = 1,
        Futomu = 2,
        Fekberendezes = 3,
    }

    public enum WorkStatusEnum
    {
        
        FelvettMunka = 0,
        ElvegzesAlatt = 1,
        Befejezett = 2,
    }
}
