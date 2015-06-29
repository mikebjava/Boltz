using UnityEngine;
using System.Collections;

public class ToxicGooDrip : MonoBehaviour
{

    #region Editor Variables
    public int Damage = 5;
    #endregion

    private PlayerVitalsController pvc;
    private Animator animator;

    void Start()
    {
        pvc = GameController.Instance().Boltz.GetComponent<PlayerVitalsController>() as PlayerVitalsController;
        if (pvc == null)
        {
            Debug.LogWarning("ToxicGooDrip droplet was unable to locate the PlayerVitalsController. This may cause problems.");
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("ToxicGooDrip was unable to find an animator. This may cause problems.");
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Mechanic")
        {
            if (coll.gameObject.tag == "Player")
            {
                if (pvc != null)
                {
                    pvc.Damage(Damage, gameObject);
                }

                Destroy(gameObject);
                return;
            }

            if (animator != null)
            {
                animator.SetBool("hitGround", true);
            }


            Destroy(gameObject, 2000);
        }
    }

}
