using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

    public Transform target;
    public float maxDist = 5f;
    public float minDist = 1f;

	// Update is called once per frame
	void Update () {
        transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);

        
        //keep object a certain distance from target
        float dist = Vector3.Distance(transform.position, target.position);
        dist = Mathf.Clamp(dist, minDist, maxDist);

        print("Current distance from target: "+ dist);
	}
}
