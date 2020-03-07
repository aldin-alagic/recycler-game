using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public Image image;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float time = 1f;

        while (time > 0f)
        {
            time -= Time.deltaTime * 0.5f;
            float alpha = curve.Evaluate(time);
            image.color = new Color(0f, 0f, 0f, time);
            yield return 0;
        }
    }
    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeOut(string scene)
    {
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * 0.5f;
            float alpha = curve.Evaluate(time);
            image.color = new Color(0f, 0f, 0f, time);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}
