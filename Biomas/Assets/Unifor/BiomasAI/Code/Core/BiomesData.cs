using System.Collections.Generic;
using System.Linq;


namespace Unifor.Biomas
{
    [System.Serializable]
    public record BiomesData
    {
        public List<Biome> Biomes;

        public IEnumerable<string> BiomeNames 
            => Biomes.Select(biome => biome.Name);

        public IDictionary<string, string> ToDictionary()
        {
            var dict = new Dictionary<string, string>();
            foreach (var biome in Biomes)
                foreach (var item in biome.ToDictionary())
                {
                    dict.TryAdd(item.Key, item.Value);
                }

            return dict;
        }
    }

    [System.Serializable]
    public record Biome
    {
        public string Name;
        public string Description;
        public List<Specimen> Wildlife;

        public IEnumerable<string> WildlifeNames
            => Wildlife.Select(wildlife => wildlife.Name);

        public Biome(string name, string description, List<Specimen> wildlife = null)
        {
            Name = name;
            Description = description;
            Wildlife = wildlife ?? new List<Specimen>();
        }

        public IDictionary<string, string> ToDictionary()
        {
            var dict = new Dictionary<string, string>() { { Name, Description } };
            foreach (var wildlife in Wildlife)
            {
                dict.TryAdd(wildlife.Name, wildlife.Description);
            }
            return dict;
        }
    }

    [System.Serializable]
    public record Specimen
    {
        public string Name;
        public string Description;

        public Specimen(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
