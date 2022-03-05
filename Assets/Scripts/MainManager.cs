using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentRecordText;
    [SerializeField] TextMeshProUGUI finishTimeText;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject gameOverScreen;

    float currentTime = 0f;

    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }

            if (!GameManager.Instance.isGamePaused)
            {
                currentTime += Time.deltaTime;
                UpdateCurrentTime();
            }
        }
    }

    // Update the current time text
    void UpdateCurrentTime()
    {
        currentRecordText.text = $"{GameManager.Instance.CurrentPlayer} - {Mathf.RoundToInt(currentTime)} s";
    }

    // Pause/resume the game
    public void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            GameManager.Instance.isGamePaused = false;
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
        }
        else
        {
            GameManager.Instance.isGamePaused = true;
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
    }

    // Go back to the main menu
    public void GoToMainMenu()
    {
        TogglePause();
        SceneManager.LoadScene(0);
    }

    // Finish the game
    public void GameOver()
    {
        GameManager.Instance.isGameOver = true;
        finishTimeText.text = $"Your Time is {Mathf.RoundToInt(currentTime)} s";
        gameOverScreen.SetActive(true);

        if (GameManager.Instance.bestRecord == null || GameManager.Instance.bestRecord.time > currentTime)
        {
            GameManager.Instance.UpdateRecord(currentTime);
        }

        GameManager.Instance.SaveRecord();
    }
}
