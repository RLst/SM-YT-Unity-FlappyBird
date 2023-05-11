using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Bird bird;
    public UnityEvent onGameStart;
    public UnityEvent onGameOver;

    bool isGameStarted = false;
    bool isGameOver = false;

    void Start()
    {
        isGameStarted = false;
        isGameOver = false;
        Time.timeScale = 0f;
        Cursor.visible = false;
    }

    void Update()
    {
        if (isGameOver)
            if (Input.GetKeyDown(KeyCode.Return))
                RestartGame();

        if (bird.isDead)
            GameOver();

        if (!isGameStarted)
            if (Input.anyKeyDown)
            {
                isGameStarted = true;
                Time.timeScale = 1f;
                onGameStart.Invoke();
            }
    }

    void GameOver()
    {
        onGameOver.Invoke();    //Show gave over screen, play lose sound, vv

        Time.timeScale = 0f;    //Pause the game
        Cursor.visible = true;
        isGameOver = true;
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
