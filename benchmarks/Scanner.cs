using System;
using System.Runtime.CompilerServices;

namespace IsQualifiedName
{
    internal enum Token { Ident, Period, Whitespace, Other };


    internal static class Scanner
    {
        public static bool Next(this ref ReadOnlySpan<char> current, out Token token)
        {
            // skip all whitespace
            int i = 0;
            for (; i < current.Length && char.IsWhiteSpace(current[i]); i++)
            {
            };
            current = current.Slice(i);

            // return if empty
            if (current.IsEmpty)
            {
                token = default;
                return false;
            }

            switch (current[0])
            {
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
                        i = 1;
                        for (; i < current.Length && (char.IsLetterOrDigit(current[i]) || current[i] == '_'); i++)
                        {
                        };
                        current = current.Slice(i);
                        token = Token.Ident;
                        return true;
                    }

                case '.':
                    {
                        current = current.Slice(1);
                        token = Token.Period;
                        return true;
                    }

                default:
                    {
                        current = current.Slice(1);
                        token = Token.Other;
                        return true;
                    }
            }
        }


        public static bool Next(this ref TextSpan span, out Token token)
        {
            char ch;
            // skip all whitespace
            while (span.TryGetFirst(out ch) && char.IsWhiteSpace(ch))
            {
                span = span.Slice(1);
            }

            // return if empty
            if (!span.TryGetFirst(out ch))
            {
                token = default;
                return false;
            }

            switch (ch)
            {
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
                        span = span.Slice(1);
                        while (span.TryGetFirst(out ch) && (char.IsLetterOrDigit(ch) || ch == '_'))
                        {
                            span = span.Slice(1);
                        }

                        token = Token.Ident;
                        return true;
                    }

                case '.':
                    {
                        span = span.Slice(1);
                        token = Token.Period;
                        return true;
                    }

                default:
                    {
                        span = span.Slice(1);
                        token = Token.Other;
                        return true;
                    }
            }
        }
    }

    ref struct TextSpan
    {
        public TextSpan(string text)
        {
            unsafe
            {
                fixed (char* p = text)
                {
                    current = p;
                    end = p + text.Length;
                }
            }
        }

        private unsafe TextSpan(char* c, char* e)
        {
            current = c;
            end = e;
        }

        unsafe char* current;

        unsafe char* end;

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { unsafe { return current >= end; } }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextSpan Slice(int n)
        {
            unsafe { return new TextSpan(current + n, end); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public bool TryGetFirst(out char ch)
        {
            unsafe
            {
                if (current < end)
                {
                    ch = *current;
                    return true;
                }
                else
                {
                    ch = default;
                    return false;
                }
            }
        }
    }
}
