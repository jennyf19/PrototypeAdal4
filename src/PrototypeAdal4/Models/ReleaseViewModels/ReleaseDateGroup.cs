using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PrototypeAdal4.Models.ReleaseViewModels
{
    public class ReleaseDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? SubmissionDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ApprovedDateTime { get; set; }

        public int ReleaseCount { get; set; }
    }
}
