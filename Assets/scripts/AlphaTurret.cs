using UnityEngine;
using System.Collections;

public class AlphaTurret : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform Muzzle;
    public float bulletSpeed = 0.1f;
    public int FireRate = 1000;
    public bool FireContinuous = false;
    public bool TurnContinuous = false;
    public bool IgnoreRange = false;
    public AudioClip TurretShotSound;

    private Cooldown attackCooldown = new Cooldown(2000);
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogWarning("Alpha Turret was unable to find an AudioSource. This may cause problems.");
        }
    }

    void FixedUpdate()
    {
        if (IgnoreRange)
        {
            RunTurretLogic();
        }

        if (TurnContinuous)
        {
            Turn();
        }
    }

    private void RunTurretLogic()
    {
        attackCooldown.CooldownTime = FireRate;

        if (attackCooldown.Available())
        {
            if (FireContinuous)
            {
                Fire();
            }
            else
            {
                Vector3 direction = GameController.Instance().Boltz.transform.position - Muzzle.transform.position;
                RaycastHit2D hit = Physics2D.Raycast(Muzzle.transform.position, direction);
                if (hit.collider.gameObject.tag == "Player")
                {
                    Fire();
                }
            }
        }
    }

    private void Turn()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, LookAt2D(gameObject, GameController.Instance().Boltz), Time.deltaTime * 8);
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, Muzzle.position, Muzzle.rotation) as GameObject;
        bullet.transform.rotation = LookAt2D(bullet, GameController.Instance().Boltz);
        Vector3 direction = GameController.Instance().Boltz.transform.position - bullet.transform.position;
        bullet.GetComponent<Rigidbody2D>().AddForce(bulletSpeed * direction.normalized);
        source.PlayOneShot(TurretShotSound);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        bool playerInRange = (coll.gameObject.tag == "Player");

        if (!IgnoreRange && playerInRange)
        {
            RunTurretLogic();
        }

        if (!TurnContinuous && playerInRange)
        {
            Turn();
        }
    }

    private Quaternion LookAt2D(GameObject o, GameObject target)
    {
        Quaternion newRotation = Quaternion.LookRotation(o.transform.position - target.transform.position, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        return newRotation;
    }
}

