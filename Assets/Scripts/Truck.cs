using System;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public GameObject gameOverUI;
    public float speed = 10f;
    public float rotationSpeed = 50f;

    private AudioManager audioManager;
    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        audioManager = AudioManager.instance;
        audioManager.Play("Driving");
        target = Waypoints.points[0];
    }

    private void Update()
    {
        if (!GameManager.gameIsOver)
        {
            Vector3 direction = target.position - transform.position;
            var targetRotation = Quaternion.LookRotation(direction);

            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
            }
        }
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            GameManager.gameIsOver = true;
            gameOverUI.SetActive(true);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
