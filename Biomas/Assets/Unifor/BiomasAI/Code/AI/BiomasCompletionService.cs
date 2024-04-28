using JonasLuz.Nuvia.OpenAI;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Unifor.Biomas.AI.Services
{
    public class BiomasCompletionService : CompletionService
    {
        public BiomasCompletionService(string apiKey, string model = "gpt-3.5-turbo") : base(apiKey, model) { }

        public override Task<string> GenerateCompletion(string systemPrompt, IEnumerable<string> userPrompts)
        {
            return base.GenerateCompletion(systemPrompt, userPrompts);
        }
    }
}
