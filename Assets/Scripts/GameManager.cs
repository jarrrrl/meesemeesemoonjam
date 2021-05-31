using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 4f;
    public Text gameOverText;
    public Canvas winCanvas;
    public void EndGame()
    {
        Debug.Log("GAME OVER");
        gameOverText.enabled = true;
        Invoke("Restart", restartDelay);
    }
    void Restart()
    {
        AudioManager.instance.StopPlaying("BossTheme");
        AudioManager.instance.StopPlaying("PlaneswalkerTheme");
        AudioManager.instance.StopPlaying("CityTheme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameWin()
    {
        winCanvas.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;

    }
}
