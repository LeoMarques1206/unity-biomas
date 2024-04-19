using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public string scene;
    public TextMeshProUGUI textComponent;
    public AudioSource src;
    public AudioClip sfx;
    public GameObject background;

    public AudioSource src2;
    public AudioClip bird;

    void Start()
    {
        SetTextOpacity(0f); // Define a opacidade inicial como 0
        Invoke("ShowText", 1.5f); // Chama o método ShowText após 1.5 segundos
    }

    void ShowText()
    {
        SetTextOpacity(1f); // Define a opacidade como 100% (1)
        background.SetActive(true);
        if (src != null && sfx != null)
        {
            src.clip = sfx;
            src.Play();
            Invoke("BirdSing", 0.3f);
            
        }
    }

    void BirdSing()
    {
        src2.clip = bird;
        src2.Play();
        Invoke("SceneExit", 3f);
    }

    void SceneExit()
    {
        SceneManager.LoadScene(scene);
    }
        
    void SetTextOpacity(float opacity)
    {
        Color textColor = textComponent.color;
        textColor.a = opacity; // Define a opacidade da cor do texto
        textComponent.color = textColor; // Aplica a nova cor ao texto
    }
}
