namespace TaskManagementSystemAPI.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Pending, In Progress, Completed
        public DateTime Deadline { get; set; }
        public string Priority { get; set; } // Low, Medium, High
        public int UserId { get; set; } // Foreign Key to User
        public User User { get; set; } // Navigation property
    }

}
