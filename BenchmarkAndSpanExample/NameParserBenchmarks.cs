using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkAndSpanExample
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class NameParserBenchmarks
    {
        private const string FullName = "Steve J Gordon";
        private static readonly NameParser Parser = new NameParser();

        [Params(1, 500)]
        public int Iterations { get; set; }

        [Benchmark(Baseline = true)]
        public void GetLastName()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Parser.GetLastName(FullName);
            }
        }

        [Benchmark]
        public void GetLastNameWithSpan()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Parser.GetLastNameWithSpan(FullName);
            }
        }
    }
}
