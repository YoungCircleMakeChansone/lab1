using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int TypeId { get; set; }
        public EventType Type { get; set; }

        public List<Sport> Sports { get; set; } = new List<Sport>();
    }
}
