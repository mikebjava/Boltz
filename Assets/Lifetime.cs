using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour
{

    #region Editor Variables
    public int Time = 5000;
    #endregion

    private Cooldown lifetime;

    void Start()
    {
        lifetime = new Cooldown(Time);
        lifetime.Available();
    }

    void FixedUpdate()
    {
        if (lifetime.Available())
        {
            Destroy(gameObject);
        }
    }

}
