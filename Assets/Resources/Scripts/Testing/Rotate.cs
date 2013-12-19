using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float rotSpeed = 20;
	
	// Update is called once per frame
	void Update () {
        float rotStep = rotSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotStep);
	}
}
