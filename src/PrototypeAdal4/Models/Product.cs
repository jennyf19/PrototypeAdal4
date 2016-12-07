using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypeAdal4.Models
{
    public class Product
    {
        public int ID { get; set; }
        //public int VersionNumID { get; set; }

        public string ProductName { get; set; }

        public string VersionNumber { get; set; }

        public string ReleaseNotes { get; set; }

        public ICollection<Approval> Approvals { get; set; }
    }
}
