using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PrototypeAdal4.Models
{

    public class Release
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReleaseID { get; set; }

        //Release is for a single Product, so there's a ProductID foreign key propery
        //& a Product navigation property (below)
        public int ProductID { get; set; }

        //Release is for a single approval, so there's an ApprovalID foreign key property 
        //& an Approval navigation property (below)
        public int ApprovalID { get; set; }

        public Product Product { get; set; }
        public Approval Approval { get; set; }

        //Navigation property
        //public ICollection<Approval> Approvals { get; set; }
    }
}
