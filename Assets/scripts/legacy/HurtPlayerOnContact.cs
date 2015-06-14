using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour
{

    #region Editor Variables
    public int damage = 1;
    #endregion

    private PlayerVitalsController vitalsController;

    void Start()
    {
        vitalsController = GameController.Instance().playerBallInstance.GetComponent<PlayerVitalsController>() as PlayerVitalsController;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == GameController.Instance().playerBallInstance)
        {
            vitalsController.Hurt(damage);
        }
    }

}
