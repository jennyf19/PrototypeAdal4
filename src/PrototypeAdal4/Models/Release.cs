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

       public int ProductID { get; set; }

        public int ApprovalID { get; set; }

        //Navigation property
        public ICollection<Approval> Approvals { get; set; }
    }
}
