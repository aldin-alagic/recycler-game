using System;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 50f;


    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {

        var targetRotation = Quaternion.LookRotation(target.position - transform.position);
        Vector3 direction = target.position - transform.position;

        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
