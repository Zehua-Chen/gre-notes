using System;
using System.Threading.Tasks;
using System.Linq;
using Records.Models;

namespace Records.Commands
{
    public class RemoveCommand : Command
    {
        public string Word { get; set; }

        public override async ValueTask RunAsync(RecordsContext context)
        {
            if (context.Words.Any((word) => word.Name == this.Word))
            {
                Word word = context.Words.Single((word) => word.Name == this.Word);

                context.Remove(word);
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine($"{this.Word} not found");
            }
        }
    }
}
