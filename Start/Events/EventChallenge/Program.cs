// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// Example file for Event Challenge

namespace EventsChallenge
{
    class BalanceChangeEventArgs : EventArgs
    {
        public required decimal Old { get; set; }
        public required decimal New { get; set; }

    }
    class PiggyBank
    {
        private decimal _BalanceAmount;

        public event EventHandler<BalanceChangeEventArgs>? BalanceChangeEvent;

        public decimal TheBalance
        {
            set
            {
                if (BalanceChangeEvent is not null)
                    BalanceChangeEvent(this, new BalanceChangeEventArgs() { Old = _BalanceAmount, New = value });
                _BalanceAmount = value;
            }
            get
            {
                return _BalanceAmount;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            decimal[] testValues = { 250, 1000, -750, 100, -200 };

            PiggyBank pb = new PiggyBank();
            pb.BalanceChangeEvent += delegate (object sender, BalanceChangeEventArgs e)
            {
                Console.WriteLine($"Balance changed from {e.Old} to {e.New}");
            };

            foreach (decimal testValue in testValues)
            {
                pb.TheBalance += testValue;
            }
            Console.WriteLine($"Final value is {pb.TheBalance}");
        }
    }
}
