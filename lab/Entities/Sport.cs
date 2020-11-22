using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab.Entities
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();
    }
}
