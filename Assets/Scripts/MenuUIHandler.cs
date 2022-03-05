using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TextMeshProUGUI bestRecordText;

    void Start()
    {
        // Show the saved data if any
        if (GameManager.Instance.bestRecord != null)
        {
            bestRecordText.text = $"Best Time: {GameManager.Instance.bestRecord.name} - {Mathf.RoundToInt(GameManager.Instance.bestRecord.time)} s";
            bestRecordText.gameObject.SetActive(true);
        }

        nameInputField.text = GameManager.Instance.CurrentPlayer;
    }

    // Load the main scene
    public void StartGame()
    {
        GameManager.Instance.CurrentPlayer = nameInputField.text == "" ? "Anonymous" : nameInputField.text;
        GameManager.Instance.isGameOver = false;
        SceneManager.LoadScene(1);
    }

    // Exit the game
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
