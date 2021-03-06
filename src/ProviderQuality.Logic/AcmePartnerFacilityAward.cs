﻿namespace ProviderQuality.Logic
{
    internal class AcmePartnerFacilityAward : IAward
    {
        private int _decrementAmount = 0;

        public int ExpiresIn { get; set; }

        public string Name
        {
            get { return Constants.AcmePartnerFacilityName; }
        }

        public int Quality { get; set; }

        public void UpdateQuality()
        {
            if (ExpiresIn <= 0)
                _decrementAmount += Constants.QualityDegradeValue * 2;
            else
                _decrementAmount += Constants.QualityDegradeValue;

            if (Quality - _decrementAmount >= Constants.MinQuality)
                Quality -= _decrementAmount;
            else
                Quality = Constants.MinQuality;

            ExpiresIn -= Constants.ExpireDegradeValue;
        }
    }
}
