

namespace Bowling
{
    public class BowlingGame
    {
        Frames _frames = new();
        public int Score => _frames.GetTotalScore();

        public void Bowl(int pin)
        {
            _frames.Bowl(pin);
        }

        public int GetFrameScore(int index)
        {
            return _frames.GetFrameScore(index);
        }

    }
}
