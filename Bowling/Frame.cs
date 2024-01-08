namespace Bowling
{
    internal class Frame
    {
        List<int> _pins = new();

        internal int Score => _pins.Sum();

        internal bool IsFull => _pins.Count == 2 || _pins.Sum() == 10;
        internal bool IsSpare => _pins.Count == 2 && _pins.Sum() == 10;
        internal bool IsStrike => _pins.Count == 1 && _pins.Sum() == 10;
        internal int FirstScore => _pins.Count != 0 ? _pins[0] : 0;
        internal bool IsBowl => _pins.Count != 0;

        internal void Bowl(int pin)
        {
            _pins.Add(pin);
        }
    }
}