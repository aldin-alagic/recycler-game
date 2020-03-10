using System.Linq;
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
    private SaveData saveData;

    public void Retry()
    {
        PlayerStatistics.ResetStats();
        Time.timeScale = 1f;
        sceneTransition.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        PlayerStatistics.ResetStats();
        Time.timeScale = 1f;
        Application.Quit();
    }

    void OnEnable()
    {
        saveData = SaveData.instance;
        audioManager = AudioManager.instance;
        audioManager.Stop("Driving");
        Time.timeScale = 0f;

        PlayerStatistics.gameTime = Time.realtimeSinceStartup - PlayerStatistics.gameTime;
        PlayerStatistics.timeScore = 6000f - (PlayerStatistics.gameTime * 10);
        PlayerStatistics.playerScore += PlayerStatistics.timeScore;
        Score score = new Score(PlayerStatistics.playerScore);
        saveData.Save(score);

        correctAnswersValue.text = PlayerStatistics.correctAnswers.ToString();
        incorrectAnswersValue.text = PlayerStatistics.incorrectAnswers.ToString();
        timeValue.text = PlayerStatistics.gameTime.ToString("F2") + "  s";
        scoreValue.text = PlayerStatistics.playerScore.ToString("F2");

        float bestScore = saveData.Load().Max(sc => sc.value);
        bestScoreValue.text = bestScore.ToString("F2");
    }
}

