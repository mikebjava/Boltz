
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class PlayerVitalsController : MonoBehaviour
{

    #region Editor Variables
    public int MaximumLife = 100;
    public int MinimumLife = 0;
    public int CurrentLife = 100;
    public bool IsDead = false;
    public int InvincibilityTime = 1000;
    public bool UseInvincibilityTimer = true;
    public bool Invincible = false;
    public AudioClip[] HurtSounds;
    #endregion

    #region Events
    public event EventHandler<DamagedEventArgs> Damaged;
    public virtual void OnDamaged(object obj, DamagedEventArgs args)
    {
        if (Damaged != null)
        {
            Damaged(obj, args);
        }
    }

    public event EventHandler<DeathEventArgs> Death;
    public virtual void OnDeath(object obj, DeathEventArgs args)
    {
        if (Death != null)
        {
            Death(obj, args);
        }
    }

    public event EventHandler<HealEventArgs> Heal;
    public virtual void OnHeal(object obj, HealEventArgs args)
    {
        if (Heal != null)
        {
            Heal(obj, args);
        }
    }
    #endregion

    private Cooldown invCD;
    private AudioSource source;

    void Start()
    {
        invCD = new Cooldown(InvincibilityTime);
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogWarning("PlayerVitalsController was unable to locate an audio source. This may cause problems.");
        }
    }

    void FixedUpdate()
    {
        invCD.CooldownTime = InvincibilityTime;
    }

    public void Damage(float damage, GameObject damageSource)
    {
        if ((invCD.Available() && !Invincible) || (!UseInvincibilityTimer && !Invincible))
        {
            CurrentLife = (int)(Mathf.Clamp(CurrentLife - damage, MinimumLife, MaximumLife));
            DamagedEventArgs args = new DamagedEventArgs();
            args.Damage = damage;
            args.DamagedObject = gameObject;
            args.DamagingObject = damageSource;
            args.CurrentLife = CurrentLife;
            OnDamaged(this, args);

            if (CurrentLife <= MinimumLife)
            {
                Kill(damageSource);
            }

            PlayRandomHurtSound();
        }
    }

    public void Kill(GameObject killer)
    {
        if (!IsDead)
        {
            DeathEventArgs args = new DeathEventArgs();
            args.Killer = killer;
            args.Victim = this.gameObject;
            OnDeath(this, args);
            IsDead = true;
            Destroy(gameObject);
        }
    }

    public void Mend(int value, GameObject source)
    {
        CurrentLife = (int)(Mathf.Clamp(CurrentLife + value, MinimumLife, MaximumLife));
        HealEventArgs args = new HealEventArgs();
        args.Amount = value;
        args.CurrentLife = CurrentLife;
        args.Receiver = gameObject;
        args.Source = source;
        OnHeal(this, args);
    }

    private void PlayRandomHurtSound()
    {
        if (source != null && HurtSounds != null && HurtSounds.Length > 0)
        {
            source.pitch = UnityEngine.Random.Range(0.9f, 1.0f);

            AudioClip c = HurtSounds[UnityEngine.Random.Range(0, HurtSounds.Length)];
            source.PlayOneShot(c);
        }
    }
}

