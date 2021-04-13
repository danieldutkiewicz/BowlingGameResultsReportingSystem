using System.Collections.Generic;

namespace BowlingGameResultsReportingSystem
{
    public class Game
    {
        public Player Player { get; set; }
        public List<Frame> Frames { get; set; }
        public List<int> RollingResult { get; set; }
    }
}
