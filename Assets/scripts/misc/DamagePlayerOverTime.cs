using UnityEngine;
using System.Collections;

public class DamagePlayerOverTime : MonoBehaviour {
    public int damagePerTick;
    public float time;
    private bool steppedOn;
    private PlayerVitalsController pvc;
	// Use this for initialization
	void Start () 
    {
        pvc = GameController.Instance().Boltz.GetComponent<PlayerVitalsController>() as PlayerVitalsController;
        if(pvc == null)
        {
            Debug.LogWarning("Warning! Pvc Not found!");
        }
	
	}
	
	// Update is called once per frame
	void Update () {
        if(time > 0f && steppedOn)
        {
            time -= Time.deltaTime;
            damage();
        }
	}

    private void damage()
    {
        pvc.Damage(damagePerTick, this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            steppedOn = true;
        }
    }
}
