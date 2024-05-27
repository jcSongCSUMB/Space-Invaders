using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class CreditSceneLogic : MonoBehaviour
{
    public float waitTime = 5f;
    public Text creditText;

    void Start()
    {
        creditText.text = GameManager.gameResultMessage;
        StartCoroutine(SwitchToStartScene());
    }

    IEnumerator SwitchToStartScene()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(waitTime);

        // Switch to the start scene
        SceneManager.LoadScene("Start Screen");
    }
}


