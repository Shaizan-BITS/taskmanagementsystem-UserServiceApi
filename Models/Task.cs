using System;
using System.Collections.Generic;

namespace UserServiceApi.Models
{
    public partial class Task
    {
        public Task()
        {
        }

        public Guid TaskId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int? Priority { get; set; }
        public string? Category { get; set; }
        public Guid? AssigneeId { get; set; }
        public Guid? CreatorId { get; set; }

        public virtual User? Assignee { get; set; }
        public virtual User? Creator { get; set; }
    }
}
