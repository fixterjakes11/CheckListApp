using System;
using System.Collections.Generic;

namespace CheckListApp.DB
{
    public partial class CompletedTask
    {
        public int TaskId { get; set; }
        public int? ChecklistId { get; set; }
        public int? ParticipantId { get; set; }
        public DateTime? TaskDate { get; set; }
        public string? Status { get; set; }

        public virtual Checklist? Checklist { get; set; }
        public virtual Participant? Participant { get; set; }
    }
}
