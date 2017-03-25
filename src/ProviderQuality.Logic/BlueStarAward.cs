namespace ProviderQuality.Logic
{
    internal class BlueStarAward : IAward
    {
        const int degradeScale = 2;

        private int _decrementAmount = 0;

        public int ExpiresIn { get; set; }
        
        public string Name
        {
            get { return Constants.BlueStarName; }
        }

        public int Quality { get; set; }

        public void UpdateQuality()
        {
            if (ExpiresIn <= 0)
                _decrementAmount += (Constants.QualityDegradeValue * degradeScale) * 2;
            else
                _decrementAmount += (Constants.QualityDegradeValue * degradeScale);

            if (Quality - _decrementAmount >= Constants.MinQuality)
                Quality -= _decrementAmount;
            else
                Quality = Constants.MinQuality;

            ExpiresIn -= Constants.ExpireDegradeValue;
        }
    }
}
