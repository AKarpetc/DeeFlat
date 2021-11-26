using DeeFlat.Homework.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeeFlat.Homework.DataAccess.Data
{
    public class HomeworkContext : DbContext
    {
        public HomeworkContext(DbContextOptions<HomeworkContext> options) : base(options)
        {
        }

        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Chat> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatMessage>()
                .Property(p => p.MessageIndex)
                .ValueGeneratedOnAdd();
        }
    }
}
