using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;

    void Update()
    {
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
        transform.RotateAround(transform.parent.position, Vector3.up, 20 * Time.deltaTime);
    }
}
