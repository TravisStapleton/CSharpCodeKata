namespace ProviderQuality.Logic
{
    internal class BlueDistinctionPlusAward : IAward
    {
        public int ExpiresIn { get; set; }

        public string Name
        {
            get { return Constants.BlueDistinctPlusName; }
        }

        public int Quality { get; set; }

        public void UpdateQuality()
        {
            
        }
    }
}
