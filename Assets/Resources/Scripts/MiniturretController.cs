using UnityEngine;
using System.Collections;

/// <summary>
/// controls mini-turret functions, determines how much damage is
/// inflicted on crystal and shields
/// @Author: Edgar Onukwugha
/// @Date: 12/12/2013
/// Updates (12/15/2013): Implementing upgrade components for turrets
/// </summary>
public class MiniturretController : MonoBehaviour
{
    #region Fields
    public Transform target;
    public Transform emitter;
    public GameObject projectile;
    public float fireSpeed = 6;
    public float fastFireCooldown = 3;
    public float slowFireCooldown = 8;    
    public float rotationAngle = 40;

    float timer;
    float fireCooldown;
    bool turretEnabled;
    int level;
    int exp;
    int expLimit, prevExpLimit;

    int crystalShieldDamage;
    int crystalHealthDamage;
    int expPoints;
    int expPointDamage;
    #endregion

    public bool TurretEnabled
    {
        get { return turretEnabled; }
        set { turretEnabled = value; }
    }

    void Start()
    {
        turretEnabled = true;

        if (target == null)
            target = GameObject.FindGameObjectWithTag(Tags.crystal).transform;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
        RotateAroundTarget();

        if (turretEnabled)
            FireCountdown();
    }

    #region Turret Movement
    //has camera rotate toward target on y-axis
    void LookAtTarget()
    {
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
    }

    void RotateAroundTarget()
    {
        transform.RotateAround(target.position, Vector3.up, rotationAngle * Time.deltaTime);
    }
    #endregion

    #region Turret Attacks
    //instantiates projectile, moves it forward
    void Fire()
    {
        GameObject clone = Instantiate(projectile, emitter.position, Quaternion.identity) as GameObject;
        clone.GetComponent<ProjectileManager>().Activate();
        clone.rigidbody.velocity = emitter.forward * fireSpeed;

        //set values for clone projectile
        TurretProjectileController tpc = clone.GetComponent<TurretProjectileController>();
        /*tpc.CrystalDamage = crystalHealthDamage;
        tpc.ShieldDamage = crystalShieldDamage;
        tpc.TurretExp = expPoints;
        tpc.TurretExpDamage = expPointDamage;
        tpc.turret = this;*/
    }

    //fires projectile from turret at cooldown
    void FireCountdown()
    {
        timer += Time.deltaTime;
        fireCooldown = Random.Range(fastFireCooldown, slowFireCooldown);

        //fire weapon, reset timer
        if (timer >= fireCooldown)
        {
            Fire();
            timer = 0;
        }
    }
    #endregion

    #region Experience and Levels
    //increases or decreases experience points
    //based on change amount
    public void AlterExperiencePoints(int expChangeAmount)
    {
        exp += expChangeAmount;
    }

    void ClampExperienceValues()
    {
        exp = Mathf.Clamp(exp, 0, 50);
        expLimit = Mathf.Clamp(expLimit, 10, 50);
        prevExpLimit = Mathf.Clamp(prevExpLimit, 0, 40);
        level = Mathf.Clamp(level, 1, 5);
    }

    //sets turret's individual level based on experience
    void AlterTurretLevel()
    {
        if (exp >= expLimit)
        {
            level++;
        }

        if (exp < prevExpLimit)
        {
            level--;
        }
    }

    //sets properties in levels for each turret
    void SetLevelProperties()
    {
        switch (level)
        {
            case 1:
                fireSpeed = 2;
                fireCooldown = 4;
                projectile.rigidbody.mass = 0.2f;
                expLimit = 10;
                prevExpLimit = 0;
                crystalShieldDamage = 1;
                crystalHealthDamage = 1;
                expPoints = 1;
                expPointDamage = 1;
                break;
            case 2:
                fireSpeed = 3;
                fireCooldown = 5;
                projectile.rigidbody.mass = .4f;
                expLimit = 20;
                prevExpLimit = 10;
                crystalShieldDamage = 2;
                crystalHealthDamage = 2;
                expPoints = 1;
                expPointDamage = 1;
                break;
            case 3:
                fireSpeed = 4;
                fireCooldown = 6;
                projectile.rigidbody.mass = .6f;
                expLimit = 30;
                prevExpLimit = 20;
                crystalShieldDamage = 3;
                crystalHealthDamage = 3;
                expPoints = 1;
                expPointDamage = 1;
                break;
            case 4:
                fireSpeed = 5;
                fireCooldown = 7;
                projectile.rigidbody.mass = .8f;
                expLimit = 40;
                prevExpLimit = 30;
                crystalShieldDamage = 4;
                crystalHealthDamage = 4;
                expPoints = 1;
                expPointDamage = 1;
                break;
            case 5:
                fireSpeed = 6;
                fireCooldown = 8;
                projectile.rigidbody.mass = 1;
                expLimit = 50;
                prevExpLimit = 40;
                crystalShieldDamage = 5;
                crystalHealthDamage = 5;
                expPoints = 1;
                expPointDamage = 1;
                break;
        }
    }
    #endregion
}