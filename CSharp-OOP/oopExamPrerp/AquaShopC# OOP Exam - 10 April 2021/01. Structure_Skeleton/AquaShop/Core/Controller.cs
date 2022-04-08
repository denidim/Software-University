using System;
using System.Linq;
using System.Collections.Generic;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using AquaShop.Models.Fish;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private List<IAquarium> aquariums;

        private DecorationRepository decorations;

        public Controller()
        {
            aquariums = new List<IAquarium>();

            decorations = new DecorationRepository();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if(aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if(decorationType== "Plant")
            {
                decorations.Add(new Plant());
            }
            else if(decorationType == "Ornament")
            {
                decorations.Add(new Ornament());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var currDec = decorations.FindByType(decorationType);//Models.FirstOrDefault(x=>x.GetType().Name==decorationType);

            if (currDec == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,decorationType));
            }
            decorations.Remove(currDec);

            aquariums.FirstOrDefault(x => x.Name == aquariumName).AddDecoration(currDec);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType,aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aq = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            string message = "";

            if (fishType == "FreshwaterFish")
            {
                if(aq.GetType().Name== "FreshwaterAquarium")
                {
                    aquariums.FirstOrDefault(x => x.Name == aquariumName).AddFish(new FreshwaterFish(fishName,fishSpecies,price));
                    
                    message = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else
                {
                    message = string.Format(OutputMessages.UnsuitableWater);
                }
            }
            else if(fishType== "SaltwaterFish")
            {
                if (aq.GetType().Name == "SaltwaterAquarium")
                {
                    aquariums.FirstOrDefault(x => x.Name == aquariumName).AddFish(new FreshwaterFish(fishName, fishSpecies, price));

                    message = message = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else
                {
                    message = string.Format(OutputMessages.UnsuitableWater);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            return message;
        }

        public string FeedFish(string aquariumName)
        {
            var currAq = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            currAq.Feed();

            return string.Format(OutputMessages.FishFed,currAq.Fish.Count());
        }

        public string CalculateValue(string aquariumName)
        {
            var currAq = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var fishSum = currAq.Fish.Sum(x => x.Price);

            var decorationSum = currAq.Decorations.Sum(x => x.Price);

            var value = fishSum + decorationSum;
            
            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string Report()
        { 
            StringBuilder sb = new StringBuilder();

            foreach (var aq in aquariums)
            {
                sb.Append(aq.GetInfo()+Environment.NewLine).ToString().TrimEnd();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
