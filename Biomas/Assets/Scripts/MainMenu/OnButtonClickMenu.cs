using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveCameraOnButtonClick : MonoBehaviour
{
    public string buttonName;
    public GameObject pata1, pata2, pata3;
    //jogar
    //creditos
    //opcoes

    public CanvasGroup mainMenu;
    public CanvasGroup cena;

    public CanvasGroup cenaDicas;
    public GameObject cat;

    public float moveSpeed = 1.5f;
    private bool apertou = false;
    void Start()
    {
        Time.timeScale = 1f; 
        Button button = GetComponent<Button>();
        button.onClick.AddListener(FazAlgo);
    }

    public void IniciaJogo()
    {
        Debug.Log("IniciaJogo"); //Mudar de cena
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("StartLore");
    }

    public void creditos()
    {
        mainMenu.alpha = 0f;
        mainMenu.interactable = false;
        cena.alpha = 1f;
        apertou = false;
        TranslateObjectDown(pata2, 3.7f);
        cat.SetActive(false);
    }

    public void dicas()
    {
        mainMenu.alpha = 0f;
        mainMenu.interactable = false;
        cenaDicas.alpha = 1f;
        apertou = false;
        TranslateObjectDown(pata3, 3.7f);
        cat.SetActive(false);
    }

    public void ApertaCreditos()
    {
        TranslateObjectUp(pata2, 3.7f);
        Invoke("creditos", 0.3f);
        apertou = true;
    }

    public void ApertaJogar()
    {
        TranslateObjectUp(pata1, 3.7f);
        Invoke("IniciaJogo", 0.5f);
        apertou = true;
    }

    void FazAlgo()
    {
        if(buttonName == "jogar" && apertou == false)
        {
            TranslateObjectUp(pata1, 3.7f);
            Invoke("IniciaJogo", 0.5f);
            apertou = true;

        } else if (buttonName == "creditos" && apertou == false)
        {
            TranslateObjectUp(pata2, 3.7f);
            Invoke("creditos", 0.3f);
            apertou = true;
        } else if (buttonName == "dicas" && apertou == false)
        {
            TranslateObjectUp(pata3, 3.7f);   
            Invoke("dicas", 1);
            apertou = true;
        }
    }

    

    public void TranslateObjectUp(GameObject objToTranslate, float distance)
    {
        // Calcula a posição final desejada
        Vector3 targetPosition = objToTranslate.transform.position + new Vector3(0f, distance, 0f);

        // Aplica a interpolação suave para mover o objeto
        StartCoroutine(MoveObjectCoroutine(objToTranslate.transform, targetPosition));
    }
    
    public void TranslateObjectDown(GameObject objToTranslate, float distance)
    {
        // Calcula a posição final desejada (para baixo)
        Vector3 targetPosition = objToTranslate.transform.position - new Vector3(0f, distance, 0f);

        // Inicia a rotina para mover o objeto suavemente
        StartCoroutine(MoveObjectCoroutine(objToTranslate.transform, targetPosition));
    }

    private IEnumerator MoveObjectCoroutine(Transform objTransform, Vector3 targetPosition)
    {
        float elapsedTime = 0f;

        // Interpolação suave enquanto não alcança a posição desejada
        while (elapsedTime < moveSpeed)
        {
            objTransform.position = Vector3.Lerp(objTransform.position, targetPosition, (elapsedTime / moveSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Garante que o objeto alcance exatamente a posição final
        objTransform.position = targetPosition;
    }
}
