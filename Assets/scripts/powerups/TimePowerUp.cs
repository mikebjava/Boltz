using UnityEngine;
using System.Collections;

public class TimePowerUp : MonoBehaviour {
    public float timeAdded;
    private JTimer timer;
    private CollisionController cc;
	void Start () 
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        timer = go.GetComponent<JTimer>() as JTimer;
        cc = GameController.Instance().boltzInstance.GetComponent<CollisionController>() as CollisionController;
        if(go == null)
        {
            Debug.LogWarning("UI not found. This may cause errors");
        }
        if(timer == null)
        {
            Debug.LogWarning("Timer not found. This may cause errors");
        } 
        if(cc == null)
        {
            Debug.LogWarning("Collision Controller not found. This may cause errors");
        }
        else
        {
            cc.Collided += SyncCollision;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void SyncCollision(object obj, CollisionEventArgs args)
    {
        if(args.isTrigger)
        {
            if(args.triggerObject != null)
            {
               
                if(args.triggerObject.gameObject.tag == "TimePowerUp" && args.triggerObject.gameObject == this.gameObject)
                {
                    timer.addTime(timeAdded);
                    cc.Collided -= SyncCollision;
                    gameObject.SetActive(false);
                }
            }
            Debug.LogWarning("Trigger object is null!");
        }
    }
}
