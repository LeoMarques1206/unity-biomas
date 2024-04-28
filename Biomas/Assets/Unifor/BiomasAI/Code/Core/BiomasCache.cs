using System.Collections.Generic;
using System.Linq;


namespace Unifor.Biomas
{
    public class BiomasCache
    {
        private IDictionary<string, string> _descriptions;
        private IDictionary<string, ICollection<string>> _biomesWildlife;

        public string FailedReason { get; private set; }

        public BiomasCache(BiomesData predefined)
        {
            _descriptions = predefined.ToDictionary();
            _biomesWildlife = new Dictionary<string, ICollection<string>>();
            foreach (var biome in predefined.Biomes)
            {
                _biomesWildlife.Add(biome.Name, biome.WildlifeNames.ToHashSet());
            }
        }

        public BiomesData Reconstruct()
        {
            var data = new BiomesData();
            data.Biomes = new List<Biome>();
            
            foreach (var biomeData in _biomesWildlife)
            {
                var biomeName = biomeData.Key;
                var biomeDescription = _descriptions[biomeName];
                
                var wildlife = new List<Specimen>();
                foreach (var specimen in biomeData.Value)
                {
                    var specimenDescription = _descriptions[specimen];
                    wildlife.Add(new Specimen(specimen, specimenDescription));
                }
                var biome = new Biome(biomeName, biomeDescription, wildlife);
                data.Biomes.Add(biome);
            }

            return data;
        }

        public string DescriptionOf(string name) =>
            _descriptions.ContainsKey(name) ? _descriptions[name] : null;

        public IEnumerable<string> WildlifeIn(string biome) =>
            _biomesWildlife.ContainsKey(biome) ? _biomesWildlife[biome] : null;

        public CacheOperationResult AddOrUpdateBiome(string biome, string description)
        {
            if (_descriptions.ContainsKey(biome))
            {
                _descriptions[biome] = description;
                return CacheOperationResult.ElementUpdated;
            }
            
            _descriptions.Add(biome, description);
            _biomesWildlife.Add(biome, new HashSet<string>());
            
            return CacheOperationResult.ElementAdded;
        }
        
        public CacheOperationResult AddOrUpdateWildlife(string biome, string wildlife, string description)
        {
            if (!_biomesWildlife.ContainsKey(biome))
            {
                FailedReason = $"The biome {biome} doesn't exist in the cache.";
                return CacheOperationResult.OperationFailed;
            }
            _biomesWildlife[biome].Add(wildlife);

            if (_descriptions.ContainsKey(wildlife))
            {
                _descriptions[wildlife] = description;
                return CacheOperationResult.ElementUpdated;
            }

            _descriptions.Add(wildlife, description);
            return CacheOperationResult.ElementAdded;
        }

        public enum CacheOperationResult 
        { 
            OperationFailed = 0,
            ElementAdded, ElementUpdated
        }
    }
}
