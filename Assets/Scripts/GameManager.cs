using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject gamePaused;
    public static bool gameIsOver;

    AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
        audioManager.Play("Ambience");
        audioManager.Play("Theme");
        gameIsOver = false;
    }
    void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        /*if (PlayerStats.Health <= 0)
        {
            gameIsOver = true;
            EndGame();
        }*/
    }

    void EndGame()
    {
        /*audioManager.Stop("Game music");
        audioManager.Play("Game over");
        gameOverUI.SetActive(true);*/
    }
}
