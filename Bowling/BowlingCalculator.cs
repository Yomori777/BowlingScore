namespace Bowling
{
    internal class BowlingCalculator
    {
        internal static int Calculate(List<Frame> frames, int index)
        {
            if (frames.Count <= index) return 0;

            if (frames[index].IsSpare && frames.Count > index+1)
            {
                return frames[index].Score + frames[index + 1].FirstScore;
            }

            if (frames[index].IsStrike && frames.Count > index + 1)
            {
                if(frames[index + 1].IsStrike && frames.Count > index + 2)
                {
                    return frames.Skip(index).Take(3).Sum(x => x.Score);
                }
                return frames.Skip(index).Take(2).Sum(x=>x.Score);
            }
            return frames[index].Score;
        }
    }
}