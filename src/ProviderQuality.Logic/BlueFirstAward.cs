namespace ProviderQuality.Logic
{
    internal class BlueFirstAward : IAward
    {
        private const int BlueFirsteUpgradeValue = 1;

        private int _incrementAmount = 0;

        public int ExpiresIn { get; set; }

        public string Name
        {
            get { return Constants.BlueFirstName; }
        }

        public int Quality { get; set; }

        public void UpdateQuality()
        {
            if (ExpiresIn <= 0)
                _incrementAmount += BlueFirsteUpgradeValue * 2;
            else
                _incrementAmount += BlueFirsteUpgradeValue;

            if (Quality + _incrementAmount <= Constants.MaxQuality)
                Quality += _incrementAmount;
            else
                Quality = Constants.MaxQuality;

            ExpiresIn -= Constants.ExpireDegradeValue;
        }
    }
}
