using UnityEngine;
using System.Collections;

//attach to all projectile prefabs
[RequireComponent(typeof(AudioSource))]
public class ProjectileManager : MonoBehaviour
{
    public float lifeLimit = 5f;
    public float rotationSpeed = 20f;
    public GameObject deathParticleSystem;
    public AudioClip firingClip, collisionClip;

    [HideInInspector]
    public bool countdownIsActive = true;

    float life = 0f;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);

        if(countdownIsActive)
            Countdown();
    }

    void OnCollisionEnter(Collision c)
    {
        //ReflectOffSurface(c);
        Deactivate();
    }

    void Countdown()
    {
        if (life < Time.time)
        {
            Deactivate();
        }
    }

    public void Activate()
    {
        life = Time.time + lifeLimit;

        if (firingClip != null &&
            !audio.isPlaying)
        {
            audio.clip = firingClip;
            audio.Play();
        }
    }

    public void Deactivate()
    {
        if (deathParticleSystem != null)
        {
            if (collisionClip != null)
            {
                Instantiate(deathParticleSystem, transform.position, Random.rotation);
                audio.clip = collisionClip;
                audio.PlayOneShot(audio.clip);
                if (!audio.isPlaying)
                    Destroy(gameObject);
            }
        }
        else
            Destroy(gameObject);
    }

    void ReflectOffSurface(Collision c)
    {
        Vector3 reflectDir = Vector3.Reflect(transform.forward, c.contacts[0].normal);
        float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, rot, 0);
    }
}