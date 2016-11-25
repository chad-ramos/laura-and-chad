using System.Data.Entity;
using LauraAndChad.Models;

namespace LauraAndChad
{
    public class LauraAndChad : DbContext
    {
        public DbSet<Rsvp> Rsvps { get; set; }
    }
}
