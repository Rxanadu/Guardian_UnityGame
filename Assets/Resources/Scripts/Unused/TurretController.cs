using UnityEngine;
using System.Collections;

/// <summary>
/// Controls all aspects of turret in game
/// @Author:Edgar Onukwugha
/// @Date: 12/4/2013
/// </summary>
public class TurretController : MonoBehaviour {

    public Transform[] turrets;
    public GameObject projectile;
    public float shotSpeed = 3;
    public float rotSpeed = 20;
    public float shotCooldown = 3;
    public bool centerTurret = true;

    float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (centerTurret) {
            RotateTurret();
            FireProjectiles(); 
        }
       
	}

    //emits projectiles with initial velocity 
    void FireProjectiles() {
        timer += Time.deltaTime;
        //Debug.Log("Timer: "+ timer);
        if (timer >= shotCooldown) { 
            foreach (Transform turret in turrets) {
                GameObject clone = Instantiate(projectile, turret.position, Quaternion.identity) as GameObject;
                clone.GetComponent<ProjectileManager>().Activate();
                clone.rigidbody.velocity = turret.forward * shotSpeed;
                timer = 0;
            }            
        }             
    }

    //rotates turrent around the center of stage
    void RotateTurret() {
        transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
    }
}
