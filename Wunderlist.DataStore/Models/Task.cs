using System;
using System.ComponentModel.DataAnnotations;

namespace Wunderlist.DataStore.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime? Due { get; set; }

        public DateTime? DateCompleted { get; set; }
    }
}
