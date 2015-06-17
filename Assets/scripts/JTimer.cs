using UnityEngine;
using System.Collections;

public class JTimer : MonoBehaviour {
    public float timeLeft;
    public GameObject go;
    //public Text text;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        timeLeft -= Time.deltaTime;
        //text.text = "Time Left " + timeLeft;
    }
}
