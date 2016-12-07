using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypeAdal4.Models
{
    public class Release
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReleaseID { get; set; }

        public DateTime SubmissionDateTime { get; set; }

        public int ProductID { get; set; }

        //Navigation property
        public ICollection<Approval> Approvals { get; set; }
    }
}
