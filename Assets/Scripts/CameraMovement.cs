using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float sSpeed = 10.0f;
    public Vector3 dist;
    public Transform lookTarget;

    void LateUpdate()
    {
        Vector3 dPos = target.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }

}


