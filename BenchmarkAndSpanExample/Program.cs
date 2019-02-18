using BenchmarkDotNet.Running;

namespace BenchmarkAndSpanExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<NameParserBenchmarks>();
        }
    }
}
