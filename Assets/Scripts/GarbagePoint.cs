using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GarbagePoint : MonoBehaviour
{
    public float range = 2f;
    public string garbageTruckTag = "Garbage Truck";
    public bool cleared = false;
    public Texture2D garbageImage;
    public GameObject recycleDialogUI;
    public GameObject imageContainer;
    public GameObject textContainer;
    public GameObject correctGarbageCanBtn;
    public string explanation = "Vrećice grickalica idu u kanticu za papir";

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.4f);
    }

    void UpdateTarget()
    {
        GameObject garbageTruck = GameObject.FindGameObjectWithTag(garbageTruckTag);
        float distanceGarbageTruck = Vector3.Distance(transform.position, garbageTruck.transform.position);
        if (distanceGarbageTruck <= range && !cleared)
        {
            imageContainer.GetComponentInChildren<RawImage>().texture = garbageImage;
            textContainer.GetComponentInChildren<Text>().text = explanation;
            correctGarbageCanBtn.SetActive(false);
            recycleDialogUI.SetActive(true);
            cleared = true;
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
