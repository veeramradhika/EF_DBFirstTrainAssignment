using System;
using System.Collections.Generic;

namespace DBFirstAssignment.Models
{
    public partial class TrainMaster
    {
        public TrainMaster()
        {
            TrainRunDays = new HashSet<TrainRunDay>();
        }

        public decimal TrainNo { get; set; }
        public string? TrainName { get; set; }
        public string? FromStation { get; set; }
        public string? ToStation { get; set; }
        public TimeSpan? JourneyStartTime { get; set; }
        public TimeSpan? JourneyEndTime { get; set; }

        public virtual ICollection<TrainRunDay> TrainRunDays { get; set; }
    }
}
