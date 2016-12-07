using System;
using System.Collections.Generic;
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

        public int ProductID { get; set; }

        public ApprovalStatus? ApprovalStatus { get; set; }

        public string ApprovedBy { get; set; }
        public DateTime ApprovedDateTime { get; set; }

        public Product Product { get; set; }

        public Release Release { get; set; }

    }
}
