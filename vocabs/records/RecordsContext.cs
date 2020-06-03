using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Records.Models;

namespace Records
{
    public class RecordsContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=words.db");
        }
    }
}
