using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFinished : MonoBehaviour
{

    public Text correctAnswersValue;
    public Text incorrectAnswersValue;
    public Text timeValue;
    public Text scoreValue;
    public Text bestScoreValue;
    public SceneTransitionManager sceneTransition;

    private AudioManager audioManager;

    public void Retry()
    {
        Time.timeScale = 1f;
        sceneTransition.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    void OnEnable()
    {
        audioManager = AudioManager.instance;
        audioManager.Stop("Driving");
        Time.timeScale = 0f;
        PlayerStatistics.gameTime = Time.realtimeSinceStartup;
        PlayerStatistics.timeScore = 6000f - (PlayerStatistics.gameTime * 10);
        PlayerStatistics.playerScore += PlayerStatistics.timeScore;

        correctAnswersValue.text = PlayerStatistics.correctAnswers.ToString();
        incorrectAnswersValue.text = PlayerStatistics.incorrectAnswers.ToString();
        timeValue.text = PlayerStatistics.gameTime.ToString("F2") + "  s";
        scoreValue.text = PlayerStatistics.playerScore.ToString("F2");
        bestScoreValue.text = PlayerStatistics.playerScore.ToString("F2");
    }
}

