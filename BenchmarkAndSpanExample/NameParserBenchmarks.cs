using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkAndSpanExample
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class NameParserBenchmarks
    {
        private static readonly string FullName = "Steve J Gordon";
        private static readonly NameParser Parser = new NameParser();

        [Benchmark(Baseline = true)]
        public void GetLastName()
        {
            Parser.GetLastName(FullName);
        }

        [Benchmark]
        public void GetLastNameWithSpan()
        {
            Parser.GetLastNameWithSpan(FullName);
        }
    }
}
