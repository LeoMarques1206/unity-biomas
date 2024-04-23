using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public string scene;
    public CanvasGroup canvasGroup;
    public AudioSource src;
    public AudioClip sfx;
    public GameObject background;

    public AudioSource src2;
    public AudioClip bird;

    void Start()
    {
        SetCanvasGroupOpacity(0f); // Define a opacidade inicial como 0
        Invoke("ShowText", 1.5f); // Chama o método ShowText após 1.5 segundos
    }

    void ShowText()
    {
        SetCanvasGroupOpacity(1f); // Define a opacidade como 100% (1)
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
        
    void SetCanvasGroupOpacity(float opacity)
    {
        canvasGroup.alpha = opacity; // Define a opacidade do canvas
    }
}
