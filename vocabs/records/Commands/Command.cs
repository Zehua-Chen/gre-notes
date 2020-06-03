using System;
using System.Threading.Tasks;

namespace Records.Commands
{
    public abstract class Command
    {
        public abstract ValueTask RunAsync(RecordsContext context);

        public static Command Parse(string line)
        {
            string[] words = line
                .Trim()
                .ToLower()
                .Split(' ');

            if (words.Length == 0)
            {
                throw new ArgumentException("\"line\" needs to contain more than one string");
            }

            switch (words[0])
            {
                case "remove":
                    if (words.Length != 2)
                    {
                        throw new Exception("Command needs to have the pattern \"remove <word>\"");
                    }

                    return new RemoveCommand()
                    {
                        Word = words[1]
                    };
                case "record":
                    if (words.Length != 2)
                    {
                        throw new Exception("Command needs to have the pattern \"record <word>\"");
                    }

                    return new RecordCommand()
                    {
                        Word = words[1]
                    };
                case "list":
                    int filter = 0;

                    if (words.Length == 1)
                    {
                        filter = -1;
                    }
                    else if (words.Length == 2)
                    {
                        filter = Convert.ToInt32(words[1]);
                    }
                    else
                    {
                        throw new Exception("Command needs to have hte pattern list (filter)");
                    }

                    return new ListCommand()
                    {
                        Filter = filter
                    };
                default:
                    throw new Exception($"Unrecognized command {words[0]}");
            }
        }
    }
}
