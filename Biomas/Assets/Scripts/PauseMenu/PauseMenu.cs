using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private CanvasGroup canvasGroup;
    private bool isPaused = false;

    void Start()
    {
        // Obtém o componente CanvasGroup do objeto de pausa
        canvasGroup = pauseMenuUI.GetComponent<CanvasGroup>();
        
        // Inicialmente, o menu de pausa está invisível e não interativo
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        Time.timeScale = 1f; 
        isPaused = false;
    }

    void Pause()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        Time.timeScale = 0f; 
        isPaused = true;
    }
}