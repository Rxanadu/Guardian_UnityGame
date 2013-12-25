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

    public float maxHealth;
    public float shieldCooldown = 5f;
    public float shieldMovementRate = .3f;
    public float shieldRechargeDelay;
    public Color fullShieldColor;
    public Color lowShieldColor;
    public float offsetY = 1.7f;

    float initTransformY;
    float disabledTransformY;
    float timer;
    Vector3 initPosition;
    Vector3 disabledPosition;
    bool healingAllowed;
    bool shieldDisabled;

    float health;

    void Start()
    {
        InitializeShield();
        InvokeRepeating("RechargeShield", 1, 1);
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        renderer.material.color = Color.Lerp(lowShieldColor,
            fullShieldColor, health / maxHealth);

        if (health <= 0) { 
            StopAllCoroutines();
            StartCoroutine(DisengageShieldDuringCooldown(shieldCooldown));
        }
            
    }

    //sets up all elements of shield at start of game
    void InitializeShield()
    {
        health = maxHealth;
        renderer.material.color = fullShieldColor;
        initTransformY = transform.position.y;
        disabledTransformY = initTransformY - offsetY;
        initPosition = new Vector3(transform.localPosition.x, initTransformY, transform.localPosition.z);
        disabledPosition = new Vector3(transform.localPosition.x, disabledTransformY, transform.localPosition.z);
        shieldDisabled = false;
        healingAllowed = true;
        timer = 0;
    }

    //stops shield from regenerating when hit
    IEnumerator DelayShieldRegen(float delay) {
        healingAllowed = false;
        yield return new WaitForSeconds(delay);
        healingAllowed = true;
    }

    IEnumerator DisengageShieldDuringCooldown(float cooldown) {
        float movementStep = shieldMovementRate * Time.deltaTime;
        shieldDisabled = true;
        while (Vector3.Distance(transform.localPosition, disabledPosition) > 0) {
            //move shield to disabled position (y-axis)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                disabledPosition, movementStep);
        }

        yield return new WaitForSeconds(cooldown);

        shieldDisabled = false;

        health = maxHealth;

        while (Vector3.Distance(transform.localPosition, initPosition) > 0) {
            //move shield to original position (y-axis)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                initPosition, movementStep);
        }

        yield return null;
    }

    void RechargeShield()
    {
        if (healingAllowed && health < maxHealth)
            health++;
    }

    //hurt a shield
    public void DamageShieldHealth(float shieldDamage)
    {
        health -= shieldDamage;
        DelayShieldRegen(shieldRechargeDelay);
    }
}