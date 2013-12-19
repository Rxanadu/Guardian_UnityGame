using UnityEngine;
using System.Collections;

/// <summary>
/// controls all aspects of the crystal, the device the player
/// protects through the game
/// @Author: Edgar Onukwugha
/// @Date: 12/12/2013
/// </summary>
public class CrystalController : MonoBehaviour
{

    public Color fullHealthColor = Color.green;
    public Color lowHealthColor = Color.red;
    public int maxHealth = 10;
    public float rotSpeed = 5;

    int health;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    // Use this for initialization
    void Start()
    {
        InitializeCrystal();
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        renderer.material.color = Color.Lerp(lowHealthColor,
            fullHealthColor, health / maxHealth);

        //rotate crystal
        float rotStep = rotSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotStep);
    }

    //start crystal off at start of game
    void InitializeCrystal()
    {
        health = maxHealth;
        renderer.material.color = fullHealthColor;
    }

    //hurt the crystal
    public void DamageCrystalHealth(int healthDamage)
    {
        health -= healthDamage;
    }
}