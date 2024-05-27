using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public TMP_Text scoreTableText;
    public static string gameResultMessage;

    private int currentScore = 0;
    private int highScore = 0;
    private int totalEnemies;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreUI();
        UpdateScoreTableUI();
        
        totalEnemies = 12;
    }
    
    public void AddPoints(int points)
    {
        currentScore += points;
        UpdateScoreUI();
        
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreUI();
        }
    }

    public void EnemyDestroyed()
    {
        totalEnemies--;

        if (totalEnemies <= 0)
        {
            WinGame();
        }
    }

    public void PlayerDestroyed()
    {
        LoseGame();
    }

    private void WinGame()
    {
        gameResultMessage = "CONGRATS!\n\nCREDITS\n\nDESIGN: JUNCHEN";
        SceneManager.LoadScene("Credits");
    }

    private void LoseGame()
    {
        gameResultMessage = "GAME OVER!\n\nCREDITS\n\nDESIGN: JUNCHEN";
        SceneManager.LoadScene("Credits");
    }
    
    void UpdateScoreUI()
    {
        scoreText.text = "SCORE\n" + currentScore.ToString("D4");
    }
    
    void UpdateHighScoreUI()
    {
        highScoreText.text = "HIGHSCORE\n" + highScore.ToString("D4");
    }
    
    void UpdateScoreTableUI()
    {
        scoreTableText.text = "*SCORE TABLE*\n" +
                              " ?   : 40 PTS\n\n" +
                              "      : 30 PTS\n\n" +
                              "      : 20 PTS\n\n" +
                              "      : 10 PTS";
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreUI();
    }
}
