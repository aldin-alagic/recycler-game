using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{

    public static int correctAnswers;
    public static int incorrectAnswers;
    public static float gameTime;
    public static float timeScore;
    public static float playerScore;

    void Awake()
    {
        ResetStats();
    }

    public static void ResetStats()
    {
        gameTime = Time.realtimeSinceStartup;
        correctAnswers = 0;
        incorrectAnswers = 0;
        playerScore = 0f;
        timeScore = 10000f;
    }

}
