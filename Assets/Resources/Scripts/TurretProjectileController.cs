using UnityEngine;
using System.Collections;

/// <summary>
/// Control all what occurs when a turret projectile 
/// collides with a specific object
/// @Author: Edgar Onukwugha
/// @Date: 12/15/2013
/// @Usage: attach to turret projectile(s)
/// </summary>
public class TurretProjectileController : MonoBehaviour
{
    int shieldDamage;
    int crystalDamage;
    int turretExpDamage;    //should be negative
    int turretExp;

    public int ShieldDamage
    {
        get { return shieldDamage; }
        set { shieldDamage = value; }
    }

    public int CrystalDamage
    {
        get { return crystalDamage; }
        set { crystalDamage = value; }
    }

    public int TurretExpDamage
    {
        get { return turretExpDamage; }
        set { turretExpDamage = value; }
    }

    public int TurretExp
    {
        get { return turretExp; }
        set { TurretExp = value; }
    }

    [HideInInspector]
    public MiniturretController turret;

    void Start()
    {
        shieldDamage = 25;
        crystalDamage = 2;
        turretExp = 1;
        turretExpDamage = -3;
    }

    void OnCollisionEnter(Collision other)
    {
        //damage crystal shield
        if (other.gameObject.tag == Tags.crystalShield)
        {
            CrystalShieldController csc = other.gameObject.GetComponent<CrystalShieldController>();
            //decrease shield health
            csc.DamageShieldHealth(shieldDamage);

            //increase turret exp
            //turret.AlterExperiencePoints (turretExp);

        }

        //damage turret exp
        if (other.gameObject.tag == Tags.player)
        {
            //decrease turret exp
            //turret.AlterExperiencePoints(turretExpDamage);
        }

        //damage crystal
        if (other.gameObject.tag == Tags.crystal)
        {
            CrystalController cc = other.gameObject.GetComponent<CrystalController>();
            //decrease crystal health
            cc.DamageCrystalHealth(crystalDamage);

            //increase turret exp
            //turret.AlterExperiencePoints(turretExp);
        }
    }
}