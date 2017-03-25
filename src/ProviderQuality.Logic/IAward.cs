namespace ProviderQuality.Logic
{
    public interface IAward
    {
        string Name { get; }

        int ExpiresIn { get; set; }

        int Quality { get; set; }

        void UpdateQuality();
    }
}
