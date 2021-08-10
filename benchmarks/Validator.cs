using System;
using System.Linq;

namespace IsQualifiedName
{
    class Validator
    {

        public static bool IsQualifiedNameSplit(string name)
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

            bool IsNullOrWhiteSpaceInternal(String value)
            {
                return value == null || value.ToCharArray().All(Char.IsWhiteSpace);
            }

            return true;
        }

        public static bool IsQualifiedName2(string name)
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

        public static bool IsQualifiedNameScanner(string name)
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

        public static bool IsQualifiedNameCustomScanner(string name)
        {
            var span = new TextSpan(name);

            // starts with an identifier
            if (!(span.Next(out var token) && token == Token.Ident))
            {
                return false;
            }

            // a sequence of 1 or more  '.' <ident>
            do
            {
                // expect a period
                if (!(span.Next(out token) && token == Token.Period))
                {
                    return false;
                }

                // followed by an identifier
                if (!(span.Next(out token) && token == Token.Ident))
                {
                    return false;
                }
            } while (!span.IsEmpty);
            return true;
        }
    }
}