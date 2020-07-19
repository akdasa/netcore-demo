using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wunderlist.DataStore.Models
{
    public class Notepad
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public bool IsArchived { get; set; } = false;

        public DateTime? Due { get; set; }

        public List<Task> Tasks { get; } = new List<Task>();
    }
}
