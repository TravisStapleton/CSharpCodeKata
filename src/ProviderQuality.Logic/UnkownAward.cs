namespace ProviderQuality.Logic
{
    internal class UnknownAward : IAward
    {
        public int ExpiresIn { get; set; }

        public string Name
        {
            get { return "Unknown Award"; }
        }

        public int Quality { get; set; }

        public void UpdateQuality()
        {
            // Unknown award type, no updates.
        }
    }
}
