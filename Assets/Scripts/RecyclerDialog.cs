using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RecyclerDialog : MonoBehaviour
{
    public GameObject userInterface;
    public GameObject garbageCans;
    public GameObject exitBtn;
    public GameObject resultTextContainer;
    public GameObject textContainer;
    public GameObject nameContainer;
    public GameObject imageContainer;
    public GameObject UI;
    public GameObject[] garbageCanBtns;
    public Garbage[] garbages;
    public string titleText = "Znate li reciklirati sljedeći otpad?";

    private Garbage selectedGarbage;
    private int randomIndex;

    private void OnEnable()
    {

        Pause();

        do
        {
            randomIndex = Random.Range(0, garbages.Length);
            selectedGarbage = garbages[randomIndex];
        } while (selectedGarbage.cleared);

        garbageCanBtns[selectedGarbage.garbageCan].GetComponentInChildren<Button>().onClick.AddListener(CorrectAnswer);
        textContainer.GetComponent<TMPro.TextMeshProUGUI>().text = selectedGarbage.text;
        nameContainer.GetComponent<TMPro.TextMeshProUGUI>().text = selectedGarbage.name;
        imageContainer.GetComponent<UnityEngine.UI.RawImage>().texture = selectedGarbage.image;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        StartCoroutine(Wait());
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        Reset();
    }

    public void WrongAnswer()
    {
        garbageCans.SetActive(false);
        resultTextContainer.GetComponent<UnityEngine.UI.Text>().color = Color.red;
        resultTextContainer.GetComponent<UnityEngine.UI.Text>().text = "NETOČNO";
        textContainer.SetActive(true);
        selectedGarbage.cleared = true;

        StartCoroutine(WaitForReading());
    }

    public void CorrectAnswer()
    {
        garbageCans.SetActive(false);
        resultTextContainer.GetComponent<UnityEngine.UI.Text>().color = Color.green;
        resultTextContainer.GetComponent<UnityEngine.UI.Text>().text = "TOČNO";
        textContainer.SetActive(true);
        selectedGarbage.cleared = true;

        StartCoroutine(WaitForReading());
    }

    private void Reset()
    {
        userInterface.SetActive(false);
        exitBtn.SetActive(false);
        garbageCans.SetActive(true);
        resultTextContainer.GetComponent<UnityEngine.UI.Text>().color = Color.white;
        resultTextContainer.GetComponent<UnityEngine.UI.Text>().text = titleText;
        garbageCanBtns[selectedGarbage.garbageCan].GetComponentInChildren<Button>().onClick.AddListener(WrongAnswer);
        textContainer.SetActive(false);
        UI.SetActive(false);
    }

    IEnumerator WaitForReading()
    {
        yield return new WaitForSecondsRealtime(4);
        exitBtn.SetActive(true);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2);
        UI.SetActive(true);
    }
}
