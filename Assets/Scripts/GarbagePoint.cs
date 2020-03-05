using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GarbagePoint : MonoBehaviour
{
    public float range = 2f;
    public string garbageTruckTag = "Garbage Truck";
    public bool cleared = false;
    public GameObject recycleDialogUI;

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
            recycleDialogUI.SetActive(true);
            cleared = true;
            Destroy(gameObject, 0.1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
