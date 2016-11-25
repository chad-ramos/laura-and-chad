using System.Data.Entity;
using LauraAndChad.Models;

namespace LauraAndChad
{
    public class LauraAndChadContext : DbContext
    {
        public LauraAndChadContext() : base("name=LauraAndChadContext")
        {
        }

        public DbSet<Rsvp> Rsvps { get; set; }
    }
}
