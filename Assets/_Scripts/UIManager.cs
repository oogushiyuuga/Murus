using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "GameScene";
    [SerializeField] private string startSceneName = "StartScene";
    [SerializeField] private TextMeshProUGUI timeText;

    void Start()
    {
        float clearTime = GameManager.Instance.ElapsedTime;
        timeText.text = "CLEAR TIME\n" + FormatTime(clearTime);
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = (int)timeInSeconds / 60;
        int seconds = (int)timeInSeconds % 60;
        int milliseconds = (int)(timeInSeconds * 100) % 100; // ミリ秒（100分の1秒）

        // 00:00.00 の形式で返す
        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

    public void StartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(gameSceneName);
    }

    public void GoToStartScene()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(startSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}