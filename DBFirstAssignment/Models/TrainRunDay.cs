using System;
using System.Collections.Generic;

namespace DBFirstAssignment.Models
{
    public partial class TrainRunDay
    {
        public int TrainId { get; set; }
        public decimal TrainNo { get; set; }
        public string? RunDays { get; set; }

        public virtual TrainMaster TrainNoNavigation { get; set; } = null!;
    }
}
