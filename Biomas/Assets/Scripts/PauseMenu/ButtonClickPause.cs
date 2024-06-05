using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickPause : MonoBehaviour
{
    private string sceneName = "Menu";

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}