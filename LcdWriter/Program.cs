using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcdWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = CheckArgs(args);

			var digitFactory = new DigitFactory();

            var lcdWriterService = new LcdWriterService(input, Console.CursorTop, digitFactory);
            lcdWriterService.Write();

            Console.ReadKey();
        }

        static string CheckArgs(string[] args)
        {
            if (args == null || !args.Any() || args.Count() > 1)
            {
                Console.WriteLine("Enter a few numbers (without spaces) and type `Return` to finish :");
                Console.WriteLine();
                return Console.ReadLine();
            }

            // from command line
            Console.WriteLine($"You have entered: {args[0]}");
            return args[0];
        }
    }
}
