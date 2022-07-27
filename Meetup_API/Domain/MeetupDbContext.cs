using Meetup_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Meetup_API.Domain
{
    public class MeetupDbContext : DbContext
    {
        public MeetupDbContext(DbContextOptions<MeetupDbContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
    }
}
