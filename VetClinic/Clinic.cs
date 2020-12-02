using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic()
        {
            this.data = new List<Pet>();
        }

        public Clinic(int capacity)
            :this()
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Pet pet)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.data
                .FirstOrDefault(p => p.Name == name);

            if (pet != null)
            {
                this.data.Remove(pet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.data
                .FirstOrDefault(p => (p.Name == name && p.Owner == owner));

            if (pet != null)
            {
                return pet;
            }
            return null;
        }

        public Pet GetOldestPet()
        {
            Pet oldestPet = this.data
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();

            return oldestPet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"The clinic has the following patients:");

            foreach (var pet in this.data)
            {
                sb
                    .AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
