using System.ComponentModel.DataAnnotations;

namespace lab.Entities
{
    public class EventType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
