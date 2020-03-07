using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{

    public static int correctAnswers;
    public static int incorrectAnswers;
    public static float gameTime;
    public static float timeScore = 10000f;
    public static float playerScore;


    void Start()
    {
        gameTime = 0;
        correctAnswers = 0;
        incorrectAnswers = 0;
        playerScore = 0f;
    }


}
