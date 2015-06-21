using UnityEngine;
using System.Collections;

public class DamagePlayerOnCollision : MonoBehaviour {
    public int damage;
    PlayerVitalsController pvc;
	// Use this for initialization
	void Start () {
        pvc = GameController.Instance().Boltz.GetComponent<PlayerVitalsController>() as PlayerVitalsController;
        if(pvc == null)
        {
            Debug.LogWarning("PVC NOT FOUND ITS A TRAP");
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            pvc.Damage(damage, this.gameObject);
        }
    }


}
