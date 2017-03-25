namespace ProviderQuality.Logic
{
    internal class BlueCompareAward : IAward
    {
        private const int AddTwoThreshold = 10;
        private const int AddThreeThreshold = 5;
        private const int BlueCompareUpgradeValue = 1;
        private int _incrementAmount = 0;

        public int ExpiresIn { get; set; }

        public string Name
        {
            get { return Constants.BlueCompareName; }
        }

        public int Quality { get; set; }

        public void UpdateQuality()
        {
            if (ExpiresIn <= 0)
            {
                Quality = 0;
                ExpiresIn -= Constants.ExpireDegradeValue;
                return;
            }

            if (ExpiresIn <= AddThreeThreshold)
                _incrementAmount += BlueCompareUpgradeValue * 3;
            else if (ExpiresIn <= AddTwoThreshold)
                _incrementAmount += BlueCompareUpgradeValue * 2;
            else
                _incrementAmount += BlueCompareUpgradeValue;

            if (Quality + _incrementAmount >= Constants.MaxQuality)
                Quality = Constants.MaxQuality;
            else
                Quality += _incrementAmount;

            ExpiresIn -= Constants.ExpireDegradeValue;
        }
    }
}
