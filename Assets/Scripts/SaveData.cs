using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Save(Score score)
    {
        List<Score> scores = new List<Score>();
        if (PlayerPrefs.HasKey("Data"))
        {
            scores = Load();
        }
        scores.Add(score);

        string json = JsonHelper.ToJson(scores.ToArray());
        PlayerPrefs.DeleteKey("Data");
        PlayerPrefs.SetString("Data", json);
        PlayerPrefs.Save();
    }

    public List<Score> Load()
    {
        string json = PlayerPrefs.GetString("Data");
        Score[] scoresArr = JsonHelper.FromJson<Score>(json);
        List<Score> scores = scoresArr.OfType<Score>().ToList();

        return scores;
    }

}
