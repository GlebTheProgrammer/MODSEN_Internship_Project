using System.ComponentModel.DataAnnotations;

namespace Meetup_API.DTOs
{
    public class EventReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Plan { get; set; }

        public string Speaker { get; set; }

        public string Date { get; set; }

        public string Place { get; set; }
    }
}
