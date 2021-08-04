using System;

namespace IsQualifiedName
{

    internal enum Token { Ident, Period, Whitespace, Other };


    internal static class Scanner
    {
        public static bool Next(this ref ReadOnlySpan<char> current, out Token token)
        {
        Start:
            if (current.IsEmpty)
            {
                token = default;
                return false;
            }

            var ch = current[0];
            switch (ch)
            {
                case ' ':
                case '\t':
                case '\r':
                case '\n':
                    {
                        int i = 0;
                        for (; i < current.Length && char.IsWhiteSpace(current[i]); i++)
                        {
                        };
                        current = current.Slice(i);
                        token = Token.Whitespace;
                        goto Start; // whitespace gets skipped
                    }
                    
                // TODO: add uppercase letters
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                case '_':
                    {
                        int i = 0;
                        for (; i < current.Length && (char.IsLetterOrDigit(current[i]) || current[i] == '_'); i++)
                        {
                        };
                        current = current.Slice(i);
                        token = Token.Ident;
                        return true;
                    }

                case '.':
                    current = current.Slice(1);
                    token = Token.Period;
                    return true;

                default:
                    current = current.Slice(1);
                    token = Token.Other;
                    return true;
            }
        }
    }
}
