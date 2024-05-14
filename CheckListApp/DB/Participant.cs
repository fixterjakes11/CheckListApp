using System;
using System.Collections.Generic;

namespace CheckListApp.DB
{
    public partial class Participant
    {
        public Participant()
        {
            CompletedTasks = new HashSet<CompletedTask>();
        }

        public int ParticipantId { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? ContactInfo { get; set; }

        public virtual ICollection<CompletedTask> CompletedTasks { get; set; }
    }
}
