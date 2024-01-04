
using System.Net.NetworkInformation;

namespace Bowling
{
    internal class Frame
    {
        List<int> _pins = new();
        public bool IsFull => (_pins.Count == 2 || _pins.Sum() == 10);

        public int Score => _pins.Sum();

        public bool IsSpare => _pins.Count == 2 && _pins.Sum() == 10;
        public bool IsStrike => _pins.Count == 1 && _pins.Sum() == 10;
        public int FirstScore => _pins.Count != 0 ? _pins[0] : 0;

        internal void Bowl(int pin)
        {
            _pins.Add(pin);
        }
    }
}