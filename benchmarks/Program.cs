using System;
using System.Collections.Generic;
using BenchmarkDotNet.Running;


namespace IsQualifiedName
{
    class Program
    {
        static void Main(string[] args)
        {
            // foreach (var test in new[] { "aaaa.bbbb", "aaaa.", ".aaaa", "a. b1bbb", "a. .b" })
            // {
            //     Console.WriteLine("{0} {1}", test, IsQualifiedName(test));
            // }

            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }

        internal static bool IsQualifiedName2(string name)
        {
            bool allWhitespace = true;

            bool hasDot = false;

            foreach (char ch in name)
            {
                if (ch == '.')
                {
                    if (allWhitespace)
                    {
                        return false;
                    }

                    hasDot = true;
                    allWhitespace = true;
                }
                else if (!char.IsWhiteSpace(ch))
                {
                    allWhitespace = false;
                }
            }

            return hasDot ^ allWhitespace;
        }


        internal static bool IsQualifiedNameScanner(string name)
        {
            ReadOnlySpan<char> current = name;

            // starts with an identifier
            if (!(current.Next(out var token) && token == Token.Ident))
            {
                return false;
            }

            // a sequence of 0 or more ...
            while (!current.IsEmpty)
            {
                // expect a period
                if (!(current.Next(out token) && token == Token.Period))
                {
                    return false;
                }

                // followed by an identifier
                if (!(current.Next(out token) && token == Token.Ident))
                {
                    return false;
                }
            }
            return true;
        }
    }
}