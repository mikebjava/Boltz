using UnityEngine;
using System.Collections;

public class MagnetHands : MonoBehaviour
{

    public Transform PullLocation;
    public LayerMask PullableLayers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RaycastHit2D hit = Physics2D.Raycast(PullLocation.position, Vector2.right, 5f, PullableLayers);


            if (hit.collider != null)
            {
                Debug.Log("Raycast hit '" + hit.collider.gameObject.name + "' with tag '" + hit.collider.tag + "'");

                if (hit.collider.gameObject.tag == "Metallic")
                {
                    Rigidbody2D rb = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    rb.AddForceAtPosition(new Vector2(10, 0), hit.point);
                    
                }
            }
        }
    }
}
