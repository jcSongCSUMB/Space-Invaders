using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Text titleText;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
    }
}
