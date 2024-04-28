using System.IO;
using UnityEngine;
using UnityObject = UnityEngine.Object;


namespace Unifor.Biomas
{
    public static class BiomasResources
    {
        private static UnityObject _LoadResource(string resourcePath)
        {
            var resource = Resources.Load(resourcePath);
            if (resource == null)
            {
                Debug.LogWarning($"Could not load the {resourcePath} resource file. Check if it exists.");
                return null;
            }
            return resource;
        }

        public static string LoadTextResource(string resourcePath)
        {
            var resource = _LoadResource(resourcePath) as TextAsset;
            return resource ? resource.text : string.Empty;
        }

        public static BiomesData LoadDataResource(string resourcePath)
        {
            var resource = _LoadResource(resourcePath) as TextAsset;
            if (resource == null) return null;
            
            BiomesData data = JsonUtility.FromJson<BiomesData>(resource.text);
            return data;
        }

        public static void SaveDataResource(string resourcePath, BiomesData data)
        {
            var json = JsonUtility.ToJson(data);
            File.WriteAllText($"{Application.dataPath}/{resourcePath}", json);
        }
    }
}
