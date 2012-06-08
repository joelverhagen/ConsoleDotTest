using System;
using System.Threading;
using NDesk.Options;

namespace ConsoleDotTest
{
    class Program
    {
        private const int LINES_READ = 3;
        private const int SLEEP_TIME = 3;

        static int Main(string[] args)
        {
            // gross, but it works
            bool help = false;
            bool stdin = false;
            bool stderr = false;
            bool stdout = false;
            bool wait = false;
            bool fail = false;

            // create the option set to determine the command-line arguments that this application accepts
            OptionSet optionSet = new OptionSet()
            {
                { "h|help", "show this help message", v => help = true },
                { "i|stdin", "reads in " + LINES_READ + " lines from STDIN, which will be echoed back on STDOUT before termination", v => stdin = true },
                { "e|stderr", "output a message to STDERR", v => stderr = true },
                { "o|stdout", "output a message to STDOUT", v => stdout = true },
                { "w|wait", "wait " + SLEEP_TIME + " seconds before terminating", v => wait = true },
                { "f|fail", "terminate with a non-zero exit code", v => fail = true },
            };

            try
            {
                optionSet.Parse(args);

                // if no valid parameters were provided, then display the help message
                help = help || (!stdin && !stderr && !stdout && !wait && !fail);
            }
            catch (OptionException)
            {
                help = true;
            }

            if (help)
            {
                // output the actual help message
                Console.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName + " [OPTIONS]");
                Console.WriteLine("  Facilitates some basic command-line operations, for testing purposes.");
                Console.WriteLine();
                Console.WriteLine("Options:");
                optionSet.WriteOptionDescriptions(Console.Out);

                return 0;
            }

            string input = String.Empty;
            if (stdin)
            {
                // read in three lines of text and store them for outputting later
                for (int i = 0; i < LINES_READ; i++)
                {
                    input += Console.ReadLine() + Environment.NewLine;
                }
            }

            if (stderr)
            {
                // output the message to STDERR
                Console.Error.WriteLine("ERROR: This is the first line of an error message.");
                Console.Error.WriteLine("  ERROR: This is the second line. Here comes an empty line.");
                Console.Error.WriteLine();
                Console.Error.WriteLine("  ERROR: The message is now done.");
            }

            if (stdout)
            {
                // output the message to STDOUT
                Console.Error.WriteLine("OUT: This is the first line of a normal message.");
                Console.Error.WriteLine("  OUT: This is the second line. Here comes an empty line.");
                Console.Error.WriteLine();
                Console.Error.WriteLine("  OUT: The message is now done.");
            }

            if (wait)
            {
                // sleep for the specified time
                Thread.Sleep(SLEEP_TIME * 1000);
            }

            // ouput the user input back, if it exists
            if (!String.IsNullOrEmpty(input))
            {
                Console.Write(input);
            }

            // conditional return a non-success exit code
            return fail ? 1 : 0;
        }
    }
}
