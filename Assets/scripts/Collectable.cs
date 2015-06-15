using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{

    #region Editor Variables
    public int Value = 100;
    #endregion

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            PlayerStatsController psc = GameController.Instance().boltzInstance.GetComponent<PlayerStatsController>() as PlayerStatsController;
            psc.ModifyScore(Value);
            Debug.Log("Player earned points of: " + Value);
            Destroy(gameObject);
        }
            

    }
}
