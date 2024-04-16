using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    public GameObject sceneStart;
    void Start()
    {
        sceneStart.SetActive(true);
        Debug.Log("TESTE");
    }
}
