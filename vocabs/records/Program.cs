using System;
using System.Threading.Tasks;
using Records.Commands;
using Microsoft.EntityFrameworkCore;

namespace Records
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using RecordsContext context = new RecordsContext();

            await context.Database.MigrateAsync();

            while (true)
            {
                try
                {
                    Console.Write("> ");
                    string line = Console.ReadLine();

                    if (line == "")
                    {
                        continue;
                    }

                    await Command.Parse(line).RunAsync(context);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
