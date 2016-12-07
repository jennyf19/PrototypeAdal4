using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrototypeAdal4.Models
{
    public class Product
    {
        public int ID { get; set; }
        //public int VersionNumID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Product Name cannot be longer than 50 characters")]
        public string ProductName { get; set; }

        [Required]
        [RegularExpression(@"^v[1-9]{1,2}\.([0-9]{1,2}\.)([0-9]{1,3})$", ErrorMessage = "The version number must be in the following format: v0.00.00")]
        public string VersionNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string ReleaseNotes { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SubmissionDate { get; set; }

        public ICollection<Release> Releases { get; set; }

        public ICollection<Approval> Approvals { get; set; }
    }
}
