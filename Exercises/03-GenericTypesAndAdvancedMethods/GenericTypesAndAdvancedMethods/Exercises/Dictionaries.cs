using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypesAndAdvancedMethods.Exercises
{
    public static class ExerciseDictionary
    {
        public static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
        {
            
            Dictionary<PetType, double> maximumWeightByPetType = new Dictionary<PetType, double>();
            double maximumWeight = default;

            foreach (Pet pet in pets)
            {
                if(!maximumWeightByPetType.ContainsKey(pet.PetType))
                {
                    maximumWeightByPetType.Add(pet.PetType, pet.Weight);
                    maximumWeight = pet.Weight;
                    
                }
                else if (maximumWeightByPetType[pet.PetType] > maximumWeight)
                {
                    maximumWeightByPetType[pet.PetType] = pet.Weight;
                    maximumWeight = pet.Weight;
                }
            }

            return maximumWeightByPetType;
        }
    }

    public class Pet
    {
        public PetType PetType { get; }
        public double Weight { get; }

        public Pet(PetType petType, double weight)
        {
            PetType = petType;
            Weight = weight;
        }

        public override string ToString() => $"{PetType}, {Weight} kilos";
    }

    public enum PetType { Dog, Cat, Fish }
}
