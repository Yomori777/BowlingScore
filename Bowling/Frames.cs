
using System.Net.NetworkInformation;

namespace Bowling
{
    internal class Frames
    {
        List<Frame> _frames = new();

        public int FrameNumber => GetFrameNumber();

        public bool IsEnd => GetGameEnd();

        private bool GetGameEnd()
        {
            if (_frames.Count >= 12) return true;
            if (0 <= _frames.Count && _frames.Count < 10) return false;
            if (!_frames[9].IsStrike && !_frames[9].IsSpare) return false;
            if (_frames.Count >= 11 && !_frames[10].IsStrike) return true;
            return false;
        }

        private int GetFrameNumber()
        {
            if (_frames.Count == 0) return 0;
            if (_frames.Last().IsFull ) return _frames.Count;
            return _frames.Count - 1;
        }

        internal void Bowl(int pin)
        {
            var frame = GetNowFrame();
            frame.Bowl(pin);
        }

        internal int GetTotalScore()
        {
            var score = 0;
            foreach (var index in Enumerable.Range(0, _frames.Count >= 10 ? 10 : _frames.Count))
            {
                score += GetFrameScore(index);
            }
            return score;
        }

        public int GetFrameScore(int index)
        {
            if (index >= _frames.Count) return 0;
            return BowlingCalculator.Calculate(_frames, index);
        }

        private Frame GetNowFrame()
        {
            if (_frames.Count == 0 || _frames.Last().IsFull)
            {
                _frames.Add(new Frame());
            }
            return _frames.Last();
        }

        internal bool IsSpare(int frameNumber)
        {
            if (!IsRangeFrame(frameNumber)) return false;
            return _frames[frameNumber].IsSpare;
        }

        internal bool IsStrike(int frameNumber)
        {
            if (!IsRangeFrame(frameNumber)) return false;
            return _frames[frameNumber].IsStrike;
        }

        private bool IsRangeFrame(int frameNumber)
        {
            if (_frames.Count == 0) return false;
            if (_frames.Count <= frameNumber) return false;
            return true;    
        }
    }

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
                    return frames[index].Score + frames[index+1].Score + frames[index+2].Score;
                }
                return frames[index].Score + frames[index+1].Score;
            }
            return frames[index].Score;
        }
    }
}