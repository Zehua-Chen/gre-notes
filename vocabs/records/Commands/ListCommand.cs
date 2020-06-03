using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Records.Models;

namespace Records.Commands
{
    public class ListCommand : Command
    {
        public int Filter { get; set; }
        public override ValueTask RunAsync(RecordsContext context)
        {
            var words = context.Words
                .AsNoTracking()
                .Where((word) => word.Misses >= this.Filter);

            foreach (Word word in words)
            {
                Console.WriteLine($"{word.Name}: {word.Misses}");
            }

            return new ValueTask();
        }
    }
}
