using System;

namespace IsQualifiedName
{

    class Program
    {
        static void Main(string[] args)
        {
            foreach (var test in new[] { "aaaa.bbbb", "aaaa.", ".aaaa", "a. b1bbb", "a. .b" })
            {
                Console.WriteLine("{0} {1}", test, Validator.IsQualifiedNameSplit(test));
            }
        }
    }
}