using System.Collections.Generic;
using System.Linq;
using ProviderQuality.Logic;


namespace ProviderQuality.Console
{
    public class Program
    {
        public IList<Award> Awards
        {
            get;
            set;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Updating award metrics...!");

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Gov Quality Plus", SellIn = 10, Quality = 20},
                    new Award {Name = "Blue First", SellIn = 2, Quality = 0},
                    new Award {Name = "ACME Partner Facility", SellIn = 5, Quality = 7},
                    new Award {Name = "Blue Distinction Plus", SellIn = 0, Quality = 80},
                    new Award {Name = "Blue Compare", SellIn = 15, Quality = 20},
                    new Award {Name = "Top Connected Providres", SellIn = 3, Quality = 6},
                    new Award {Name = "Blue Star", SellIn = 5, Quality = 10 },
                }

            };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            // Decided to leave Main application intact and just update the existing values.
            var tempAwardList = Awards;
            var tempFactory = AwardFactory.Instance;

            foreach (var award in tempAwardList)
            {
                var tempAward = tempFactory.CreateAward(award.Name);
                tempAward.Quality = award.Quality;
                tempAward.ExpiresIn = award.SellIn;
                tempAward.UpdateQuality();
                award.Quality = tempAward.Quality;
                award.SellIn = tempAward.ExpiresIn;
            }
        }

        public void UpdateQualityLegacy()
        {
            // LEGACY CODE, leaving for posterity's sake and verification that logic remains unchanged (Code for Blue Star enhancement is inserted but commented out).
            for (var i = 0; i < Awards.Count; i++)
            {
                if (Awards[i].Name != "Blue First" && Awards[i].Name != "Blue Compare")
                {
                    if (Awards[i].Quality > 0)
                    {
                        if (Awards[i].Name != "Blue Distinction Plus")
                        {
                            Awards[i].Quality = Awards[i].Quality - 1;

                            // UPDATE that would have been needed to Legacy code for Blue Star enhancement
                            //if (Awards[i].Name == "Blue Star" && Awards[i].Quality > 0)
                            //    Awards[i].Quality -= 1;
                        }
                    }
                }
                else
                {
                    if (Awards[i].Quality < 50)
                    {
                        Awards[i].Quality = Awards[i].Quality + 1;

                        if (Awards[i].Name == "Blue Compare")
                        {
                            if (Awards[i].SellIn < 11)
                            {
                                if (Awards[i].Quality < 50)
                                {
                                    Awards[i].Quality = Awards[i].Quality + 1;
                                }
                            }

                            if (Awards[i].SellIn < 6)
                            {
                                if (Awards[i].Quality < 50)
                                {
                                    Awards[i].Quality = Awards[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Awards[i].Name != "Blue Distinction Plus")
                {
                    Awards[i].SellIn = Awards[i].SellIn - 1;
                }

                if (Awards[i].SellIn < 0)
                {
                    if (Awards[i].Name != "Blue First")
                    {
                        if (Awards[i].Name != "Blue Compare")
                        {
                            if (Awards[i].Quality > 0)
                            {
                                if (Awards[i].Name != "Blue Distinction Plus")
                                {
                                    Awards[i].Quality = Awards[i].Quality - 1;

                                    // UPDATE that would have been needed to Legacy code for Blue Star enhancement
                                    //if (Awards[i].Name == "Blue Star" && Awards[i].Quality > 0)
                                    //    Awards[i].Quality -= 1;
                                }
                            }
                        }
                        else
                        {
                            Awards[i].Quality = Awards[i].Quality - Awards[i].Quality;
                        }
                    }
                    else
                    {
                        if (Awards[i].Quality < 50)
                        {
                            Awards[i].Quality = Awards[i].Quality + 1;
                        }
                    }
                }
            }

        }

    }

}
