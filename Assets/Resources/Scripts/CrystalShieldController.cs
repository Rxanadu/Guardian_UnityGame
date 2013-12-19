using UnityEngine;
using System.Collections;

/// <summary>
/// controls functions of shields surrounding crystal
/// @Author: Edgar Onukwugha
/// @Date: 12/17/2013
/// @Usage: place on each shield surrounding the crystal object
/// </summary>
public class CrystalShieldController : MonoBehaviour
{

    public int maxHealth;
    public float shieldCooldown;
    public float shieldRechargeRate;
    public float shieldRechargeDelay;
    public Color fullShieldColor;
    public Color lowShieldColor;
    public float offsetY = 1.7f;

    float initTransformY;
    float disabledTransformY;
    Vector3 initPosition;
    Vector3 disabledPosition;

    int health;

    void Start()
    {
        InitializeShield();
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        renderer.material.color = Color.Lerp(lowShieldColor,
            fullShieldColor, health / maxHealth);

        if(health< maxHealth)
            Invoke("RechargeShield", shieldRechargeDelay);

        if (health <= 0)
        {
            DisableShield();
        }
    }

    void InitializeShield() {
        health = maxHealth;
        renderer.material.color = fullShieldColor;
        initTransformY = transform.position.y;
        disabledTransformY = initTransformY - offsetY;
        initPosition = new Vector3(transform.localPosition.x, initTransformY, transform.localPosition.z);
        disabledPosition = new Vector3(transform.localPosition.x, disabledTransformY, transform.localPosition.z);
    }

    void DisableShield()
    {
        //move shield to disabled position (y-axis)
        transform.localPosition = Vector3.MoveTowards(transform.localPosition,
            disabledPosition, Time.deltaTime);
    }

    void EnableShield()
    {
        //move shield to original position (y-axis)
        transform.localPosition = Vector3.MoveTowards(transform.localPosition,
            initPosition, Time.deltaTime);

        //reset health
        health = maxHealth;
    }

    void RechargeShield()
    {
      health++;                 
    }

    //hurt a shield
    public void DamageShieldHealth(int shieldDamage)
    {
        health -= shieldDamage;
    }
}