using System.Collections.Generic;

[System.Serializable]
public class Scores
{
    public List<Score> scores;

    public Scores()
    {
        scores = new List<Score>();
    }
}