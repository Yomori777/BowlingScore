
using System;
using System.Collections;
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
            if (!_frames[9].IsStrike && !_frames[9].IsSpare) return true;
            if (_frames.Count >= 11 && _frames[9].IsSpare && _frames[10].IsBowl) return true;
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
            return Enumerable.Range(0, _frames.Count >= 10 ? 10 : _frames.Count).Sum(x => GetFrameScore(x));
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
            if (!IsRangeFrames(frameNumber)) return false;
            return _frames[frameNumber].IsSpare;
        }

        internal bool IsStrike(int frameNumber)
        {
            if (!IsRangeFrames(frameNumber)) return false;
            return _frames[frameNumber].IsStrike;
        }
        private bool IsRangeFrames(int frameNumber)
        {
            if (_frames.Count == 0) return false;
            if (_frames.Count <= frameNumber) return false;
            return true;
        }
    }
}