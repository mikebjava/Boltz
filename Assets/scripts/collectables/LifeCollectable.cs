using UnityEngine;
using System.Collections;

public class LifeCollectable : Collectable
{
    #region Editor Variables
    public int value;
    #endregion

    // Use this for initialization
	void Start () {
        Collected += addLifeOnCollect;
	}

    private void addLifeOnCollect(object sender, CollectableCollectedEventArgs args)
    {
        PlayerVitalsController pvc = GameController.Instance().Boltz.GetComponent<PlayerVitalsController>() as PlayerVitalsController;
        pvc.addLife(value, this.gameObject);
    }
	

}
