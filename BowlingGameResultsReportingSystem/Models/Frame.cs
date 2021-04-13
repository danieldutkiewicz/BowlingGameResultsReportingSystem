namespace BowlingGameResultsReportingSystem
{
    public class Frame
    {
        public int FirstThrow { get; set; }
        public int SecondThrow { get; set; }
        public bool IsStrike => FirstThrow == 10;
        public bool IsSpare => FirstThrow + SecondThrow == 10 && IsStrike == false;
    }
}
