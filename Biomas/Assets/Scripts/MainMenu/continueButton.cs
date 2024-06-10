using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class continueButton : MonoBehaviour
{
    public GameObject button;
    public GameObject player;
    private PlayerMovement playerMovement;
    void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }
    void Start()
    {
        if(playerMovement.hasViolet == false)
        {
            button.SetActive(true);
        } else
        {
            button.SetActive(false);
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene("Lobby");
    }
}
