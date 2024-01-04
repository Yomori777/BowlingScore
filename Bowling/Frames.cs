




namespace Bowling
{
    internal class Frames
    {
        List<Frame> _frame = new();
        internal void Bowl(int pin)
        {
            var frame = GetNowFrame();
            frame.Bowl(pin);
        }

        internal int GetTotalScore()
        {
            var score = 0;
            foreach (var index in Enumerable.Range(1, _frame.Count >= 10 ? 10 : _frame.Count))
            {
                score += GetFrameScore(index);
            }
            return score;
        }

        public int GetFrameScore(int index)
        {
            if (index == 0 || index > _frame.Count) return 0;
            return BowlingCalculator.Calculate(_frame, index);
        }

        private Frame GetNowFrame()
        {
            if (_frame.Count == 0 || _frame.Last().IsFull)
            {
                _frame.Add(new Frame());
            }
            return _frame.Last();
        }
    }

    internal class BowlingCalculator
    {
        internal static int Calculate(List<Frame> frames, int index)
        {
            if (index == 0 || frames.Count < index) return 0;


            if (frames[index - 1].IsSpare && frames.Count > index)
            {
                return frames[index - 1].Score + frames[index].FirstScore;
            }

            if (frames[index - 1].IsStrike && frames.Count > index)
            {
                if(frames[index].IsStrike && frames.Count > index + 1)
                {
                    return frames[index - 1].Score + frames[index].Score + frames[index+1].Score;
                }
                return frames[index - 1].Score + frames[index].Score;
            }
            return frames[index - 1].Score;
        }
    }
}