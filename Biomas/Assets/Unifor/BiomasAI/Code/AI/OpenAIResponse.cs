using System;
using UnityEngine;


namespace Unifor.BiomasAI.AI
{
    [Serializable]
    public class OpenAIResponse
    {
        private string _source;
        
        public readonly Root root;

        public OpenAIResponse(string json)
        {
            _source = json.Replace("\"object\"", "\"service\"");
            root = JsonUtility.FromJson<Root>(_source);
        }

        [System.Serializable]
        public record Message
        {
            public string role;
            public string content;
        }

        [System.Serializable]
        public record Choice
        {
            public int index;
            public Message message;
            public string finish_reason;
        }

        [System.Serializable]
        public record Usage
        {
            public int prompt_tokens;
            public int completion_tokens;
            public int total_tokens;
        }

        [System.Serializable]
        public record Root
        {
            public string id;
            public string service;
            public long created;
            public string model;
            public Choice[] choices;
            public Usage usage;
        }
    }
}
