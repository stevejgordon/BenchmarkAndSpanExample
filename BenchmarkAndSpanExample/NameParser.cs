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

            ReadOnlySpan<char> nameSlice;

            while (true)
            {
                nameSlice = fullName.Slice(lastSpacePosition + 1);
                    
                var spaceIndex = nameSlice.IndexOf(' ');

                if (spaceIndex == -1)
                {
                    break;
                }

                lastSpacePosition = spaceIndex + lastSpacePosition + 1;
            }

            return lastSpacePosition == -1 ? ReadOnlySpan<char>.Empty : nameSlice;
        }
    }
}
