using UnityEngine;
using System.Collections;
using System;

public class Bullet : MonoBehaviour
{

    #region Editor Variables
    public bool DestroyOnContact = true;
    public bool DamageOnContact = true;
    public int Damage = 10;
    public bool HasLifetime = true;
    public int Lifetime = 5000;
    #endregion

    private Cooldown lifeCD;

    void Start()
    {
        lifeCD = new Cooldown(Lifetime);
        lifeCD.Available();
    }

    void FixedUpdate()
    {
        if (lifeCD.Available() && HasLifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && DamageOnContact)
        {
            PlayerVitalsController pvc = GameController.Instance().Boltz.GetComponent<PlayerVitalsController>();
            pvc.Damage(Damage, gameObject);
        }

        if (DestroyOnContact && !coll.isTrigger)
        {
            Destroy(gameObject);
        }
    }

}
