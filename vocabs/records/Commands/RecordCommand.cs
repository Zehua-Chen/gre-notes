using System;
using System.Threading.Tasks;
using System.Linq;
using Records.Models;

namespace Records.Commands
{
    public class RecordCommand : Command
    {
        public string Word { get; set; }

        public override async ValueTask RunAsync(RecordsContext context)
        {
            if (context.Words.Any((word) => word.Name == this.Word))
            {
                Word word = context.Words.Single((word) => word.Name == this.Word);
                word.Misses++;
            }
            else
            {
                Word word = new Word()
                {
                    Name = this.Word,
                    Misses = 1
                };

                await context.AddAsync(word);
            }

            await context.SaveChangesAsync();
        }
    }
}
