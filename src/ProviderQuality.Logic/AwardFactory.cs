namespace ProviderQuality.Logic
{
    public sealed class AwardFactory
    {
        static AwardFactory()
        {
        }

        private AwardFactory()
        {
        }

        public static AwardFactory Instance { get; } = new AwardFactory();

        public IAward CreateAward(string awardName)
        {
            switch (awardName)
            {
                case Constants.AcmePartnerFacilityName:
                    return new AcmePartnerFacilityAward();
                case Constants.BlueCompareName:
                    return new BlueCompareAward();
                case Constants.BlueDistinctPlusName:
                    return new BlueDistinctionPlusAward();
                case Constants.BlueFirstName:
                    return new BlueFirstAward();
                case Constants.BlueStarName:
                    return new BlueStarAward();
                case Constants.GovQualityPlusName:
                    return new GovQualityPlusAward();
                case Constants.TopConnectedProvidersName:
                    return new TopConnectedProvidersAward();
                default:
                    return new UnknownAward();
            }
        }

    }
}
