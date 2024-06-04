using System;
using System.Collections;
using Unifor.Biomas.AI.Services;
using Unifor.BiomasAI.AI;
using UnityEngine;


namespace Unifor.Biomas.AI
{
    public class BiomasAIManager : MonoBehaviour
    {
        private const string GPT_SYSTEM = @"
Voc� � um especilista em geografia e biologia brasileiras. 
Especificamente, voc� conhece os biomas brasileiros, sua fauna e flora.
";
        private const string USER_PROMPT = "Descreva, em um a dois par�grafos, #";

        [Header("GPT Setup")]
        [SerializeField]
        [Tooltip("If selected, the AI will ask GPT about the biome or wildlife at runtime and save it response in cache. Be aware of the remote GPT call delay.")]
        private bool _useGptAtRuntime = false;

        [SerializeField]
        private string _gptApiKeyResource = "GPT_API_PATH";
        private string _gptApiKey;

        [Header("Cache Setup")]
        [SerializeField]
        private string _predefinedDataResource;

        private BiomasCache _cache;
        private BiomasCompletionService _completionService;

        private void Awake()
        {
            // Load the GPT API key and create Completion service instance.
            _gptApiKey = BiomasResources.LoadTextResource(_gptApiKeyResource);
            _completionService = new BiomasCompletionService(_gptApiKey, "gpt-4");

            // Load the predefined BiomasCache.
            var data = BiomasResources.LoadDataResource(_predefinedDataResource);
            Debug.Log(_predefinedDataResource.ToString());
            _cache = new BiomasCache(data);
        }

        private void OnDestroy()
        {
            // Update the predefined cache resource.
            var data = _cache.Reconstruct();
            BiomasResources.SaveDataResource(_predefinedDataResource, data);
        }

        private IEnumerator _QueryGPTCoroutine(string name, GptCallback callback, string biome = null)
        {
            var prompt = new string[] { USER_PROMPT.Replace("#", name) };
            Debug.Log($"Ativando GPT com prompt {prompt[0]}");

            var gptQuery = _completionService.GenerateCompletion(GPT_SYSTEM, prompt);
            yield return new WaitUntil(() => gptQuery.IsCompleted);

            var result = gptQuery.Result;
            var response = new OpenAIResponse(result);
            var description = response.root.choices[0].message.content;

            if (biome != null) _cache.AddOrUpdateWildlife(biome, name, description);
            else _cache.AddOrUpdateBiome(name, description);

            callback(description);
        }

        public delegate void GptCallback(string description);

        /// <summary>
        /// Describe the biome given.
        /// </summary>
        /// <param name="biome">The biome.</param>
        /// <param name="callback">The function to be called with the biome description.</param>
        public void DescribeBiome(string biome, GptCallback callback)
        {
            var description = _cache.DescriptionOf(biome);
            if (description == null && _useGptAtRuntime)
                StartCoroutine(_QueryGPTCoroutine(biome, callback));
            else callback(description);
        }

        /// <summary>
        /// Describe the wildlife.
        /// </summary>
        /// <param name="biome">the biome of the wildlife.</param>
        /// <param name="wildlife">wildlife name</param>
        /// <param name="callback">function to be called with the wildlife description.</param>
        public void DescribeWildlife(string biome, string wildlife, GptCallback callback)
        {
            var description = _cache.DescriptionOf(wildlife);
            if (description == null && _useGptAtRuntime)
                StartCoroutine(_QueryGPTCoroutine(wildlife, callback, biome));
            else callback(description);
        }
    }
}