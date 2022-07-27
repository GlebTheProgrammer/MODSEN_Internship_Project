using System.ComponentModel.DataAnnotations;

namespace Meetup_API.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Plan { get; set; }

        [Required]
        [MaxLength(255)]
        public string Organizer { get; set; }

        [Required]
        [MaxLength(255)]
        public string Speaker { get; set; }

        [Required]
        [MaxLength(12)]
        public string Date { get; set; }

        [MaxLength(255)]
        [Required]
        public string Place { get; set; }
    }
}
