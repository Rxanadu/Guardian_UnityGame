using UnityEngine;
using System.Collections;

/// <summary>
/// controls what occurs to player if player object collides
/// with object
/// @Author: Edgar Onukwugha
/// @Date: 12/8/2013
/// </summary>
public class DeathAreaController : MonoBehaviour {

    public GameObject spawnPoint;
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player);
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            ResetPlayerToCheckpoint(spawnPoint);
        }
    }

    //places player back to current checkpoint
    void ResetPlayerToCheckpoint(GameObject checkPoint) {
        player.transform.position = checkPoint.transform.position;
        player.rigidbody.velocity = Vector3.zero;
    }
}
