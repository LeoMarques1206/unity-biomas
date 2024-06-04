using System;
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

        /// <summary>
        /// Load a text resource.
        /// </summary>
        /// <param name="resourcePath">The path of the resource.</param>
        /// <returns>String content of the resource.</returns>
        public static string LoadTextResource(string resourcePath)
        {
            var resource = _LoadResource(resourcePath) as TextAsset;
            return resource ? resource.text : string.Empty;
        }

        /// <summary>
        /// Load a BiomesData resource.
        /// </summary>
        /// <param name="resourcePath">The resource path</param>
        /// <returns>BiomesData structure of the resource content.</returns>
        public static BiomesData LoadDataResource(string resourcePath)
        {
            string json;
            var path = $"{Application.dataPath}/{resourcePath}";
            if (File.Exists(path))
                try
                {
                    json = File.ReadAllText(path);
                    Debug.Log(json);
                }
                catch (Exception)
                {
                    Debug.LogWarning($"File {path} exists, but could not be read.");
                    return null;
                }
            else
            {
                var resource = _LoadResource(resourcePath) as TextAsset;
                if (resource == null) return null;

                json = resource.text;
            }

            Debug.Log(json);
            BiomesData data = JsonUtility.FromJson<BiomesData>(json);
            
            return data;
        }

        /// <summary>
        /// Save BiomesData to file for future use.
        /// </summary>
        /// <param name="resourcePath">The resource path.</param>
        /// <param name="data">The data to be saved.</param>
        public static void SaveDataResource(string resourcePath, BiomesData data)
        {
            var json = JsonUtility.ToJson(data);
            var path = $"{Application.dataPath}/{resourcePath}";
            try
            {
                File.WriteAllText(path, json);
            }
            catch (Exception)
            {
                Debug.LogError($"Could not write file {path}");
                throw;
            }
            
        }
    }
}
