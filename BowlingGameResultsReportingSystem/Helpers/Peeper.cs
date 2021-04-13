using System.Collections.Generic;
using System.Diagnostics;

namespace BowlingGameResultsReportingSystem
{
    public class Peeper
    {
        public void PeepAtFrames(List<Frame> frames)
        {
            for (var frame = 0; frame < frames.Count; frame++)
            {
                Debug.WriteLine(
                    $"Frame {frame + 1}: " +
                    $"First throw: {frames[frame].FirstThrow}, " +
                    $"Second throw: {frames[frame].SecondThrow}, " +
                    $"IsStrike: {frames[frame].IsStrike}, " +
                    $"IsSpare: {frames[frame].IsSpare}");
            }
        }

        public void PeepAtEachFrameResult(List<int> framesResults)
        {
            for (var result = 0; result < framesResults.Count; result++)
                Debug.WriteLine($"Frame {result + 1} result: {framesResults[result]}");
        }

        public void PeepAtRollingResults(List<int> rollingResults)
        {
            for (var result = 0; result < rollingResults.Count; result++)
                Debug.WriteLine($"Frame {result + 1} rolling result: {rollingResults[result]}");
        }
    }
}
