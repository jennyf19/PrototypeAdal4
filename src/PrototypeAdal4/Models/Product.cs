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

        public string ProductName { get; set; }

        public string VersionNumber { get; set; }

        public string ReleaseNotes { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SubmissionDate { get; set; }

        public ICollection<Approval> Approvals { get; set; }
    }
}
