using System;
using System.Collections.Generic;
using System.Linq;
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

        internal static bool IsQualifiedNameSplit(string name)
        {
            string[] nameTokens = name.Split('.');
            if (nameTokens.Length < 2)
            {
                return false;
            }

            foreach (string token in nameTokens)
            {
                if (IsNullOrWhiteSpaceInternal(token))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool IsNullOrWhiteSpaceInternal(String value)
        {
            return value == null || value.ToCharArray().All(Char.IsWhiteSpace);
        }



        internal static bool IsQualifiedNameScanner(string name)
        {
            ReadOnlySpan<char> current = name;

            // starts with an identifier
            if (!(current.Next(out var token) && token == Token.Ident))
            {
                return false;
            }

            // a sequence of 1 or more  '.' <ident>
            do
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
            } while (!current.IsEmpty);
            return true;
        }
    }
}