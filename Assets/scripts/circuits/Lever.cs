using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {
    public GameObject attachedGameObject;
    private ConnectedComponent connectedComp;
    private int powerState; //0 is off 1 is on
	// Use this for initialization
	void Start () {
        if(attachedGameObject != null)
        {
            connectedComp = attachedGameObject.GetComponent<ConnectedComponent>() as ConnectedComponent;
            if (connectedComp == null)
            {
                Debug.LogWarning("Component Script Not Found");
            }
        } else
        {
            Debug.LogWarning("No Attached GameObject To Switch");
        }
        
      
       
	}
	
	// Update is called once per frame
	void Update () 
    {
            //TODO\\
        /*Check power state
         * Change Animation based on power state
         */
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            switch (powerState)
            {
                case 0:
                    powerState = 1;
                    connectedComp.updateComponent(true);
                    break;
                case 1:
                    powerState = 0;
                    connectedComp.updateComponent(false);
                    break;
                default:
                    break;
            }
        }
    }


}
