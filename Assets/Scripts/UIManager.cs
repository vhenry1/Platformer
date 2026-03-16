using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onScoreChanged += UpdateScore;
            GameManager.Instance.onHealthChanged += UpdateHealth;
            GameManager.Instance.onGameOver += HandleGameOver;
        }
    }

    void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onScoreChanged -= UpdateScore;
            GameManager.Instance.onHealthChanged -= UpdateHealth;
            GameManager.Instance.onGameOver -= HandleGameOver;
        }
    }

    void UpdateScore(int newScore)
    {
        Debug.Log("Score event fired. New Score: " + newScore);
        scoreText.text = "Score: " + newScore;
    }

    void UpdateHealth(int newHealth)
    {
        Debug.Log("Health event fired. New health: " + newHealth);
        healthText.text = "Health: " + newHealth;
    }

    void HandleGameOver()
    {
        Debug.Log("Game Over event fired.");
        SceneManager.LoadScene("GameOver");
    }
}