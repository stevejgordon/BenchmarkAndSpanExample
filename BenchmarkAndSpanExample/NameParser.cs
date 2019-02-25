using System;
using System.Linq;

namespace BenchmarkAndSpanExample
{
    public class NameParser
    {
        public string GetLastName(string fullName)
        {
            var names = fullName.Split(" ");

            var lastName = names.LastOrDefault();

            return lastName ?? string.Empty;
        }

        public ReadOnlySpan<char> GetLastNameWithSpan(ReadOnlySpan<char> fullName)
        {
            var lastSpacePosition = -1;

            while (true)
            {
                var spaceIndex = fullName.Slice(lastSpacePosition + 1).IndexOf(' ');

                if (spaceIndex == -1)
                {
                    break;
                }

                lastSpacePosition = spaceIndex + lastSpacePosition + 1;
            }

            if (lastSpacePosition == -1)
                return string.Empty;

            var lastName = fullName.Slice(lastSpacePosition + 1);

            return lastName;
        }
    }
}
