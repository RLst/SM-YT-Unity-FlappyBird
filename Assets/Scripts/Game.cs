using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Bird bird;
    public UnityEvent onGameOver;

    void Start()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    void Update()
    {
        if (bird.isDead)
            GameOver();
    }

    void GameOver()
    {
        onGameOver.Invoke();    //Show gave over screen, play lose sound, vv

        Time.timeScale = 0f;    //Pause the game
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        // Debug.Log("Quitting!");
        Application.Quit();
    }
}
