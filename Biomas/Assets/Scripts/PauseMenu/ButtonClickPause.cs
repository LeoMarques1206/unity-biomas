using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickPause : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }
}