using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BowlingGameResultsReportingSystem
{
    public class GameLoader
    {
        public List<Game> LoadAllGamesFromFile(string pathToFile)
        {
            var playerNames = GetAllPlayers(pathToFile);
            var throws = GetAllThrows(pathToFile);

            List<Game> games = new List<Game>();
            for (var i = 0; i < playerNames.Count(); i++)
            {
                var frames = SortThrowsIntoFrames(throws[i]);
                var frameResults = CalculateFramesResults(frames);
                var rollingResult = ConvertResultToRolling(frameResults);
                games.Add(new Game() { Player = playerNames[i], Frames = frames, RollingResult = rollingResult });
            }
            return games;
        }

        private List<int> ConvertResultToRolling(List<int> frameResults)
        {
            List<int> rollingResults = new List<int>();
            for (var result = 0; result < frameResults.Count(); result++)
            {
                var score = rollingResults.LastOrDefault() + frameResults.ElementAt(result);
                rollingResults.Add(score);
            }
            return rollingResults;
        }

        private List<Frame> SortThrowsIntoFrames(int[] throws)
        {
            List<Frame> frames = new List<Frame>();
            for (var i = 0; i < throws.Length; i++)
            {   
                if (IsLastFrame(frames) && IsStrike(throws[i]))
                {
                    frames.Add(new Frame { FirstThrow = throws[i], SecondThrow = throws[NextThrow(i)] });
                    return frames;
                }
                else if (IsStrike(throws[i]))
                {
                    frames.Add(new Frame { FirstThrow = throws[i] });
                    continue;
                }
                else if (IsNextThrow(throws, i))
                {
                    frames.Add(new Frame { FirstThrow = throws[i], SecondThrow = throws[NextThrow(i)] });
                    i++;
                }
                else
                {
                    frames.Add(new Frame { FirstThrow = throws[i] });
                }
            }
            return frames;
        }

        private List<int> CalculateFramesResults(List<Frame> frames)
        {
            List<int> frameResults = new List<int>();
            for (var i = 0; i < frames.Count(); i++)
            {
                if (IsStrike(frames[i]))
                {
                    if (IsNextFrameTheLastFrame(i))
                    {
                        frameResults.Add(
                            frames[i].FirstThrow +
                            frames[GetNextFrame(i)].FirstThrow +
                            frames[GetNextFrame(i)].SecondThrow);
                        return frameResults;
                    }
                    else if (IsStrike(frames[GetNextFrame(i)]))
                    {
                        frameResults.Add(
                            frames[i].FirstThrow +
                            frames[GetNextFrame(i)].FirstThrow +
                            frames[GetNextNextFrame(i)].FirstThrow);
                    }
                    else
                    {
                        frameResults.Add(
                            frames[i].FirstThrow +
                            frames[GetNextFrame(i)].FirstThrow +
                            frames[GetNextFrame(i)].SecondThrow);
                    }
                }
                else if (IsSpare(frames[i]))
                {
                    frameResults.Add(frames[i].FirstThrow + frames[i].SecondThrow + frames[GetNextFrame(i)].FirstThrow);
                }
                else
                {
                    if (IsNotLastFrame(i))
                        frameResults.Add(frames[i].FirstThrow + frames[i].SecondThrow);
                }
            }
            return frameResults;
        }

        private bool IsEverySecondLine(int lineIndex)
        {
            return lineIndex % 2 != 0;
        }

        private int[] ConvertStringScoresIntoScoresArrayOfInts(string scoreLine)
        {
            var cleanedScoreLine = scoreLine.Trim().Split(',');
            return cleanedScoreLine.Select(x => Convert.ToInt32(x)).ToArray();
        }

        private bool IsLastFrame(List<Frame> frames)
        {
            return frames.Count == 10;
        }

        private bool IsLastFrame(int frame)
        {
            return frame == 10;
        }

        private bool IsNextFrameTheLastFrame(int currentFrame)
        {
            return IsLastFrame(currentFrame + 1);
        }

        private bool IsNextThrow(int[] throws, int @throw)
        {
            return @throw + 1 < throws.Length;
        }

        private bool IsStrike(int point)
        {
            return point == 10;
        }

        private bool IsStrike(Frame frame)
        {
            return frame.IsStrike == true;
        }

        private bool IsSpare(Frame frame)
        {
            return frame.IsSpare == true;
        }

        private int NextThrow(int currentThrow)
        {
            return currentThrow + 1;
        }

        private int GetNextFrame(int currentFrame)
        {
            return currentFrame + 1;
        }

        private int GetNextNextFrame(int currentFrame)
        {
            return currentFrame + 2;
        }

        private bool IsNotLastFrame(int currentFrame)
        {
            return currentFrame < 10;
        }

        private List<int[]> GetAllThrows(string pathToFile)
        {
            var lines = File.ReadAllLines(pathToFile);
            List<int[]> scores = new List<int[]>();
            for (var line = 0; line < lines.Length; line++)
            {
                if (IsEverySecondLine(line))
                    scores.Add(ConvertStringScoresIntoScoresArrayOfInts(lines[line]));
            }
            return scores;
        }

        private List<Player> GetAllPlayers(string pathToFile)
        {
            var lines = File.ReadAllLines(pathToFile);
            List<Player> player = new List<Player>();
            for (var line = 0; line < lines.Length; line++)
            {
                if (!IsEverySecondLine(line))
                    player.Add(new Player() { Name = lines[line] });
            }
            return player;
        }
    }
}
