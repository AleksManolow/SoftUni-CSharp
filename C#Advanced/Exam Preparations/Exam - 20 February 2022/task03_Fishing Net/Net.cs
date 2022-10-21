using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public string Material { get; set; }
        public int Capacity { get; set; }
        public List<Fish> Fish { get; set; }

        public int Count => this.Fish.Count;
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            this.Fish = new List<Fish>();
        }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Weight <= 0 || fish.Length <= 0)
            {
                return "Invalid fish.";
            }
            if (Count == Capacity)
            {
                return "Fishing net is full.";
            }

            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish fish = this.Fish.SingleOrDefault(x => x.Weight == weight);
            if (fish == null)
            {
                return false;
            }
            this.Fish.Remove(fish);
            return true;
        }

        public Fish GetFish(string fishType)
        {
            return this.Fish.SingleOrDefault(x => x.FishType == fishType);
        }
        public Fish GetBiggestFish()
        {
            return this.Fish.SingleOrDefault(x => x.Weight == this.Fish.Max(x => x.Weight));
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            for (int i = 0; i < Count - 1; i++)
            {
                sb.AppendLine(Fish[i].ToString());
            }
            sb.Append(Fish[Count - 1]).ToString();
            return sb.ToString();
        }

    }
}
