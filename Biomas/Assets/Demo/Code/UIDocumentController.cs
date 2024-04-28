using UnityEngine;
using UnityEngine.UIElements;


namespace Unifor.Biomas.AI.Demo
{
    public class UIDocumentController : MonoBehaviour
    {
        [SerializeField]
        private BiomasAIManager _manager;

        private UIDocument _uiDocument;
        private Label _description;

        void Start()
        {
            _uiDocument = GetComponent<UIDocument>();
            var visualTree = _uiDocument.rootVisualElement;

            var biomeInput = visualTree.Q<TextField>("BiomeName");
            var wildlifeInput = visualTree.Q<TextField>("WildlifeName");

            var buttonBiome = visualTree.Q<Button>("ButtonBiome");
            var buttonWildlife = visualTree.Q<Button>("ButtonWildlife");
            
            _description = visualTree.Q<Label>("Description");

            buttonBiome.clicked += 
                () => OnBiomeButtonClicked(biomeInput.text);
            buttonWildlife.clicked += 
                () => OnWildlifeButtonClicked(biomeInput.text, wildlifeInput.text);
        }

        void OnBiomeButtonClicked(string biome)
        {
            if (biome == string.Empty)
            {
                _description.text = "ERRO - O nome do bioma deve ser informado.";
                return;
            }
            _manager.DescribeBiome(biome, FillDescription);
        }

        void OnWildlifeButtonClicked(string biome, string wildlife)
        {
            if (biome == string.Empty || wildlife == string.Empty)
            {
                _description.text = "ERRO - O nome do bioma E da espécie devem ser informados.";
                return;
            }
            _manager.DescribeWildlife(biome, wildlife, FillDescription);
        }

        void FillDescription(string description)
        {
            _description.text = description;
        }
    }
}