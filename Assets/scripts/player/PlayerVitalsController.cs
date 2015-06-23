
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
    #endregion

    public void Damage(float damage, GameObject damageSource)
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
        }
    }


}

