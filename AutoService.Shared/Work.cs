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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "FaultDescription cannot be empty or whitespace.")]
        public string CustomerId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{3}-\d{3}$", ErrorMessage = "RegPlate must be in the format XXX-YYY (X: uppercase letters, Y: numbers).")]
        public string RegPlate { get; set; }

        [Required]
        [Range(typeof(DateOnly), "1900-01-01", "9999-12-31", ErrorMessage = "DateOfMake cannot be older than January 1, 1900.")]
        public DateOnly? DateOfMake { get; set; }

        [Required]
        [RegularExpression(@"^(Karosszeria|Motor|Futomu|Fekberendezes)$", ErrorMessage = "WorkType must be one of the following: Karosszeria, Motor, Futomu, Fekberendezes.")]
        public WorkTypeEnum WorkType { get; set; }

        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "FaultDescription cannot be empty or whitespace.")]
        public string FaultDescription { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "FaultSeverity must be a number between 1 and 10.")]
        public int FaultSeverity { get; set; }


        [Required]
        [RegularExpression(@"^(FelvettMunka|ElvegzesAlatt|Befejezett)$", ErrorMessage = "WorkStatus must be one of the following:  FelvettMunka, ElvegzesAlatt, Befejezett.")]
        public WorkStatusEnum WorkStatus { get; set; }

        public void SetWorkStatus(WorkStatusEnum value, bool canChangeWhitoutTests)
        {
            if(WorkStatus == value)
            {
                WorkStatus = value;
                return;
            }
            
            else if (WorkStatus == WorkStatusEnum.FelvettMunka && value == WorkStatusEnum.ElvegzesAlatt && !canChangeWhitoutTests)
            {
                WorkStatus = value;
                return;
            }
            else if (WorkStatus == WorkStatusEnum.ElvegzesAlatt && value == WorkStatusEnum.Befejezett && !canChangeWhitoutTests)
            {
                WorkStatus = value;
                return;
            }
            else
            {
                if (canChangeWhitoutTests)
                {
                    WorkStatus = value;
                    return;
                }
                else
                {
                    throw new InvalidOperationException($"Invalid state transition for WorkStatus: {WorkStatus} => {value}");
                }
                
            }
        }

       
    }

    public enum WorkTypeEnum
    {
        Karosszeria,
        Motor,
        Futomu,
        Fekberendezes
    }

    public enum WorkStatusEnum
    {
        
        FelvettMunka,
        ElvegzesAlatt,
        Befejezett
    }
}
