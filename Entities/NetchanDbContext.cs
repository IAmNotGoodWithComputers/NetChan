using Microsoft.EntityFrameworkCore;

namespace NetChan.Entities
{
    public class NetchanDbContext: DbContext
    {
        public NetchanDbContext(DbContextOptions<NetchanDbContext> options)
            : base(options)
        { }
        
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Thread> Threads { get; set; }
    }
}