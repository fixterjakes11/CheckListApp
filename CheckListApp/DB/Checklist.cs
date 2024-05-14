using System;
using System.Collections.Generic;

namespace CheckListApp.DB
{
    public partial class Checklist
    {
        public Checklist()
        {
            CompletedTasks = new HashSet<CompletedTask>();
        }

        public int ChecklistId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<CompletedTask> CompletedTasks { get; set; }
    }
}
