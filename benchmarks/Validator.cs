using System;
using System.Linq;


namespace IsQualifiedName
{
    public class Validator
    {
        public static bool IsQualifiedName2(string name)
        {
            bool isAllWhiteSpace = true;
            bool hasDot = false;

            foreach (char ch in name)
            {
                if (ch == '.')
                {
                    if (isAllWhiteSpace)
                    {
                        return false;
                    }

                    hasDot = true;
                    isAllWhiteSpace = true;
                }
                else if (!char.IsWhiteSpace(ch))
                {
                    isAllWhiteSpace = false;
                }
            }

            return hasDot && !isAllWhiteSpace;
        }

        public static bool IsQualifiedName3(string name)
        {
            bool foundDot = false;
            bool previousSegmentAllWhitespace = true;
            foreach (char ch in name)
            {
                if (ch == '.')
                {
                    foundDot = true;
                    if (previousSegmentAllWhitespace)
                    {
                        return false;
                    }
                    previousSegmentAllWhitespace = true;
                }
                else if (!char.IsWhiteSpace(ch))
                {
                    previousSegmentAllWhitespace = false;
                }
            }

            return foundDot & !previousSegmentAllWhitespace;
        }

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

            return true;

            static bool IsNullOrWhiteSpaceInternal(String value)
            {
                return value == null || value.ToCharArray().All(Char.IsWhiteSpace);
            }
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
    }

#if DEBUG

#endif
}