using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI finalScoreText;
    
    void Start()
    {
        int finalScore = GameManager.Instance.GetScore();
        finalScoreText.text = "Final Score: " + finalScore;
    }
    
    public void OnSubmitScore()
    {
        string playerName = playerNameInput.text;
        
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Anonymous";
        }
        
        int finalScore = GameManager.Instance.GetScore();
        float completionTime = Time.timeSinceLevelLoad;
        
        DatabaseManager.Instance.SaveHighScore(playerName, finalScore, completionTime);
        
        SceneManager.LoadScene("HighScores");
    }
}