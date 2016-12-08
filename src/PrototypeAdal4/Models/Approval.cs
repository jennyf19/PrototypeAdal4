using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypeAdal4.Models
{
    public enum ApprovalStatus
    {
        Pending, Approved, Denied
    }

    public class Approval
    {
        public int ApprovalID { get; set; }

        //public int ProductID { get; set; }

        [DisplayFormat(NullDisplayText = "No Status")]
        [Display(Name = "Approval Status")]
        public ApprovalStatus? ApprovalStatus { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Enter a name less than 50 characters")]
        [Display(Name = "Approved by")]
        public string ApprovedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Approved")]
        public DateTime ApprovedDate { get; set; }

        public ICollection<Release> Releases { get; set; }

    }
}
