using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 4f;
    public Text gameOverText;
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
}
