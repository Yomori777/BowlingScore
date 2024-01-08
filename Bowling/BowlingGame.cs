namespace Bowling
{
    public class BowlingGame
    {
        Frames _frames = new();
        public int Score => _frames.GetTotalScore();

        public int FrameNumber => _frames.FrameNumber;

        public bool IsEnd => _frames.IsEnd;

        public void Bowl(int pin)
        {
            _frames.Bowl(pin);
        }

        public int GetFrameScore(int index)
        {
            return _frames.GetFrameScore(index);
        }

        public bool IsSpare(int frameNumber)
        {
            return _frames.IsSpare(frameNumber);
        }

        public bool IsStrike(int frameNumber)
        {
            return _frames.IsStrike(frameNumber);
        }
    }
}
