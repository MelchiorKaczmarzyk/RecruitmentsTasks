using BlazorNotes.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BlazorNotes.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options) 
        { 
            
        }
        public virtual DbSet<Note> Notes { get; set; }
    }
}
